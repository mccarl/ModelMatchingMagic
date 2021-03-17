
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScan = new System.Windows.Forms.Button();
            this.dataGridViewModels = new System.Windows.Forms.DataGridView();
            this.colModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAirline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageModels = new System.Windows.Forms.TabPage();
            this.tabPageAirlines = new System.Windows.Forms.TabPage();
            this.dataGridViewAirlines = new System.Windows.Forms.DataGridView();
            this.colAirlineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodes5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAircraft = new System.Windows.Forms.TabPage();
            this.dataGridViewAircraft = new System.Windows.Forms.DataGridView();
            this.colAircraftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEngine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModels)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageModels.SuspendLayout();
            this.tabPageAirlines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirlines)).BeginInit();
            this.tabPageAircraft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAircraft)).BeginInit();
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
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
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
            this.dataGridViewModels.Size = new System.Drawing.Size(765, 322);
            this.dataGridViewModels.TabIndex = 3;
            this.dataGridViewModels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModels_CellContentClick);
            this.dataGridViewModels.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModels_CellValueChanged);
            this.dataGridViewModels.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewModels_EditingControlShowing);
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
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonGenerate.Location = new System.Drawing.Point(325, 406);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(149, 32);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "&Generate VMR File";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
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
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageModels);
            this.tabControl1.Controls.Add(this.tabPageAirlines);
            this.tabControl1.Controls.Add(this.tabPageAircraft);
            this.tabControl1.Location = new System.Drawing.Point(15, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 348);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageModels
            // 
            this.tabPageModels.Controls.Add(this.dataGridViewModels);
            this.tabPageModels.Location = new System.Drawing.Point(4, 22);
            this.tabPageModels.Name = "tabPageModels";
            this.tabPageModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModels.Size = new System.Drawing.Size(765, 322);
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
            this.tabPageAirlines.Size = new System.Drawing.Size(765, 322);
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
            this.colCodes1,
            this.colCodes2,
            this.colCodes3,
            this.colCodes4,
            this.colCodes5});
            this.dataGridViewAirlines.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAirlines.Name = "dataGridViewAirlines";
            this.dataGridViewAirlines.Size = new System.Drawing.Size(765, 322);
            this.dataGridViewAirlines.TabIndex = 0;
            this.dataGridViewAirlines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAirlines_CellValueChanged);
            this.dataGridViewAirlines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewAirlines_EditingControlShowing);
            // 
            // colAirlineName
            // 
            this.colAirlineName.HeaderText = "Airline Name";
            this.colAirlineName.Name = "colAirlineName";
            this.colAirlineName.Width = 150;
            // 
            // colCodes1
            // 
            this.colCodes1.HeaderText = "ICAO Codes";
            this.colCodes1.Name = "colCodes1";
            this.colCodes1.Width = 90;
            // 
            // colCodes2
            // 
            this.colCodes2.HeaderText = "";
            this.colCodes2.Name = "colCodes2";
            this.colCodes2.Width = 60;
            // 
            // colCodes3
            // 
            this.colCodes3.HeaderText = "";
            this.colCodes3.Name = "colCodes3";
            this.colCodes3.Width = 60;
            // 
            // colCodes4
            // 
            this.colCodes4.HeaderText = "";
            this.colCodes4.Name = "colCodes4";
            this.colCodes4.Width = 60;
            // 
            // colCodes5
            // 
            this.colCodes5.HeaderText = "";
            this.colCodes5.Name = "colCodes5";
            this.colCodes5.Width = 60;
            // 
            // tabPageAircraft
            // 
            this.tabPageAircraft.Controls.Add(this.dataGridViewAircraft);
            this.tabPageAircraft.Location = new System.Drawing.Point(4, 22);
            this.tabPageAircraft.Name = "tabPageAircraft";
            this.tabPageAircraft.Size = new System.Drawing.Size(765, 322);
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
            this.colEngine});
            this.dataGridViewAircraft.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAircraft.Name = "dataGridViewAircraft";
            this.dataGridViewAircraft.Size = new System.Drawing.Size(762, 319);
            this.dataGridViewAircraft.TabIndex = 0;
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
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            // 
            // colEngine
            // 
            this.colEngine.HeaderText = "Engine Type";
            this.colEngine.Name = "colEngine";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPath);
            this.Name = "FormMain";
            this.Text = "ModelMatchingMagic";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModels)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageModels.ResumeLayout(false);
            this.tabPageAirlines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirlines)).EndInit();
            this.tabPageAircraft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAircraft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.DataGridView dataGridViewModels;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAirline;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExclude;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageModels;
        private System.Windows.Forms.TabPage tabPageAirlines;
        private System.Windows.Forms.DataGridView dataGridViewAirlines;
        private System.Windows.Forms.TabPage tabPageAircraft;
        private System.Windows.Forms.DataGridView dataGridViewAircraft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAircraftType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEngine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAirlineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodes5;
    }
}

