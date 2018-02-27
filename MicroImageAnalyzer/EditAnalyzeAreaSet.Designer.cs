namespace MicroImageAnalyzer
{
	partial class EditAnalyzeAreaSet
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
            this.pictureMicroImage = new System.Windows.Forms.PictureBox();
            this.scrollT = new System.Windows.Forms.HScrollBar();
            this.labelT = new System.Windows.Forms.Label();
            this.nudT = new System.Windows.Forms.NumericUpDown();
            this.checkBinarize = new System.Windows.Forms.CheckBox();
            this.labelPointXLabel = new System.Windows.Forms.Label();
            this.labelPointX = new System.Windows.Forms.Label();
            this.labelPointYLabel = new System.Windows.Forms.Label();
            this.labelPointY = new System.Windows.Forms.Label();
            this.groupAnalyzeAreas = new System.Windows.Forms.GroupBox();
            this.buttonFill = new System.Windows.Forms.Button();
            this.checkEnabled = new System.Windows.Forms.CheckBox();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.labelR = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.labelY = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.dataAnalyzeAreas = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioButtonPic473 = new System.Windows.Forms.RadioButton();
            this.radioButtonPic561 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMicroImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).BeginInit();
            this.groupAnalyzeAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnalyzeAreas)).BeginInit();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureMicroImage
            // 
            this.pictureMicroImage.Location = new System.Drawing.Point(12, 40);
            this.pictureMicroImage.Name = "pictureMicroImage";
            this.pictureMicroImage.Size = new System.Drawing.Size(336, 256);
            this.pictureMicroImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMicroImage.TabIndex = 2;
            this.pictureMicroImage.TabStop = false;
            // 
            // scrollT
            // 
            this.scrollT.LargeChange = 1;
            this.scrollT.Location = new System.Drawing.Point(12, 299);
            this.scrollT.Maximum = 1;
            this.scrollT.Minimum = 1;
            this.scrollT.Name = "scrollT";
            this.scrollT.Size = new System.Drawing.Size(336, 17);
            this.scrollT.TabIndex = 4;
            this.scrollT.Value = 1;
            this.scrollT.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollT_Scroll);
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(19, 327);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(14, 12);
            this.labelT.TabIndex = 7;
            this.labelT.Text = "T:";
            // 
            // nudT
            // 
            this.nudT.Location = new System.Drawing.Point(36, 325);
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
            // checkBinarize
            // 
            this.checkBinarize.AutoSize = true;
            this.checkBinarize.Location = new System.Drawing.Point(155, 326);
            this.checkBinarize.Name = "checkBinarize";
            this.checkBinarize.Size = new System.Drawing.Size(54, 16);
            this.checkBinarize.TabIndex = 9;
            this.checkBinarize.Text = "2値化";
            this.checkBinarize.UseVisualStyleBackColor = true;
            this.checkBinarize.CheckedChanged += new System.EventHandler(this.checkBinarize_CheckedChanged);
            // 
            // labelPointXLabel
            // 
            this.labelPointXLabel.AutoSize = true;
            this.labelPointXLabel.Location = new System.Drawing.Point(232, 327);
            this.labelPointXLabel.Name = "labelPointXLabel";
            this.labelPointXLabel.Size = new System.Drawing.Size(14, 12);
            this.labelPointXLabel.TabIndex = 10;
            this.labelPointXLabel.Text = "X:";
            // 
            // labelPointX
            // 
            this.labelPointX.AutoSize = true;
            this.labelPointX.Location = new System.Drawing.Point(246, 327);
            this.labelPointX.Name = "labelPointX";
            this.labelPointX.Size = new System.Drawing.Size(23, 12);
            this.labelPointX.TabIndex = 11;
            this.labelPointX.Text = "999";
            // 
            // labelPointYLabel
            // 
            this.labelPointYLabel.AutoSize = true;
            this.labelPointYLabel.Location = new System.Drawing.Point(275, 327);
            this.labelPointYLabel.Name = "labelPointYLabel";
            this.labelPointYLabel.Size = new System.Drawing.Size(14, 12);
            this.labelPointYLabel.TabIndex = 12;
            this.labelPointYLabel.Text = "Y:";
            // 
            // labelPointY
            // 
            this.labelPointY.AutoSize = true;
            this.labelPointY.Location = new System.Drawing.Point(289, 327);
            this.labelPointY.Name = "labelPointY";
            this.labelPointY.Size = new System.Drawing.Size(23, 12);
            this.labelPointY.TabIndex = 13;
            this.labelPointY.Text = "999";
            // 
            // groupAnalyzeAreas
            // 
            this.groupAnalyzeAreas.Controls.Add(this.buttonFill);
            this.groupAnalyzeAreas.Controls.Add(this.checkEnabled);
            this.groupAnalyzeAreas.Controls.Add(this.nudThreshold);
            this.groupAnalyzeAreas.Controls.Add(this.labelThreshold);
            this.groupAnalyzeAreas.Controls.Add(this.nudR);
            this.groupAnalyzeAreas.Controls.Add(this.labelR);
            this.groupAnalyzeAreas.Controls.Add(this.nudY);
            this.groupAnalyzeAreas.Controls.Add(this.labelY);
            this.groupAnalyzeAreas.Controls.Add(this.nudX);
            this.groupAnalyzeAreas.Controls.Add(this.labelX);
            this.groupAnalyzeAreas.Controls.Add(this.dataAnalyzeAreas);
            this.groupAnalyzeAreas.Location = new System.Drawing.Point(369, 13);
            this.groupAnalyzeAreas.Name = "groupAnalyzeAreas";
            this.groupAnalyzeAreas.Size = new System.Drawing.Size(641, 293);
            this.groupAnalyzeAreas.TabIndex = 14;
            this.groupAnalyzeAreas.TabStop = false;
            this.groupAnalyzeAreas.Text = "解析エリア情報";
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(535, 261);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(100, 23);
            this.buttonFill.TabIndex = 20;
            this.buttonFill.Text = "反映";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // checkEnabled
            // 
            this.checkEnabled.AutoSize = true;
            this.checkEnabled.Location = new System.Drawing.Point(6, 265);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Size = new System.Drawing.Size(67, 16);
            this.checkEnabled.TabIndex = 16;
            this.checkEnabled.Text = "解析する";
            this.checkEnabled.UseVisualStyleBackColor = true;
            this.checkEnabled.CheckedChanged += new System.EventHandler(this.checkEnabled_CheckedChanged);
            // 
            // nudThreshold
            // 
            this.nudThreshold.Location = new System.Drawing.Point(303, 264);
            this.nudThreshold.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(55, 19);
            this.nudThreshold.TabIndex = 8;
            this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(269, 266);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(31, 12);
            this.labelThreshold.TabIndex = 7;
            this.labelThreshold.Text = "閾値:";
            // 
            // nudR
            // 
            this.nudR.Location = new System.Drawing.Point(223, 264);
            this.nudR.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(40, 19);
            this.nudR.TabIndex = 6;
            this.nudR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudR.ValueChanged += new System.EventHandler(this.nudR_ValueChanged);
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(205, 266);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(15, 12);
            this.labelR.TabIndex = 5;
            this.labelR.Text = "R:";
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(159, 264);
            this.nudY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(40, 19);
            this.nudY.TabIndex = 4;
            this.nudY.ValueChanged += new System.EventHandler(this.nudY_ValueChanged);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(142, 266);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 12);
            this.labelY.TabIndex = 3;
            this.labelY.Text = "Y:";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(96, 264);
            this.nudX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(40, 19);
            this.nudX.TabIndex = 2;
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(79, 266);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 12);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X:";
            // 
            // dataAnalyzeAreas
            // 
            this.dataAnalyzeAreas.AllowUserToAddRows = false;
            this.dataAnalyzeAreas.AllowUserToDeleteRows = false;
            this.dataAnalyzeAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAnalyzeAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAnalyzeAreas.Location = new System.Drawing.Point(6, 20);
            this.dataAnalyzeAreas.MultiSelect = false;
            this.dataAnalyzeAreas.Name = "dataAnalyzeAreas";
            this.dataAnalyzeAreas.ReadOnly = true;
            this.dataAnalyzeAreas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataAnalyzeAreas.RowTemplate.Height = 21;
            this.dataAnalyzeAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataAnalyzeAreas.Size = new System.Drawing.Size(629, 236);
            this.dataAnalyzeAreas.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(373, 327);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 12);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "エリア名:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(433, 324);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(173, 19);
            this.textName.TabIndex = 20;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(612, 322);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Text = "追加";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(723, 322);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.status.Location = new System.Drawing.Point(0, 358);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1025, 23);
            this.status.TabIndex = 18;
            this.status.Text = "status";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 18);
            this.labelStatus.Text = "labelStatus";
            // 
            // radioButtonPic473
            // 
            this.radioButtonPic473.AutoSize = true;
            this.radioButtonPic473.Checked = true;
            this.radioButtonPic473.Location = new System.Drawing.Point(14, 13);
            this.radioButtonPic473.Name = "radioButtonPic473";
            this.radioButtonPic473.Size = new System.Drawing.Size(41, 16);
            this.radioButtonPic473.TabIndex = 21;
            this.radioButtonPic473.TabStop = true;
            this.radioButtonPic473.Text = "473";
            this.radioButtonPic473.UseVisualStyleBackColor = true;
            this.radioButtonPic473.CheckedChanged += new System.EventHandler(this.radioButtonPix473_CheckedChanged);
            // 
            // radioButtonPic561
            // 
            this.radioButtonPic561.AutoSize = true;
            this.radioButtonPic561.Location = new System.Drawing.Point(61, 13);
            this.radioButtonPic561.Name = "radioButtonPic561";
            this.radioButtonPic561.Size = new System.Drawing.Size(41, 16);
            this.radioButtonPic561.TabIndex = 22;
            this.radioButtonPic561.Text = "561";
            this.radioButtonPic561.UseVisualStyleBackColor = true;
            this.radioButtonPic561.CheckedChanged += new System.EventHandler(this.radioButtonPic561_CheckedChanged);
            // 
            // EditAnalyzeAreaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 381);
            this.Controls.Add(this.radioButtonPic561);
            this.Controls.Add(this.radioButtonPic473);
            this.Controls.Add(this.status);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.groupAnalyzeAreas);
            this.Controls.Add(this.labelPointY);
            this.Controls.Add(this.labelPointYLabel);
            this.Controls.Add(this.labelPointX);
            this.Controls.Add(this.labelPointXLabel);
            this.Controls.Add(this.checkBinarize);
            this.Controls.Add(this.nudT);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.scrollT);
            this.Controls.Add(this.pictureMicroImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditAnalyzeAreaSet";
            this.Text = "解析エリアを追加";
            this.Load += new System.EventHandler(this.EditAnalyzeAreaSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMicroImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudT)).EndInit();
            this.groupAnalyzeAreas.ResumeLayout(false);
            this.groupAnalyzeAreas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnalyzeAreas)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.PictureBox pictureMicroImage;
        private System.Windows.Forms.HScrollBar scrollT;
		private System.Windows.Forms.Label labelT;
		private System.Windows.Forms.NumericUpDown nudT;
		private System.Windows.Forms.CheckBox checkBinarize;
		private System.Windows.Forms.Label labelPointXLabel;
		private System.Windows.Forms.Label labelPointX;
		private System.Windows.Forms.Label labelPointYLabel;
		private System.Windows.Forms.Label labelPointY;
		private System.Windows.Forms.GroupBox groupAnalyzeAreas;
		private System.Windows.Forms.NumericUpDown nudThreshold;
		private System.Windows.Forms.Label labelThreshold;
		private System.Windows.Forms.NumericUpDown nudR;
		private System.Windows.Forms.Label labelR;
		private System.Windows.Forms.NumericUpDown nudY;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.NumericUpDown nudX;
		private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.DataGridView dataAnalyzeAreas;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
		private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.RadioButton radioButtonPic473;
        private System.Windows.Forms.RadioButton radioButtonPic561;
        private System.Windows.Forms.Button buttonFill;
	}
}