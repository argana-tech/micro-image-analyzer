namespace MicroImageAnalyzer
{
	partial class NewProject
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
            this.textSourceFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSourceFolder = new System.Windows.Forms.Button();
            this.labelDestinationFolder = new System.Windows.Forms.Label();
            this.textDestinationFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseDestinationFolder = new System.Windows.Forms.Button();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textProjectName = new System.Windows.Forms.TextBox();
            this.labelT = new System.Windows.Forms.Label();
            this.textT = new System.Windows.Forms.TextBox();
            this.labelTDimension = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.textZ = new System.Windows.Forms.TextBox();
            this.labelZDimension = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textY = new System.Windows.Forms.TextBox();
            this.labelYDimension = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.textX = new System.Windows.Forms.TextBox();
            this.labelXDimension = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProjectFileName = new System.Windows.Forms.Label();
            this.textProjectFileName = new System.Windows.Forms.TextBox();
            this._project = new System.Windows.Forms.Label();
            this.labelSourceFolder = new System.Windows.Forms.Label();
            this.labelImage = new System.Windows.Forms.Label();
            this.textImageCount = new System.Windows.Forms.TextBox();
            this.labelMai = new System.Windows.Forms.Label();
            this.labelKaku = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.textFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupSettings.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // textSourceFolder
            // 
            this.textSourceFolder.Location = new System.Drawing.Point(122, 14);
            this.textSourceFolder.Name = "textSourceFolder";
            this.textSourceFolder.Size = new System.Drawing.Size(344, 19);
            this.textSourceFolder.TabIndex = 1;
            // 
            // buttonBrowseSourceFolder
            // 
            this.buttonBrowseSourceFolder.Location = new System.Drawing.Point(472, 12);
            this.buttonBrowseSourceFolder.Name = "buttonBrowseSourceFolder";
            this.buttonBrowseSourceFolder.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseSourceFolder.TabIndex = 2;
            this.buttonBrowseSourceFolder.Text = "参照...";
            this.buttonBrowseSourceFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseSourceFolder.Click += new System.EventHandler(this.buttonBrowseSourceFolder_Click);
            // 
            // labelDestinationFolder
            // 
            this.labelDestinationFolder.AutoSize = true;
            this.labelDestinationFolder.Location = new System.Drawing.Point(12, 134);
            this.labelDestinationFolder.Name = "labelDestinationFolder";
            this.labelDestinationFolder.Size = new System.Drawing.Size(66, 12);
            this.labelDestinationFolder.TabIndex = 3;
            this.labelDestinationFolder.Text = "保存フォルダ:";
            // 
            // textDestinationFolder
            // 
            this.textDestinationFolder.Location = new System.Drawing.Point(122, 131);
            this.textDestinationFolder.Name = "textDestinationFolder";
            this.textDestinationFolder.Size = new System.Drawing.Size(344, 19);
            this.textDestinationFolder.TabIndex = 4;
            // 
            // buttonBrowseDestinationFolder
            // 
            this.buttonBrowseDestinationFolder.Location = new System.Drawing.Point(472, 129);
            this.buttonBrowseDestinationFolder.Name = "buttonBrowseDestinationFolder";
            this.buttonBrowseDestinationFolder.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseDestinationFolder.TabIndex = 5;
            this.buttonBrowseDestinationFolder.Text = "参照...";
            this.buttonBrowseDestinationFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseDestinationFolder.Click += new System.EventHandler(this.buttonBrowseDestinationFolder_Click);
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.labelProjectName);
            this.groupSettings.Controls.Add(this.textProjectName);
            this.groupSettings.Controls.Add(this.labelT);
            this.groupSettings.Controls.Add(this.textT);
            this.groupSettings.Controls.Add(this.labelTDimension);
            this.groupSettings.Controls.Add(this.labelZ);
            this.groupSettings.Controls.Add(this.textZ);
            this.groupSettings.Controls.Add(this.labelZDimension);
            this.groupSettings.Controls.Add(this.labelY);
            this.groupSettings.Controls.Add(this.textY);
            this.groupSettings.Controls.Add(this.labelYDimension);
            this.groupSettings.Controls.Add(this.labelX);
            this.groupSettings.Controls.Add(this.textX);
            this.groupSettings.Controls.Add(this.labelXDimension);
            this.groupSettings.Location = new System.Drawing.Point(13, 197);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(560, 115);
            this.groupSettings.TabIndex = 6;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "プロジェクト設定";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(24, 25);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(70, 12);
            this.labelProjectName.TabIndex = 24;
            this.labelProjectName.Text = "プロジェクト名:";
            // 
            // textProjectName
            // 
            this.textProjectName.Location = new System.Drawing.Point(96, 22);
            this.textProjectName.Name = "textProjectName";
            this.textProjectName.Size = new System.Drawing.Size(357, 19);
            this.textProjectName.TabIndex = 23;
            this.textProjectName.TextChanged += new System.EventHandler(this.textProjectName_TextChanged);
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(242, 83);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(40, 12);
            this.labelT.TabIndex = 20;
            this.labelT.Text = "frames";
            // 
            // textT
            // 
            this.textT.Location = new System.Drawing.Point(186, 80);
            this.textT.Name = "textT";
            this.textT.Size = new System.Drawing.Size(50, 19);
            this.textT.TabIndex = 19;
            // 
            // labelTDimension
            // 
            this.labelTDimension.AutoSize = true;
            this.labelTDimension.Location = new System.Drawing.Point(165, 83);
            this.labelTDimension.Name = "labelTDimension";
            this.labelTDimension.Size = new System.Drawing.Size(14, 12);
            this.labelTDimension.TabIndex = 18;
            this.labelTDimension.Text = "T:";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(101, 83);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(35, 12);
            this.labelZ.TabIndex = 15;
            this.labelZ.Text = "slices";
            // 
            // textZ
            // 
            this.textZ.Location = new System.Drawing.Point(45, 80);
            this.textZ.Name = "textZ";
            this.textZ.Size = new System.Drawing.Size(50, 19);
            this.textZ.TabIndex = 14;
            // 
            // labelZDimension
            // 
            this.labelZDimension.AutoSize = true;
            this.labelZDimension.Location = new System.Drawing.Point(24, 83);
            this.labelZDimension.Name = "labelZDimension";
            this.labelZDimension.Size = new System.Drawing.Size(14, 12);
            this.labelZDimension.TabIndex = 13;
            this.labelZDimension.Text = "Z:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(242, 58);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(35, 12);
            this.labelY.TabIndex = 10;
            this.labelY.Text = "pixels";
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(186, 55);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(50, 19);
            this.textY.TabIndex = 9;
            // 
            // labelYDimension
            // 
            this.labelYDimension.AutoSize = true;
            this.labelYDimension.Location = new System.Drawing.Point(165, 58);
            this.labelYDimension.Name = "labelYDimension";
            this.labelYDimension.Size = new System.Drawing.Size(14, 12);
            this.labelYDimension.TabIndex = 8;
            this.labelYDimension.Text = "Y:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(101, 58);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(35, 12);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "pixels";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(45, 55);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(50, 19);
            this.textX.TabIndex = 4;
            // 
            // labelXDimension
            // 
            this.labelXDimension.AutoSize = true;
            this.labelXDimension.Location = new System.Drawing.Point(24, 58);
            this.labelXDimension.Name = "labelXDimension";
            this.labelXDimension.Size = new System.Drawing.Size(14, 12);
            this.labelXDimension.TabIndex = 3;
            this.labelXDimension.Text = "X:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(366, 318);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(472, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.status.Location = new System.Drawing.Point(0, 409);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(588, 23);
            this.status.TabIndex = 9;
            this.status.Text = "status";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 18);
            this.labelStatus.Text = "labelStatus";
            // 
            // labelProjectFileName
            // 
            this.labelProjectFileName.AutoSize = true;
            this.labelProjectFileName.Location = new System.Drawing.Point(12, 165);
            this.labelProjectFileName.Name = "labelProjectFileName";
            this.labelProjectFileName.Size = new System.Drawing.Size(104, 12);
            this.labelProjectFileName.TabIndex = 26;
            this.labelProjectFileName.Text = "プロジェクトファイル名:";
            // 
            // textProjectFileName
            // 
            this.textProjectFileName.Location = new System.Drawing.Point(122, 162);
            this.textProjectFileName.Name = "textProjectFileName";
            this.textProjectFileName.Size = new System.Drawing.Size(301, 19);
            this.textProjectFileName.TabIndex = 25;
            this.textProjectFileName.TextChanged += new System.EventHandler(this.textProjectFileName_TextChanged);
            // 
            // _project
            // 
            this._project.AutoSize = true;
            this._project.Location = new System.Drawing.Point(422, 165);
            this._project.Name = "_project";
            this._project.Size = new System.Drawing.Size(42, 12);
            this._project.TabIndex = 27;
            this._project.Text = ".project";
            // 
            // labelSourceFolder
            // 
            this.labelSourceFolder.AutoSize = true;
            this.labelSourceFolder.Location = new System.Drawing.Point(12, 17);
            this.labelSourceFolder.Name = "labelSourceFolder";
            this.labelSourceFolder.Size = new System.Drawing.Size(66, 12);
            this.labelSourceFolder.TabIndex = 28;
            this.labelSourceFolder.Text = "参照フォルダ:";
            // 
            // labelImage
            // 
            this.labelImage.AutoSize = true;
            this.labelImage.Location = new System.Drawing.Point(120, 90);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(29, 12);
            this.labelImage.TabIndex = 30;
            this.labelImage.Text = "枚数";
            // 
            // textImageCount
            // 
            this.textImageCount.Location = new System.Drawing.Point(194, 87);
            this.textImageCount.Name = "textImageCount";
            this.textImageCount.ReadOnly = true;
            this.textImageCount.Size = new System.Drawing.Size(32, 19);
            this.textImageCount.TabIndex = 29;
            this.textImageCount.Text = "0";
            this.textImageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMai
            // 
            this.labelMai.AutoSize = true;
            this.labelMai.Location = new System.Drawing.Point(232, 90);
            this.labelMai.Name = "labelMai";
            this.labelMai.Size = new System.Drawing.Size(17, 12);
            this.labelMai.TabIndex = 33;
            this.labelMai.Text = "枚";
            // 
            // labelKaku
            // 
            this.labelKaku.AutoSize = true;
            this.labelKaku.Location = new System.Drawing.Point(171, 90);
            this.labelKaku.Name = "labelKaku";
            this.labelKaku.Size = new System.Drawing.Size(17, 12);
            this.labelKaku.TabIndex = 34;
            this.labelKaku.Text = "各";
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(12, 42);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(81, 12);
            this.labelFormat.TabIndex = 37;
            this.labelFormat.Text = "対象フォーマット:";
            // 
            // buttonFormat
            // 
            this.buttonFormat.Location = new System.Drawing.Point(472, 37);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(100, 23);
            this.buttonFormat.TabIndex = 36;
            this.buttonFormat.Text = "取得";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            // 
            // textFormat
            // 
            this.textFormat.Location = new System.Drawing.Point(122, 39);
            this.textFormat.Name = "textFormat";
            this.textFormat.Size = new System.Drawing.Size(344, 19);
            this.textFormat.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "フォーマット例 : U2REP-LE53-21__w[x]Confocal [nm]nm_s1_t[t].TIF";
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.buttonFormat);
            this.Controls.Add(this.textFormat);
            this.Controls.Add(this.labelKaku);
            this.Controls.Add(this.labelMai);
            this.Controls.Add(this.labelImage);
            this.Controls.Add(this.textImageCount);
            this.Controls.Add(this.labelSourceFolder);
            this.Controls.Add(this._project);
            this.Controls.Add(this.labelProjectFileName);
            this.Controls.Add(this.textProjectFileName);
            this.Controls.Add(this.status);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.buttonBrowseDestinationFolder);
            this.Controls.Add(this.textDestinationFolder);
            this.Controls.Add(this.labelDestinationFolder);
            this.Controls.Add(this.buttonBrowseSourceFolder);
            this.Controls.Add(this.textSourceFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewProject";
            this.Text = "新しいプロジェクト";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox textSourceFolder;
		private System.Windows.Forms.Button buttonBrowseSourceFolder;
		private System.Windows.Forms.Label labelDestinationFolder;
		private System.Windows.Forms.TextBox textDestinationFolder;
		private System.Windows.Forms.Button buttonBrowseDestinationFolder;
        private System.Windows.Forms.GroupBox groupSettings;
		private System.Windows.Forms.Label labelT;
		private System.Windows.Forms.TextBox textT;
        private System.Windows.Forms.Label labelTDimension;
		private System.Windows.Forms.Label labelZ;
		private System.Windows.Forms.TextBox textZ;
        private System.Windows.Forms.Label labelZDimension;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label labelYDimension;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.Label labelXDimension;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.TextBox textProjectName;
        private System.Windows.Forms.Label labelProjectFileName;
        private System.Windows.Forms.TextBox textProjectFileName;
        private System.Windows.Forms.Label _project;
        private System.Windows.Forms.Label labelSourceFolder;
        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.TextBox textImageCount;
        private System.Windows.Forms.Label labelMai;
        private System.Windows.Forms.Label labelKaku;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Button buttonFormat;
        private System.Windows.Forms.TextBox textFormat;
        private System.Windows.Forms.Label label1;
	}
}