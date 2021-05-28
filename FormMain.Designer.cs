
namespace ModelMatchingMagic
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScan = new System.Windows.Forms.Button();
            this.dataGridViewModels = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageModels = new System.Windows.Forms.TabPage();
            this.tabPageAirlines = new System.Windows.Forms.TabPage();
            this.dataGridViewAirlines = new System.Windows.Forms.DataGridView();
            this.colAirlineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAircraft = new System.Windows.Forms.TabPage();
            this.dataGridViewAircraft = new System.Windows.Forms.DataGridView();
            this.colAircraftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEngine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelVersion = new System.Windows.Forms.Label();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.checkBoxIncludeIVAO = new System.Windows.Forms.CheckBox();
            this.colModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAirline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModels)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageModels.SuspendLayout();
            this.tabPageAirlines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirlines)).BeginInit();
            this.tabPageAircraft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAircraft)).BeginInit();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(15, 25);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(639, 21);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Text = "%LOCALAPPDATA%\\Packages\\Microsoft.FlightSimulator_8wekyb3d8bbwe\\LocalCache\\Packag" +
    "es\\Community";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Community Folder Path";
            // 
            // buttonScan
            // 
            this.buttonScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonScan.Location = new System.Drawing.Point(713, 24);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 2;
            this.buttonScan.Text = "&Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.ButtonScan_Click);
            // 
            // dataGridViewModels
            // 
            this.dataGridViewModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModelName,
            this.colAirline,
            this.colType,
            this.colExclude});
            this.dataGridViewModels.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewModels.Name = "dataGridViewModels";
            this.dataGridViewModels.RowTemplate.Height = 18;
            this.dataGridViewModels.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewModels.Size = new System.Drawing.Size(765, 325);
            this.dataGridViewModels.TabIndex = 3;
            this.dataGridViewModels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewModels_CellContentClick);
            this.dataGridViewModels.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewModels_CellValueChanged);
            this.dataGridViewModels.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewModels_EditingControlShowing);
            this.dataGridViewModels.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewModels_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClear});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(150, 26);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_ItemClicked);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemClear.Text = "Clear Override";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonGenerate.Location = new System.Drawing.Point(325, 410);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(149, 32);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "&Generate VMR File";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(660, 24);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(32, 23);
            this.buttonSelectFolder.TabIndex = 5;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageModels);
            this.tabControl1.Controls.Add(this.tabPageAirlines);
            this.tabControl1.Controls.Add(this.tabPageAircraft);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Location = new System.Drawing.Point(15, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 351);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageModels
            // 
            this.tabPageModels.Controls.Add(this.dataGridViewModels);
            this.tabPageModels.Location = new System.Drawing.Point(4, 22);
            this.tabPageModels.Name = "tabPageModels";
            this.tabPageModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModels.Size = new System.Drawing.Size(765, 325);
            this.tabPageModels.TabIndex = 0;
            this.tabPageModels.Text = "Models";
            this.tabPageModels.UseVisualStyleBackColor = true;
            // 
            // tabPageAirlines
            // 
            this.tabPageAirlines.Controls.Add(this.dataGridViewAirlines);
            this.tabPageAirlines.Location = new System.Drawing.Point(4, 22);
            this.tabPageAirlines.Name = "tabPageAirlines";
            this.tabPageAirlines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAirlines.Size = new System.Drawing.Size(765, 325);
            this.tabPageAirlines.TabIndex = 1;
            this.tabPageAirlines.Text = "Airline Codes";
            this.tabPageAirlines.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAirlines
            // 
            this.dataGridViewAirlines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAirlines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAirlines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAirlineName,
            this.colCodes});
            this.dataGridViewAirlines.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAirlines.Name = "dataGridViewAirlines";
            this.dataGridViewAirlines.Size = new System.Drawing.Size(765, 325);
            this.dataGridViewAirlines.TabIndex = 0;
            this.dataGridViewAirlines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAirlines_CellValueChanged);
            this.dataGridViewAirlines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewAirlines_EditingControlShowing);
            // 
            // colAirlineName
            // 
            this.colAirlineName.HeaderText = "Airline Name";
            this.colAirlineName.Name = "colAirlineName";
            this.colAirlineName.Width = 150;
            // 
            // colCodes
            // 
            this.colCodes.HeaderText = "ICAO Codes";
            this.colCodes.Name = "colCodes";
            this.colCodes.Width = 90;
            // 
            // tabPageAircraft
            // 
            this.tabPageAircraft.Controls.Add(this.dataGridViewAircraft);
            this.tabPageAircraft.Location = new System.Drawing.Point(4, 22);
            this.tabPageAircraft.Name = "tabPageAircraft";
            this.tabPageAircraft.Size = new System.Drawing.Size(765, 325);
            this.tabPageAircraft.TabIndex = 2;
            this.tabPageAircraft.Text = "Aircraft Types";
            this.tabPageAircraft.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAircraft
            // 
            this.dataGridViewAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAircraft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAircraftType,
            this.colManufacturer,
            this.colSize,
            this.colEngine,
            this.colRegex});
            this.dataGridViewAircraft.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAircraft.Name = "dataGridViewAircraft";
            this.dataGridViewAircraft.Size = new System.Drawing.Size(762, 322);
            this.dataGridViewAircraft.TabIndex = 0;
            this.dataGridViewAircraft.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAircraft_CellValueChanged);
            // 
            // colAircraftType
            // 
            this.colAircraftType.HeaderText = "Aircraft Type";
            this.colAircraftType.Name = "colAircraftType";
            this.colAircraftType.Width = 150;
            // 
            // colManufacturer
            // 
            this.colManufacturer.HeaderText = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            // 
            // colSize
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colSize.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Width = 60;
            // 
            // colEngine
            // 
            this.colEngine.HeaderText = "Engine Type";
            this.colEngine.Name = "colEngine";
            // 
            // colRegex
            // 
            this.colRegex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRegex.HeaderText = "Match Rule (Regex)";
            this.colRegex.Name = "colRegex";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(751, 432);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(37, 13);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "v1.0.1";
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOptions.Controls.Add(this.checkBoxIncludeIVAO);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(765, 325);
            this.tabPageOptions.TabIndex = 3;
            this.tabPageOptions.Text = "Options";
            // 
            // checkBoxIncludeIVAO
            // 
            this.checkBoxIncludeIVAO.AutoSize = true;
            this.checkBoxIncludeIVAO.Location = new System.Drawing.Point(28, 28);
            this.checkBoxIncludeIVAO.Name = "checkBoxIncludeIVAO";
            this.checkBoxIncludeIVAO.Size = new System.Drawing.Size(126, 17);
            this.checkBoxIncludeIVAO.TabIndex = 0;
            this.checkBoxIncludeIVAO.Text = "Include IVAO Models";
            this.checkBoxIncludeIVAO.UseVisualStyleBackColor = true;
            this.checkBoxIncludeIVAO.CheckedChanged += new System.EventHandler(this.checkBoxIncludeIVAO_CheckedChanged);
            // 
            // colModelName
            // 
            this.colModelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelName.HeaderText = "Model Name";
            this.colModelName.Name = "colModelName";
            // 
            // colAirline
            // 
            this.colAirline.HeaderText = "Airline ICAO";
            this.colAirline.Name = "colAirline";
            // 
            // colType
            // 
            this.colType.HeaderText = "Aircraft Type";
            this.colType.Name = "colType";
            // 
            // colExclude
            // 
            this.colExclude.HeaderText = "Exclude";
            this.colExclude.Name = "colExclude";
            this.colExclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPath);
            this.Name = "FormMain";
            this.Text = "ModelMatchingMagic";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModels)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageModels.ResumeLayout(false);
            this.tabPageAirlines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirlines)).EndInit();
            this.tabPageAircraft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAircraft)).EndInit();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.DataGridView dataGridViewModels;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageModels;
        private System.Windows.Forms.TabPage tabPageAirlines;
        private System.Windows.Forms.DataGridView dataGridViewAirlines;
        private System.Windows.Forms.TabPage tabPageAircraft;
        private System.Windows.Forms.DataGridView dataGridViewAircraft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAirlineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAircraftType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEngine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegex;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.CheckBox checkBoxIncludeIVAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAirline;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExclude;
    }
}

