using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace ModelMatchingMagic
{
    public partial class FormMain : Form
    {
        ModelMatchingMagic mmm;
        ModelMatchingMagic userOverrides = new ModelMatchingMagic();

        Regex regexAirbus = new Regex(@"A([23])([0123458])([0189])(?:-([0-9]))?");
        Regex regexBoeing = new Regex(@"7([0-8])7(?:-([0-9]))?");
        Regex regexBoeingMax = new Regex(@"737.*MAX[ -]([0-9]{0,2})", RegexOptions.IgnoreCase);
        Regex regexCessna = new Regex(@"([0-9]{3})");
        Regex regexDiamond = new Regex(@"(DA[46][02])");


        public FormMain()
        {
            InitializeComponent();

            using(WebClient wc = new WebClient())
            {
                string mmmJson = wc.DownloadString("https://raw.githubusercontent.com/mccarl/ModelMatchingMagic/master/ModelMatchingMagic.json");
                mmm = JsonConvert.DeserializeObject<ModelMatchingMagic>(mmmJson);
            }


            foreach (Airline_Group g in mmm.airline_groups)
            {
                int i = dataGridViewAirlines.Rows.Add(g.name);
                int c = 1;
                foreach (string code in g.codes)
                {
                    dataGridViewAirlines.Rows[i].Cells[c++].Value = code;
                }
                for (c++; c < dataGridViewAirlines.Columns.Count; c++)
                {
                    dataGridViewAirlines.Rows[i].Cells[c++].ReadOnly = true;
                }
                dataGridViewAirlines.Rows[i].Cells[0].ReadOnly = (i != dataGridViewAirlines.NewRowIndex);
            }

            foreach (Aircraft_Type t in mmm.aircraft_types)
            {
                int i = dataGridViewAircraft.Rows.Add(t.type, t.tags.manufacturer, t.tags.size, t.tags.engine);
                dataGridViewAircraft.Rows[i].Cells[0].ReadOnly = (i != dataGridViewAircraft.NewRowIndex);
            }

            try
            {
                using (StreamReader r = new StreamReader("ModelMatchingMagic.json"))
                {
                    string userOverridesJson = r.ReadToEnd();
                    userOverrides = JsonConvert.DeserializeObject<ModelMatchingMagic>(userOverridesJson);
                }
            } catch (FileNotFoundException) { }
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            var dlg = new FolderPicker();
            dlg.InputPath = textBoxPath.Text.Replace("%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            if (dlg.ShowDialog(IntPtr.Zero))
            {
                textBoxPath.Text = dlg.ResultPath;
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            dataGridViewModels.Rows.Clear();

            findAircraftCfgs(textBoxPath.Text.Replace("%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));

            for (int i = 0; i < dataGridViewModels.Rows.Count; i++)
            {
                dataGridViewModels.Rows[i].Cells[0].ReadOnly = (i != dataGridViewModels.NewRowIndex);
            }
        }

        private void findAircraftCfgs(string path)
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
                            content.Add(line.Substring(1, line.Length - 2), section);
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
                            }





                            if (!ivao)
                            {
                                bool exclude = false;

                                bool mmmOverrideFound = false;
                                foreach (Model_Override mo in mmm.model_overrides)
                                {
                                    if (String.Equals(title, mo.model))
                                    {
                                        //if (mo.airline != null)
                                        //{
                                        //    airline = mo.airline;
                                        //    mmmOverrideFound = true;
                                        //}
                                        //if (mo.type != null)
                                        //{
                                        //    type = mo.type;
                                        //    mmmOverrideFound = true;
                                        //}
                                        //if (mo.exclude != null)
                                        //{
                                        //    exclude = (bool)mo.exclude;
                                        //    mmmOverrideFound = true;
                                        //}
                                        airline = mo.airline;
                                        type = mo.type;
                                        exclude = mo.exclude!= null && (bool)mo.exclude;
                                        mmmOverrideFound = true;
                                    }
                                }

                                bool userOverrideFound = false;
                                foreach (Model_Override mo in userOverrides.model_overrides)
                                {
                                    if (String.Equals(title, mo.model))
                                    {
                                        //if (mo.airline != null)
                                        //{
                                        //    airline = mo.airline;
                                        //    userOverrideFound = true;
                                        //}
                                        //if (mo.type != null)
                                        //{
                                        //    type = mo.type;
                                        //    userOverrideFound = true;
                                        //}
                                        //if (mo.exclude != null)
                                        //{
                                        //    exclude = (bool)mo.exclude;
                                        //    userOverrideFound = true;
                                        //}
                                        airline = mo.airline;
                                        type = mo.type;
                                        exclude = (bool)mo.exclude;
                                        userOverrideFound = true;
                                    }
                                }

                                if (String.IsNullOrWhiteSpace(type))
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
                findAircraftCfgs(d);
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

        private void dataGridViewModels_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                            //if (e.ColumnIndex == 1)
                            //{
                            //    mo.airline = (string)row.Cells[1].Value;
                            //}
                            //else if (e.ColumnIndex == 2)
                            //{
                            //    mo.type = (string)row.Cells[2].Value;
                            //}
                            //else if (e.ColumnIndex == 3)
                            //{
                            //    mo.exclude = (bool)row.Cells[3].Value;
                            //}
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
                        //if (e.ColumnIndex == 1)
                        //{
                        //    mo.airline = (string)row.Cells[1].Value;
                        //}
                        //else if (e.ColumnIndex == 2)
                        //{
                        //    mo.type = (string)row.Cells[2].Value;
                        //}
                        //else if (e.ColumnIndex == 3)
                        //{
                        //    mo.exclude = (bool)row.Cells[3].Value;
                        //}
                        mo.airline = (string)row.Cells[1].Value;
                        mo.type = (string)row.Cells[2].Value;
                        mo.exclude = (bool)row.Cells[3].Value;
                        userOverrides.model_overrides.Add(mo);
                    }
                }

                string json = JsonConvert.SerializeObject(userOverrides, Newtonsoft.Json.Formatting.Indented);
                //Console.WriteLine(json);
                using (StreamWriter w = new StreamWriter("ModelMatchingMagic.json"))
                {
                    w.WriteLine(json);
                }
            }
        }

        private void dataGridViewModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dataGridViewModels_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewModels.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl))
            {
                ((DataGridViewTextBoxEditingControl)dataGridViewModels.EditingControl).CharacterCasing = CharacterCasing.Upper;
            }
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, SortedDictionary<string, List<string>>> mappings = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
            SortedDictionary<string, List<string>> genericMapping = new SortedDictionary<string, List<string>>();

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

                if (type != null && type.Length == 4 && !exclude)
                {
                    SortedDictionary<string, List<string>> typeMappings;
                    if (airline != null && airline.Length == 3)
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

                    foreach (Airline_Group group in mmm.airline_groups)
                    {
                        foreach (string code in group.codes)
                        {
                            if (String.Equals(mapping.Key, code))
                            {
                                foreach (string matchedCode in group.codes)
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

            foreach (Aircraft_Type aircraftType in mmm.aircraft_types)
            {
                if (!typeMappings.ContainsKey(aircraftType.type))
                {
                    List<string> matchingModels = new List<string>();

                    CheckSimilarAircraft(aircraftType, typeMappings, true, true, true, matchingModels);
                    CheckSimilarAircraft(aircraftType, typeMappings, false, true, true, matchingModels);
                    CheckSimilarAircraft(aircraftType, typeMappings, true, false, true, matchingModels);
                    CheckSimilarAircraft(aircraftType, typeMappings, false, false, true, matchingModels);
                    //CheckSimilarAircraft(aircraftType, typeMappings, true, true, true, matchingModels);
                    //CheckSimilarAircraft(aircraftType, typeMappings, true, true, true, matchingModels);

                    if (matchingModels.Count > 0)
                    {
                        WriteMatchRule(airline, aircraftType.type, matchingModels, writer);
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
