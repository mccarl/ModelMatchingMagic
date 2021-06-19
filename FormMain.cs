using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace ModelMatchingMagic
{
    public partial class FormMain : Form
    {
        readonly ModelMatchingMagic mmm;
        readonly ModelMatchingMagic userOverrides = new ModelMatchingMagic();
        readonly Regex airlinePattern = new Regex("[A-Z]{3}");

        public FormMain()
        {
            InitializeComponent();

            using(WebClient wc = new WebClient())
            {
                string mmmJson = wc.DownloadString("https://raw.githubusercontent.com/mccarl/ModelMatchingMagic/master/ModelMatchingMagic.json");
                mmm = JsonConvert.DeserializeObject<ModelMatchingMagic>(mmmJson);
            }

            try
            {
                using (StreamReader r = new StreamReader("ModelMatchingMagic.json"))
                {
                    string userOverridesJson = r.ReadToEnd();
                    userOverrides = JsonConvert.DeserializeObject<ModelMatchingMagic>(userOverridesJson);
                }
            }
            catch (FileNotFoundException) { }


            foreach (Airline_Group g in mmm.airline_groups)
            {
                string[] rowData = new string[g.codes.Length + 1];
                rowData[0] = g.name;
                g.codes.CopyTo(rowData, 1);

                while (dataGridViewAirlines.Columns.Count < g.codes.Length + 2)
                {
                    int c = dataGridViewAirlines.Columns.Add("colCodes", "");
                    dataGridViewAirlines.Columns[c].Width = 60;
                    dataGridViewAirlines.Columns[c].ReadOnly = true;
                }

                int i = dataGridViewAirlines.Rows.Add(rowData);
                dataGridViewAirlines.Rows[i].Cells[0].ReadOnly = true;
                for (int c = 1; c < dataGridViewAirlines.Columns.Count; c++)
                {
                    dataGridViewAirlines.Rows[i].Cells[c].ReadOnly = c > g.codes.Length + 1;
                }
            }
            foreach (Airline_Group g in userOverrides.airline_groups)
            {
                while (g.codes.Length >= (dataGridViewAirlines.Columns.Count - 1))
                {
                    int i = dataGridViewAirlines.Columns.Add("colCodes", "");
                    dataGridViewAirlines.Columns[i].Width = 60;
                    dataGridViewAirlines.Columns[i].ReadOnly = true;
                }

                string[] rowData = new string[/*g.codes.Length*/dataGridViewAirlines.Columns.Count + 1];
                rowData[0] = g.name;
                g.codes.CopyTo(rowData, 1);

                bool found = false;
                foreach (DataGridViewRow row in dataGridViewAirlines.Rows)
                {
                    if (String.Equals(g.name, row.Cells[0].Value))
                    {
                        row.SetValues(rowData);
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        for (int c = 1; c < dataGridViewAirlines.Columns.Count; c++)
                        {
                            row.Cells[c].ReadOnly = c > g.codes.Length + 1;
                        }
                        found = true;
                    }
                }
                if (!found)
                {
                    int i = dataGridViewAirlines.Rows.Add(rowData);
                    dataGridViewAirlines.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridViewAirlines.Rows[i].Cells[0].ReadOnly = true;
                    for (int c = 1; c < dataGridViewAirlines.Columns.Count; c++)
                    {
                        dataGridViewAirlines.Rows[i].Cells[c].ReadOnly = c > g.codes.Length + 1;
                    }
                }
            }

            foreach (Aircraft_Type t in mmm.aircraft_types)
            {
                int i = dataGridViewAircraft.Rows.Add(t.type, t.tags.manufacturer, t.tags.size, t.tags.engine, t.regex);
                dataGridViewAircraft.Rows[i].Cells[0].ReadOnly = (i != dataGridViewAircraft.NewRowIndex);
            }
            foreach (Aircraft_Type t in userOverrides.aircraft_types)
            {
                bool found = false;
                foreach (DataGridViewRow row in dataGridViewAircraft.Rows)
                {
                    if (String.Equals(t.type, row.Cells[0].Value))
                    {
                        row.Cells[1].Value = t.tags.manufacturer;
                        row.Cells[2].Value = t.tags.size;
                        row.Cells[3].Value = t.tags.engine;
                        row.Cells[4].Value = t.regex;
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        found = true;
                    }
                }
                if (!found)
                {
                    int i = dataGridViewAircraft.Rows.Add(t.type, t.tags.manufacturer, t.tags.size, t.tags.engine, t.regex);
                    dataGridViewAircraft.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridViewAircraft.Rows[i].Cells[0].ReadOnly = true;
                }
            }

            if (!String.IsNullOrWhiteSpace(userOverrides.path))
            {
                textBoxPath.Text = userOverrides.path;
            }
            checkBoxIncludeIVAO.Checked = userOverrides.include_IVAO_models;
        }

        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = textBoxPath.Text.Replace("%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            if (dlg.ShowDialog(IntPtr.Zero))
            {
                textBoxPath.Text = dlg.ResultPath;
            }
        }

        private void ButtonScan_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text.Replace("%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            try
            {
                Directory.GetFiles(path);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Unable to locate directory (" + path + ")", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userOverrides.path = path;
            SaveUserOverrides();

            tabControl1.SelectedIndex = 0;

            dataGridViewModels.Rows.Clear();

            FindAircraftCfgs(path);

            for (int i = 0; i < dataGridViewModels.Rows.Count; i++)
            {
                dataGridViewModels.Rows[i].Cells[0].ReadOnly = (i != dataGridViewModels.NewRowIndex);
            }
        }

        private void FindAircraftCfgs(string path)
        {
            foreach (string f in Directory.GetFiles(path))
            {
                if (f.Contains("aircraft.cfg"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(f);
                    string line;
                    Dictionary<string, Dictionary<string, string>> content = new Dictionary<string, Dictionary<string, string>>();
                    Dictionary<string, string> section = null;
                    while ((line = file.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.StartsWith("[") && line.EndsWith("]")) {
                            section = new Dictionary<string, string>();
                            try
                            {
                                content.Add(line.Substring(1, line.Length - 2), section);
                            } catch (ArgumentException)
                            {
                                section = null;
                            }
                        }
                        else
                        {
                            int ei = line.IndexOf("=");
                            if (section != null && ei > 0)
                            {
                                string value = line.Substring(ei + 1).Trim();
                                
                                int sci = value.IndexOf(";");
                                if (sci >= 0)
                                {
                                    value = value.Substring(0, value.IndexOf(";")).Trim();
                                }

                                if (value.StartsWith("\"") && value.EndsWith("\""))
                                {
                                    value = value.Substring(1, value.Length - 2);
                                }
                                if (value.StartsWith("\""))
                                {
                                    value = value.Substring(1, value.Length - 1);
                                }

                                section[line.Substring(0, ei).Trim().ToLower()] = value;
                            }
                        }
                    }
                    file.Close();

                    foreach (KeyValuePair<string, Dictionary<string, string>> d in content)
                    {
                        if (d.Value.TryGetValue("title", out string title))
                        {
                            string type = null;
                            string manufacturer = null;
                            string airline = null;
                            Boolean ivao = false;

                            d.Value.TryGetValue("ui_type", out type);
                            d.Value.TryGetValue("ui_manufacturer", out manufacturer);
                            d.Value.TryGetValue("icao_airline", out airline);

                            string typeInput = title + type + manufacturer;

                            type = null;

                            if (d.Value.TryGetValue("ui_createdby", out string creator) && creator.ToLower().Contains("ivao"))
                            {
                                type = title.ToUpper().Substring(0, 4);
                                airline = null;

                                if (d.Value.TryGetValue("texture", out string texture) && texture.Length >= 3)
                                {
                                    airline = texture.ToUpper().Substring(0, 3);
                                }

                                ivao = true;
                            }
                            else
                            {
                                foreach (Aircraft_Type at in mmm.aircraft_types)
                                {
                                    if (at.isMatch(typeInput))
                                    {
                                        type = at.type;
                                    }
                                }
                                foreach (Aircraft_Type at in userOverrides.aircraft_types)
                                {
                                    if (at.isMatch(typeInput))
                                    {
                                        type = at.type;
                                    }
                                }
                            }





                            if (!ivao || checkBoxIncludeIVAO.Checked)
                            {
                                bool exclude = false;

                                
                                if (String.IsNullOrWhiteSpace(airline) || !airlinePattern.IsMatch(airline))
                                {
                                    exclude = true;
                                }

                                bool mmmOverrideFound = false;
                                foreach (Model_Override mo in mmm.model_overrides)
                                {
                                    if (String.Equals(title, mo.model))
                                    {
                                        airline = mo.airline;
                                        type = mo.type;
                                        exclude = mo.exclude != null && (bool)mo.exclude;
                                        mmmOverrideFound = true;
                                    }
                                }

                                bool userOverrideFound = false;
                                foreach (Model_Override mo in userOverrides.model_overrides)
                                {
                                    if (String.Equals(title, mo.model))
                                    {
                                        airline = mo.airline;
                                        type = mo.type;
                                        exclude = (bool)mo.exclude;
                                        userOverrideFound = true;
                                    }
                                }

                                if (String.IsNullOrWhiteSpace(type) || type.Length < 2 || type.Length > 4)
                                {
                                    exclude = true;
                                }

                                int i = dataGridViewModels.Rows.Add(title, airline, type, exclude/* || type == null || type.Length != 4*/);

                                dataGridViewModels.Rows[i].Cells[3].ReadOnly = String.IsNullOrWhiteSpace(type);

                                if (userOverrideFound)
                                {
                                    dataGridViewModels.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                }
                                else if (mmmOverrideFound)
                                {
                                    dataGridViewModels.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                                }
                            }

                            if (title.ToUpper().Contains("xxxTAP"))
                            {
                                foreach (KeyValuePair<string, string> kp in d.Value)
                                {
                                    Console.WriteLine("\t" + kp.Key + "\t\t" + kp.Value);
                                }
                            }
                        }
                    }
                }
            }

            foreach (string d in Directory.GetDirectories(path))
            {
                FindAircraftCfgs(d);
            }
        }

        public static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey key, Func<TValue> createNew)
        {
            if (!dict.TryGetValue(key, out var val))
            {
                val = createNew();
                dict.Add(key, val);
            }

            return val;
        }

        private void SaveUserOverrides()
        {
            string json = JsonConvert.SerializeObject(userOverrides, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter w = new StreamWriter("ModelMatchingMagic.json"))
            {
                w.WriteLine(json);
            }
        }

        private void DataGridViewModels_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewModels.Rows[e.RowIndex];
                if (String.IsNullOrWhiteSpace((string)row.Cells[0].Value) && String.IsNullOrWhiteSpace((string)row.Cells[1].Value) && String.IsNullOrWhiteSpace((string)row.Cells[2].Value))
                {
                    dataGridViewModels.Rows.Remove(row);
                } else
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;

                    if (String.IsNullOrWhiteSpace((string)row.Cells[2].Value))
                    {
                        row.Cells[3].Value = true;
                        row.Cells[3].ReadOnly = true;
                    }
                    else
                    {
                        row.Cells[3].ReadOnly = false;
                    }

                    bool found = false;
                    foreach (Model_Override mo in userOverrides.model_overrides)
                    {
                        if (String.Equals(mo.model, row.Cells[0].Value))
                        {
                            mo.airline = (string)row.Cells[1].Value;
                            mo.type = (string)row.Cells[2].Value;
                            mo.exclude = (bool)row.Cells[3].Value;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Model_Override mo = new Model_Override();
                        mo.model = (string)row.Cells[0].Value;
                        mo.airline = (string)row.Cells[1].Value;
                        mo.type = (string)row.Cells[2].Value;
                        mo.exclude = (bool)row.Cells[3].Value;
                        userOverrides.model_overrides.Add(mo);
                    }
                }

                SaveUserOverrides();
            }
        }

        private void DataGridViewModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                DataGridViewRow row = dataGridViewModels.Rows[e.RowIndex];
                if (!row.Cells[3].ReadOnly)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void DataGridViewModels_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewModels.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl))
            {
                ((DataGridViewTextBoxEditingControl)dataGridViewModels.EditingControl).CharacterCasing = dataGridViewModels.CurrentCell.ColumnIndex > 0 ? CharacterCasing.Upper : CharacterCasing.Normal;
                ((DataGridViewTextBoxEditingControl)dataGridViewModels.EditingControl).Text = (string)dataGridViewModels.CurrentCell.Value;
            }
        }

        private void DataGridViewModels_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo ht = dataGridViewModels.HitTest(e.X, e.Y);
                dataGridViewModels.CurrentCell = dataGridViewModels.Rows[ht.RowIndex].Cells[Math.Max(ht.ColumnIndex, 0)];
                if (dataGridViewModels.Rows[ht.RowIndex].DefaultCellStyle.ForeColor == Color.Red)
                {
                    contextMenuStrip.Show(dataGridViewModels, e.Location);
                }
            }
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripMenuItemClear)
            {
                string model = (string)dataGridViewModels.Rows[dataGridViewModels.CurrentCell.RowIndex].Cells[0].Value;

                foreach (Model_Override mo in userOverrides.model_overrides)
                {
                    if (String.Equals(mo.model, model))
                    {
                        userOverrides.model_overrides.Remove(mo);
                        break;
                    }
                }
                SaveUserOverrides();

                ButtonScan_Click(sender, e);
            }
        }

        private void DataGridViewAirlines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAirlines.Rows[e.RowIndex];
                row.DefaultCellStyle.ForeColor = Color.Red;

                List<string> codes = new List<string>();
                int dest = 1;
                for (int src = 1; src < row.Cells.Count; src++)
                {
                    row.Cells[dest].Value = row.Cells[src].Value;
                    if (!String.IsNullOrWhiteSpace((string)row.Cells[src].Value))
                    {
                        codes.Add((string)row.Cells[src].Value);
                        row.Cells[dest++].ReadOnly = false;
                    }
                }
                if (dest >= row.Cells.Count)
                {
                    int i = dataGridViewAirlines.Columns.Add("colCodes", "");
                    dataGridViewAirlines.Columns[i].Width = 60;
                    dataGridViewAirlines.Columns[i].ReadOnly = true;
                }
                row.Cells[dest++].ReadOnly = false;
                for (; dest < row.Cells.Count; dest++)
                {
                    row.Cells[dest].ReadOnly = true;
                }

                bool found = false;
                foreach (Airline_Group ag in userOverrides.airline_groups)
                {
                    if (String.Equals(ag.name, row.Cells[0].Value))
                    {
                        ag.codes = codes.ToArray();
                        found = true;
                    }
                }
                if (!found)
                {
                    Airline_Group ag = new Airline_Group();
                    ag.name = (string)row.Cells[0].Value;
                    ag.codes = codes.ToArray();
                    userOverrides.airline_groups.Add(ag);
                }

                SaveUserOverrides();
            }
        }

        private void DataGridViewAirlines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewAirlines.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl))
            {
                ((DataGridViewTextBoxEditingControl)dataGridViewAirlines.EditingControl).CharacterCasing = dataGridViewAirlines.CurrentCell.ColumnIndex > 0 ? CharacterCasing.Upper : CharacterCasing.Normal;
                ((DataGridViewTextBoxEditingControl)dataGridViewAirlines.EditingControl).Text = (string)dataGridViewAirlines.CurrentCell.Value;
            }
        }

        private void DataGridViewAircraft_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAircraft.Rows[e.RowIndex];
                if (String.IsNullOrWhiteSpace((string)row.Cells[0].FormattedValue) && String.IsNullOrWhiteSpace((string)row.Cells[1].FormattedValue) && String.IsNullOrWhiteSpace((string)row.Cells[2].FormattedValue) && String.IsNullOrWhiteSpace((string)row.Cells[3].FormattedValue) && String.IsNullOrWhiteSpace((string)row.Cells[4].FormattedValue))
                {
                    dataGridViewAircraft.Rows.Remove(row);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;

                    bool found = false;
                    foreach (Aircraft_Type at in userOverrides.aircraft_types)
                    {
                        if (String.Equals(at.type, row.Cells[0].Value))
                        {
                            at.tags.manufacturer = (string)row.Cells[1].Value;
                            //at.tags.size = row.Cells[2] != null && row.Cells[2].Value != null ? (Int32)row.Cells[2].Value : 0;
                            if (int.TryParse((string)row.Cells[2].FormattedValue, out int size))
                            {
                                at.tags.size = size;
                            }
                            else
                            {
                                row.Cells[2].Value = at.tags.size;
                            }
                            at.tags.engine = (string)row.Cells[3].Value;
                            at.regex = (string)row.Cells[4].Value;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Aircraft_Type at = new Aircraft_Type();
                        at.type = (string)row.Cells[0].Value;
                        at.tags = new Tags();
                        at.tags.manufacturer = (string)row.Cells[1].Value;
                        //at.tags.size = row.Cells[2] != null && row.Cells[2].Value != null ? (Int32)row.Cells[2].Value : 0;
                        if (int.TryParse((string)row.Cells[2].FormattedValue, out int size))
                        {
                            at.tags.size = size;
                        }
                        else
                        {
                            row.Cells[2].Value = at.tags.size = 10;
                        }
                        at.tags.engine = (string)row.Cells[3].Value;
                        at.regex = (string)row.Cells[4].Value;
                        userOverrides.aircraft_types.Add(at);
                    }
                }

                SaveUserOverrides();
            }
        }

        private void checkBoxIncludeIVAO_CheckedChanged(object sender, EventArgs e)
        {
            userOverrides.include_IVAO_models = checkBoxIncludeIVAO.Checked;
            SaveUserOverrides();
        }


        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, SortedDictionary<string, List<string>>> mappings = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
            SortedDictionary<string, List<string>> genericMapping = new SortedDictionary<string, List<string>>();
            List<string[]> airlineGroups = new List<string[]>();

            foreach (DataGridViewRow row in dataGridViewModels.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string model = (string)row.Cells[0].Value;
                string airline = (string)row.Cells[1].Value;
                string type = (string)row.Cells[2].Value;
                bool exclude = (bool)row.Cells[3].Value;

                if (type != null && type.Length >= 2 && type.Length <= 4 && !exclude)
                {
                    SortedDictionary<string, List<string>> typeMappings;
                    if (airline != null && airline.Length > 0)
                    {
                        typeMappings = GetOrCreate(mappings, airline, createNew: () => new SortedDictionary<string, List<string>>());
                    }
                    else
                    {
                        typeMappings = genericMapping;
                    }

                    List<string> models = GetOrCreate(typeMappings, type, createNew: () => new List<string>());

                    models.Add(model);
                }
            }

            foreach (DataGridViewRow row in dataGridViewAirlines.Rows)
            {
                List<string> codes = new List<string>();
                for (int c = 1; c < row.Cells.Count; c++)
                {
                    if (!String.IsNullOrWhiteSpace((string)row.Cells[c].Value))
                    {
                        codes.Add((string)row.Cells[c].Value);
                    }
                }

                airlineGroups.Add(codes.ToArray());
            }


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = false;
            using (XmlWriter writer = XmlWriter.Create("ModelMatchingMagic.vmr", settings))
            {
                writer.WriteStartElement("ModelMatchRuleSet");

                foreach (KeyValuePair<string, SortedDictionary<string, List<string>>> mapping in mappings)
                {
                    WriteMatchRules(mapping.Key, mapping.Value, writer);

                    foreach (string[] group in airlineGroups)
                    {
                        foreach (string code in group)
                        {
                            if (String.Equals(mapping.Key, code))
                            {
                                foreach (string matchedCode in group)
                                {
                                    if (!String.Equals(mapping.Key, matchedCode))
                                    {
                                        WriteMatchRules(matchedCode, mapping.Value, writer);
                                    }
                                }
                            }
                        }
                    }
                }

                WriteMatchRules(null, genericMapping, writer);

                writer.WriteEndElement();
                writer.Flush();
            }

            MessageBox.Show("VMR File generated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteMatchRules(string airline, SortedDictionary<string, List<string>> typeMappings, XmlWriter writer)
        {
            foreach (KeyValuePair<string, List<string>> typeMapping in typeMappings)
            {
                WriteMatchRule(airline, typeMapping.Key, typeMapping.Value, writer);
            }

            foreach (DataGridViewRow row in dataGridViewAircraft.Rows)
            {
                Aircraft_Type at = new Aircraft_Type();
                at.type = (string)row.Cells[0].Value;
                at.tags = new Tags();
                at.tags.manufacturer = (string)row.Cells[1].Value;
                //at.tags.size = row.Cells[2] != null && row.Cells[2].Value != null ? (Int32)row.Cells[2].Value : 0;
                if (int.TryParse((string)row.Cells[2].FormattedValue, out int size))
                {
                    at.tags.size = size;
                }
                else
                {
                    at.tags.size = 10;
                }
                at.tags.engine = (string)row.Cells[3].Value;

                if (!String.IsNullOrWhiteSpace(at.type) && !typeMappings.ContainsKey(at.type))
                {
                    List<string> matchingModels = new List<string>();

                    CheckSimilarAircraft(at, typeMappings, true, true, true, matchingModels);
                    CheckSimilarAircraft(at, typeMappings, false, true, true, matchingModels);
                    CheckSimilarAircraft(at, typeMappings, true, false, true, matchingModels);
                    CheckSimilarAircraft(at, typeMappings, false, false, true, matchingModels);

                    if (matchingModels.Count > 0)
                    {
                        WriteMatchRule(airline, at.type, matchingModels, writer);
                    }
                }
            }
        }

        private void CheckSimilarAircraft(Aircraft_Type aircraftType, SortedDictionary<string, List<string>> typeMappings, bool testManufacturer, bool testSize, bool testEngine, List<string> matchingModels)
        {
            if (matchingModels.Count == 0)
            {
                foreach (Aircraft_Type matchingAircraftType in mmm.aircraft_types)
                {
                    if (aircraftType.type != matchingAircraftType.type &&
                        (String.Equals(aircraftType.tags.manufacturer, matchingAircraftType.tags.manufacturer) == testManufacturer) &&
                        (String.Equals(aircraftType.tags.size, matchingAircraftType.tags.size) == testSize) &&
                        (String.Equals(aircraftType.tags.engine, matchingAircraftType.tags.engine) == testEngine))
                    {
                        if (typeMappings.TryGetValue(matchingAircraftType.type, out List<string> models))
                        {
                            matchingModels.AddRange(models);
                        }
                    }
                }
            }
        }

        private void WriteMatchRule(string airline, string type, List<string> models, XmlWriter writer)
        {
            writer.WriteStartElement("ModelMatchRule");

            if (airline != null)
            {
                writer.WriteAttributeString("CallsignPrefix", airline);
            }

            writer.WriteAttributeString("TypeCode", type);
            writer.WriteAttributeString("ModelName", string.Join("//", models));

            writer.WriteEndElement();
        }
    }
}
