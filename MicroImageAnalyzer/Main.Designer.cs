namespace MicroImageAnalyzer
{
	partial class Main
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuProjectSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuProjectExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolEditSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.tab = new System.Windows.Forms.TabControl();
            this.AnalyzeArea = new System.Windows.Forms.TabPage();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.groupAnalyzeAreaSets = new System.Windows.Forms.GroupBox();
            this.buttonRemoveAnalyzeAreaSet = new System.Windows.Forms.Button();
            this.buttonEditAnalyzeAreaSet = new System.Windows.Forms.Button();
            this.buttonAddAnalyzeAreaSet = new System.Windows.Forms.Button();
            this.dataAnalyzeAreaSets = new System.Windows.Forms.DataGridView();
            this.checkDrawArea = new System.Windows.Forms.CheckBox();
            this.checkBinarize = new System.Windows.Forms.CheckBox();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.buttonAnalyzer = new System.Windows.Forms.Button();
            this.Slice = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataSliceAreaSets = new System.Windows.Forms.DataGridView();
            this.radioButtonPic561 = new System.Windows.Forms.RadioButton();
            this.radioButtonPic473 = new System.Windows.Forms.RadioButton();
            this.groupChartArea = new System.Windows.Forms.GroupBox();
            this.buttonExportAsCSV = new System.Windows.Forms.Button();
            this.chartSpot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.status = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.nudT = new System.Windows.Forms.NumericUpDown();
            this.labelT = new System.Windows.Forms.Label();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.labelZ = new System.Windows.Forms.Label();
            this.scrollT = new System.Windows.Forms.HScrollBar();
            this.scrollZ = new System.Windows.Forms.VScrollBar();
            this.pictureMicroImage = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            this.panel.SuspendLayout();
            this.tab.SuspendLayout();
            this.AnalyzeArea.SuspendLayout();
            this.groupAnalyzeAreaSets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnalyzeAreaSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            this.Slice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSliceAreaSets)).BeginInit();
            this.groupChartArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpot)).BeginInit();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMicroImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProject,
            this.menuTool});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1043, 26);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // menuProject
            // 
            this.menuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProjectNew,
            this.menuProjectOpen,
            this.toolStripSeparator1,
            this.menuProjectSave,
            this.menuProjectSaveAs,
            this.toolStripSeparator2,
            this.menuProjectExit});
            this.menuProject.Name = "menuProject";
            this.menuProject.Size = new System.Drawing.Size(109, 22);
            this.menuProject.Text = "プロジェクト(&P)";
            // 
            // menuProjectNew
            // 
            this.menuProjectNew.Name = "menuProjectNew";
            this.menuProjectNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuProjectNew.Size = new System.Drawing.Size(202, 22);
            this.menuProjectNew.Text = "新規作成(&N)...";
            this.menuProjectNew.Click += new System.EventHandler(this.menuProjectNew_Click);
            // 
            // menuProjectOpen
            // 
            this.menuProjectOpen.Name = "menuProjectOpen";
            this.menuProjectOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuProjectOpen.Size = new System.Drawing.Size(202, 22);
            this.menuProjectOpen.Text = "開く(&O)...";
            this.menuProjectOpen.Click += new System.EventHandler(this.menuProjectOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // menuProjectSave
            // 
            this.menuProjectSave.Enabled = false;
            this.menuProjectSave.Name = "menuProjectSave";
            this.menuProjectSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuProjectSave.Size = new System.Drawing.Size(202, 22);
            this.menuProjectSave.Text = "上書き保存(&S)";
            this.menuProjectSave.Click += new System.EventHandler(this.menuProjectSave_Click);
            // 
            // menuProjectSaveAs
            // 
            this.menuProjectSaveAs.Enabled = false;
            this.menuProjectSaveAs.Name = "menuProjectSaveAs";
            this.menuProjectSaveAs.Size = new System.Drawing.Size(202, 22);
            this.menuProjectSaveAs.Text = "名前を付けて保存(&A)...";
            this.menuProjectSaveAs.Click += new System.EventHandler(this.menuProjectSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // menuProjectExit
            // 
            this.menuProjectExit.Name = "menuProjectExit";
            this.menuProjectExit.Size = new System.Drawing.Size(202, 22);
            this.menuProjectExit.Text = "終了(&X)";
            this.menuProjectExit.Click += new System.EventHandler(this.menuProjectExit_Click);
            // 
            // menuTool
            // 
            this.menuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolEditSettings});
            this.menuTool.Enabled = false;
            this.menuTool.Name = "menuTool";
            this.menuTool.Size = new System.Drawing.Size(74, 22);
            this.menuTool.Text = "ツール(&T)";
            // 
            // menuToolEditSettings
            // 
            this.menuToolEditSettings.Name = "menuToolEditSettings";
            this.menuToolEditSettings.Size = new System.Drawing.Size(202, 22);
            this.menuToolEditSettings.Text = "プロジェクト設定(&C)...";
            this.menuToolEditSettings.Click += new System.EventHandler(this.menuToolEditSettings_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tab);
            this.panel.Controls.Add(this.radioButtonPic561);
            this.panel.Controls.Add(this.radioButtonPic473);
            this.panel.Controls.Add(this.groupChartArea);
            this.panel.Controls.Add(this.status);
            this.panel.Controls.Add(this.nudT);
            this.panel.Controls.Add(this.labelT);
            this.panel.Controls.Add(this.nudZ);
            this.panel.Controls.Add(this.labelZ);
            this.panel.Controls.Add(this.scrollT);
            this.panel.Controls.Add(this.scrollZ);
            this.panel.Controls.Add(this.pictureMicroImage);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Enabled = false;
            this.panel.Location = new System.Drawing.Point(0, 26);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1043, 741);
            this.panel.TabIndex = 1;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.AnalyzeArea);
            this.tab.Controls.Add(this.Slice);
            this.tab.Location = new System.Drawing.Point(395, 14);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(636, 309);
            this.tab.TabIndex = 32;
            this.tab.Tag = "";
            // 
            // AnalyzeArea
            // 
            this.AnalyzeArea.BackColor = System.Drawing.SystemColors.Control;
            this.AnalyzeArea.Controls.Add(this.labelThreshold);
            this.AnalyzeArea.Controls.Add(this.groupAnalyzeAreaSets);
            this.AnalyzeArea.Controls.Add(this.nudThreshold);
            this.AnalyzeArea.Controls.Add(this.buttonAnalyzer);
            this.AnalyzeArea.Location = new System.Drawing.Point(4, 22);
            this.AnalyzeArea.Name = "AnalyzeArea";
            this.AnalyzeArea.Padding = new System.Windows.Forms.Padding(3);
            this.AnalyzeArea.Size = new System.Drawing.Size(628, 283);
            this.AnalyzeArea.TabIndex = 0;
            this.AnalyzeArea.Text = "AnalyzeArea";
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(15, 260);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(31, 12);
            this.labelThreshold.TabIndex = 21;
            this.labelThreshold.Text = "閾値:";
            // 
            // groupAnalyzeAreaSets
            // 
            this.groupAnalyzeAreaSets.Controls.Add(this.buttonRemoveAnalyzeAreaSet);
            this.groupAnalyzeAreaSets.Controls.Add(this.buttonEditAnalyzeAreaSet);
            this.groupAnalyzeAreaSets.Controls.Add(this.buttonAddAnalyzeAreaSet);
            this.groupAnalyzeAreaSets.Controls.Add(this.dataAnalyzeAreaSets);
            this.groupAnalyzeAreaSets.Controls.Add(this.checkDrawArea);
            this.groupAnalyzeAreaSets.Controls.Add(this.checkBinarize);
            this.groupAnalyzeAreaSets.Location = new System.Drawing.Point(11, 7);
            this.groupAnalyzeAreaSets.Name = "groupAnalyzeAreaSets";
            this.groupAnalyzeAreaSets.Size = new System.Drawing.Size(611, 242);
            this.groupAnalyzeAreaSets.TabIndex = 20;
            this.groupAnalyzeAreaSets.TabStop = false;
            this.groupAnalyzeAreaSets.Text = "解析エリア";
            // 
            // buttonRemoveAnalyzeAreaSet
            // 
            this.buttonRemoveAnalyzeAreaSet.Location = new System.Drawing.Point(227, 210);
            this.buttonRemoveAnalyzeAreaSet.Name = "buttonRemoveAnalyzeAreaSet";
            this.buttonRemoveAnalyzeAreaSet.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveAnalyzeAreaSet.TabIndex = 3;
            this.buttonRemoveAnalyzeAreaSet.Text = "削除";
            this.buttonRemoveAnalyzeAreaSet.UseVisualStyleBackColor = true;
            this.buttonRemoveAnalyzeAreaSet.Click += new System.EventHandler(this.buttonRemoveAnalyzeAreaSet_Click);
            // 
            // buttonEditAnalyzeAreaSet
            // 
            this.buttonEditAnalyzeAreaSet.Location = new System.Drawing.Point(121, 210);
            this.buttonEditAnalyzeAreaSet.Name = "buttonEditAnalyzeAreaSet";
            this.buttonEditAnalyzeAreaSet.Size = new System.Drawing.Size(100, 23);
            this.buttonEditAnalyzeAreaSet.TabIndex = 2;
            this.buttonEditAnalyzeAreaSet.Text = "編集...";
            this.buttonEditAnalyzeAreaSet.UseVisualStyleBackColor = true;
            this.buttonEditAnalyzeAreaSet.Click += new System.EventHandler(this.buttonEditAnalyzeAreaSet_Click);
            // 
            // buttonAddAnalyzeAreaSet
            // 
            this.buttonAddAnalyzeAreaSet.Location = new System.Drawing.Point(15, 210);
            this.buttonAddAnalyzeAreaSet.Name = "buttonAddAnalyzeAreaSet";
            this.buttonAddAnalyzeAreaSet.Size = new System.Drawing.Size(100, 23);
            this.buttonAddAnalyzeAreaSet.TabIndex = 1;
            this.buttonAddAnalyzeAreaSet.Text = "追加...";
            this.buttonAddAnalyzeAreaSet.UseVisualStyleBackColor = true;
            this.buttonAddAnalyzeAreaSet.Click += new System.EventHandler(this.buttonAddAnalyzeAreaSet_Click);
            // 
            // dataAnalyzeAreaSets
            // 
            this.dataAnalyzeAreaSets.AllowUserToAddRows = false;
            this.dataAnalyzeAreaSets.AllowUserToDeleteRows = false;
            this.dataAnalyzeAreaSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAnalyzeAreaSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataAnalyzeAreaSets.Location = new System.Drawing.Point(15, 23);
            this.dataAnalyzeAreaSets.MultiSelect = false;
            this.dataAnalyzeAreaSets.Name = "dataAnalyzeAreaSets";
            this.dataAnalyzeAreaSets.ReadOnly = true;
            this.dataAnalyzeAreaSets.RowTemplate.Height = 21;
            this.dataAnalyzeAreaSets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAnalyzeAreaSets.Size = new System.Drawing.Size(581, 183);
            this.dataAnalyzeAreaSets.TabIndex = 0;
            // 
            // checkDrawArea
            // 
            this.checkDrawArea.AutoSize = true;
            this.checkDrawArea.Enabled = false;
            this.checkDrawArea.Location = new System.Drawing.Point(408, 214);
            this.checkDrawArea.Name = "checkDrawArea";
            this.checkDrawArea.Size = new System.Drawing.Size(128, 16);
            this.checkDrawArea.TabIndex = 14;
            this.checkDrawArea.Text = "選択中のエリアを表示";
            this.checkDrawArea.UseVisualStyleBackColor = true;
            this.checkDrawArea.CheckedChanged += new System.EventHandler(this.checkDrawArea_CheckedChanged);
            // 
            // checkBinarize
            // 
            this.checkBinarize.AutoSize = true;
            this.checkBinarize.Location = new System.Drawing.Point(542, 214);
            this.checkBinarize.Name = "checkBinarize";
            this.checkBinarize.Size = new System.Drawing.Size(54, 16);
            this.checkBinarize.TabIndex = 9;
            this.checkBinarize.Text = "2値化";
            this.checkBinarize.UseVisualStyleBackColor = true;
            this.checkBinarize.CheckedChanged += new System.EventHandler(this.checkBinarize_CheckedChanged);
            // 
            // nudThreshold
            // 
            this.nudThreshold.Enabled = false;
            this.nudThreshold.Location = new System.Drawing.Point(49, 258);
            this.nudThreshold.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(55, 19);
            this.nudThreshold.TabIndex = 22;
            this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
            // 
            // buttonAnalyzer
            // 
            this.buttonAnalyzer.Location = new System.Drawing.Point(110, 255);
            this.buttonAnalyzer.Name = "buttonAnalyzer";
            this.buttonAnalyzer.Size = new System.Drawing.Size(100, 23);
            this.buttonAnalyzer.TabIndex = 19;
            this.buttonAnalyzer.Text = "解析";
            this.buttonAnalyzer.UseVisualStyleBackColor = true;
            this.buttonAnalyzer.Click += new System.EventHandler(this.buttonAnalyzer_Click);
            // 
            // Slice
            // 
            this.Slice.BackColor = System.Drawing.SystemColors.Control;
            this.Slice.Controls.Add(this.groupBox1);
            this.Slice.Location = new System.Drawing.Point(4, 22);
            this.Slice.Name = "Slice";
            this.Slice.Padding = new System.Windows.Forms.Padding(3);
            this.Slice.Size = new System.Drawing.Size(628, 283);
            this.Slice.TabIndex = 1;
            this.Slice.Text = "Slice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataSliceAreaSets);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 262);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slice選択エリア";
            // 
            // dataSliceAreaSets
            // 
            this.dataSliceAreaSets.AllowUserToAddRows = false;
            this.dataSliceAreaSets.AllowUserToDeleteRows = false;
            this.dataSliceAreaSets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataSliceAreaSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSliceAreaSets.Location = new System.Drawing.Point(15, 23);
            this.dataSliceAreaSets.MultiSelect = false;
            this.dataSliceAreaSets.Name = "dataSliceAreaSets";
            this.dataSliceAreaSets.ReadOnly = true;
            this.dataSliceAreaSets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataSliceAreaSets.RowTemplate.Height = 21;
            this.dataSliceAreaSets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataSliceAreaSets.Size = new System.Drawing.Size(577, 230);
            this.dataSliceAreaSets.TabIndex = 28;
            // 
            // radioButtonPic561
            // 
            this.radioButtonPic561.AutoSize = true;
            this.radioButtonPic561.Location = new System.Drawing.Point(274, 18);
            this.radioButtonPic561.Name = "radioButtonPic561";
            this.radioButtonPic561.Size = new System.Drawing.Size(41, 16);
            this.radioButtonPic561.TabIndex = 31;
            this.radioButtonPic561.Text = "561";
            this.radioButtonPic561.UseVisualStyleBackColor = true;
            this.radioButtonPic561.CheckedChanged += new System.EventHandler(this.radioButtonPic561_CheckedChanged);
            // 
            // radioButtonPic473
            // 
            this.radioButtonPic473.AutoSize = true;
            this.radioButtonPic473.Checked = true;
            this.radioButtonPic473.Location = new System.Drawing.Point(227, 18);
            this.radioButtonPic473.Name = "radioButtonPic473";
            this.radioButtonPic473.Size = new System.Drawing.Size(41, 16);
            this.radioButtonPic473.TabIndex = 30;
            this.radioButtonPic473.TabStop = true;
            this.radioButtonPic473.Text = "473";
            this.radioButtonPic473.UseVisualStyleBackColor = true;
            this.radioButtonPic473.CheckedChanged += new System.EventHandler(this.radioButtonPic473_CheckedChanged);
            // 
            // groupChartArea
            // 
            this.groupChartArea.Controls.Add(this.buttonExportAsCSV);
            this.groupChartArea.Controls.Add(this.chartSpot);
            this.groupChartArea.Location = new System.Drawing.Point(14, 343);
            this.groupChartArea.Name = "groupChartArea";
            this.groupChartArea.Size = new System.Drawing.Size(861, 357);
            this.groupChartArea.TabIndex = 26;
            this.groupChartArea.TabStop = false;
            this.groupChartArea.Text = "グラフ";
            // 
            // buttonExportAsCSV
            // 
            this.buttonExportAsCSV.Location = new System.Drawing.Point(755, 18);
            this.buttonExportAsCSV.Name = "buttonExportAsCSV";
            this.buttonExportAsCSV.Size = new System.Drawing.Size(100, 23);
            this.buttonExportAsCSV.TabIndex = 4;
            this.buttonExportAsCSV.Text = "CSV出力...";
            this.buttonExportAsCSV.UseVisualStyleBackColor = true;
            this.buttonExportAsCSV.Click += new System.EventHandler(this.buttonExportAsCSV_Click);
            // 
            // chartSpot
            // 
            this.chartSpot.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chartSpot.BorderlineColor = System.Drawing.Color.Black;
            this.chartSpot.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartSpot.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSpot.Legends.Add(legend4);
            this.chartSpot.Location = new System.Drawing.Point(6, 47);
            this.chartSpot.Name = "chartSpot";
            this.chartSpot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series10.LabelBorderWidth = 0;
            series10.LabelForeColor = System.Drawing.Color.Empty;
            series10.Legend = "Legend1";
            series10.LegendText = "473Count";
            series10.Name = "473Count";
            series10.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Empty;
            series10.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series10.SmartLabelStyle.CalloutLineWidth = 0;
            series10.SmartLabelStyle.Enabled = false;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series11.LabelBorderWidth = 0;
            series11.LabelForeColor = System.Drawing.Color.Empty;
            series11.Legend = "Legend1";
            series11.LegendText = "561Count";
            series11.Name = "561Count";
            series11.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Empty;
            series11.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series11.SmartLabelStyle.CalloutLineWidth = 0;
            series11.SmartLabelStyle.Enabled = false;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series12.LabelBorderWidth = 0;
            series12.LabelForeColor = System.Drawing.Color.Empty;
            series12.Legend = "Legend1";
            series12.LegendText = "IntDen";
            series12.Name = "IntDen";
            series12.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Empty;
            series12.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series12.SmartLabelStyle.CalloutLineWidth = 0;
            series12.SmartLabelStyle.Enabled = false;
            series12.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartSpot.Series.Add(series10);
            this.chartSpot.Series.Add(series11);
            this.chartSpot.Series.Add(series12);
            this.chartSpot.Size = new System.Drawing.Size(849, 300);
            this.chartSpot.TabIndex = 27;
            this.chartSpot.Text = "chart1";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.toolStripProgressBar1});
            this.status.Location = new System.Drawing.Point(0, 718);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1043, 23);
            this.status.TabIndex = 13;
            this.status.Text = "status";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 18);
            this.labelStatus.Text = "labelStatus";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 17);
            this.toolStripProgressBar1.Visible = false;
            // 
            // nudT
            // 
            this.nudT.Location = new System.Drawing.Point(96, 15);
            this.nudT.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudT.Name = "nudT";
            this.nudT.Size = new System.Drawing.Size(40, 19);
            this.nudT.TabIndex = 8;
            this.nudT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudT.ValueChanged += new System.EventHandler(this.nudT_ValueChanged);
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(79, 17);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(14, 12);
            this.labelT.TabIndex = 7;
            this.labelT.Text = "T:";
            // 
            // nudZ
            // 
            this.nudZ.Location = new System.Drawing.Point(33, 15);
            this.nudZ.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(40, 19);
            this.nudZ.TabIndex = 6;
            this.nudZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZ.ValueChanged += new System.EventHandler(this.nudZ_ValueChanged);
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(16, 17);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 12);
            this.labelZ.TabIndex = 5;
            this.labelZ.Text = "Z:";
            // 
            // scrollT
            // 
            this.scrollT.LargeChange = 1;
            this.scrollT.Location = new System.Drawing.Point(14, 300);
            this.scrollT.Maximum = 1;
            this.scrollT.Minimum = 1;
            this.scrollT.Name = "scrollT";
            this.scrollT.Size = new System.Drawing.Size(336, 23);
            this.scrollT.TabIndex = 4;
            this.scrollT.Value = 1;
            this.scrollT.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollT_Scroll);
            // 
            // scrollZ
            // 
            this.scrollZ.LargeChange = 1;
            this.scrollZ.Location = new System.Drawing.Point(353, 40);
            this.scrollZ.Maximum = 1;
            this.scrollZ.Minimum = 1;
            this.scrollZ.Name = "scrollZ";
            this.scrollZ.Size = new System.Drawing.Size(17, 256);
            this.scrollZ.TabIndex = 3;
            this.scrollZ.Value = 1;
            this.scrollZ.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollZ_Scroll);
            // 
            // pictureMicroImage
            // 
            this.pictureMicroImage.Location = new System.Drawing.Point(14, 40);
            this.pictureMicroImage.Name = "pictureMicroImage";
            this.pictureMicroImage.Size = new System.Drawing.Size(336, 256);
            this.pictureMicroImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMicroImage.TabIndex = 2;
            this.pictureMicroImage.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 767);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "無題 - Micro Image Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tab.ResumeLayout(false);
            this.AnalyzeArea.ResumeLayout(false);
            this.AnalyzeArea.PerformLayout();
            this.groupAnalyzeAreaSets.ResumeLayout(false);
            this.groupAnalyzeAreaSets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnalyzeAreaSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            this.Slice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSliceAreaSets)).EndInit();
            this.groupChartArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpot)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMicroImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem menuProject;
		private System.Windows.Forms.ToolStripMenuItem menuProjectNew;
		private System.Windows.Forms.ToolStripMenuItem menuProjectOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuProjectExit;
		private System.Windows.Forms.ToolStripMenuItem menuTool;
		private System.Windows.Forms.ToolStripMenuItem menuToolEditSettings;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
		private System.Windows.Forms.CheckBox checkBinarize;
		private System.Windows.Forms.NumericUpDown nudT;
		private System.Windows.Forms.Label labelT;
		private System.Windows.Forms.NumericUpDown nudZ;
		private System.Windows.Forms.Label labelZ;
		private System.Windows.Forms.HScrollBar scrollT;
		private System.Windows.Forms.VScrollBar scrollZ;
        private System.Windows.Forms.PictureBox pictureMicroImage;
        private System.Windows.Forms.CheckBox checkDrawArea;
        private System.Windows.Forms.GroupBox groupChartArea;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpot;
        private System.Windows.Forms.Button buttonExportAsCSV;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSaveAs;
        private System.Windows.Forms.RadioButton radioButtonPic561;
        private System.Windows.Forms.RadioButton radioButtonPic473;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage AnalyzeArea;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.GroupBox groupAnalyzeAreaSets;
        private System.Windows.Forms.Button buttonRemoveAnalyzeAreaSet;
        private System.Windows.Forms.Button buttonEditAnalyzeAreaSet;
        private System.Windows.Forms.Button buttonAddAnalyzeAreaSet;
        private System.Windows.Forms.DataGridView dataAnalyzeAreaSets;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.Button buttonAnalyzer;
        private System.Windows.Forms.TabPage Slice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataSliceAreaSets;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
	}
}

