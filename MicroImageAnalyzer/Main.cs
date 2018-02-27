using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BitMiracle.LibTiff.Classic;
using System.IO;

namespace MicroImageAnalyzer
{
	public partial class Main : Form
	{
		private Project _Project;
        private Analyzer _Analyzer = null;

		private bool _IsDirty = false;

		private string _Flash = "";

        private Spot _Spot = null;
		public Main()
		{
			InitializeComponent();

			dataAnalyzeAreaSets.SelectionChanged += new EventHandler(dataAnalyzeAreaSets_SelectionChanged);
            dataSliceAreaSets.SelectionChanged += new EventHandler(dataSliceAreaSets_SelectionChanged);
           
			this._Render();
		}

		private void menuProjectNew_Click(object sender, EventArgs e)
		{
			NewProject newProject = new NewProject();
			newProject.ShowDialog();

			if (newProject.CreatedProject)
			{
				this._Project = newProject.Project;
				this._Flash = "プロジェクトを作成しました。";
				this._InitializeProject();
			}

			newProject.Dispose();

			this._Render();
		}

		private void menuProjectOpen_Click(object sender, EventArgs e)
		{
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "default.project";
            dialog.Filter ="Projectファイル(*.project)|*.project";
            dialog.Title = "プロジェクトファイルを選択してください。";

            if (dialog.ShowDialog() == DialogResult.OK)
			{
                string path = dialog.FileName;
                Project project = new Project();
				if (project.Load(path))
				{
					this._Project = project;
					this._Flash = "プロジェクトを開きました。";
					this._InitializeProject();
				}
				else
				{
					if (project.HasError())
					{
						MessageBox.Show(project.GetError());
					}

					this._Flash = "プロジェクトを開けませんでした。";
				}
			}

			this._Render();
		}

		private void menuProjectSave_Click(object sender, EventArgs e)
		{
			if (this._Project.Save())
			{
				this._Flash = "プロジェクトを保存しました。";
			}
			else
			{
				if (this._Project.HasError())
				{
					MessageBox.Show(this._Project.GetError());
				}

				this._Flash = "プロジェクトを保存できませんでした。";
			}

			this._Render();
		}

		private void menuProjectSaveAs_Click(object sender, EventArgs e)
		{

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = this._Project.ProjectFileName;
            dialog.Filter ="Projectファイル(*.project)|*.project";
            dialog.Title = "プロジェクトを保存するファイルを選択してください。";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor oldCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                string path = dialog.FileName;

                string pFileName = Path.GetFileName(path);

                this._Project.SetDestinationProjectFileName(pFileName);
                this._Project.SetDestinationProjectImagesFolderName(pFileName.Replace(".project", ".images"));

                path = path.Replace(pFileName, "");

				if (this._Project.SetDestinationFolder(path) && this._Project.SaveAs())
				{
					this._Flash = "プロジェクトを保存しました。";
				}
				else
				{
					if (this._Project.HasError())
					{
						MessageBox.Show(this._Project.GetError());
					}

					this._Flash = "プロジェクトを保存できませんでした。";
                }
                Cursor.Current = oldCursor;
			}

            this._Render();
		}

		private void menuProjectExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void menuToolEditSettings_Click(object sender, EventArgs e)
		{
			EditProject editProject = new EditProject(this._Project);
			editProject.ShowDialog();

			if (editProject.UpdatedProject)
			{
				this._Project = editProject.Project;
				this._Flash = "プロジェクト設定を変更しました。";
				this._InitializeProject();
				this._IsDirty = true;
			}

			editProject.Dispose();

			this._Render();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._IsDirty)
			{
				DialogResult result = MessageBox.Show(
					"'" + this._Project.Name + "' への変更を保存しますか？",
					"Micro Image Analyzer",
					MessageBoxButtons.YesNoCancel
				);

				if (result == DialogResult.Yes)
				{
					this._Project.Save();
				}
				else if (result == DialogResult.No)
				{
				}
				else if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		private void scrollZ_Scroll(object sender, ScrollEventArgs e)
		{
			nudZ.Value = scrollZ.Value;
		}

		private void scrollT_Scroll(object sender, ScrollEventArgs e)
		{
            nudT.Value = scrollT.Value;
		}

		private void nudZ_ValueChanged(object sender, EventArgs e)
		{
            scrollZ.Value = (int)nudZ.Value;
            
			this._Render();
		}

		private void nudT_ValueChanged(object sender, EventArgs e)
		{
            scrollT.Value = (int)nudT.Value;

			this._Render();
		}

		private void checkBinarize_CheckedChanged(object sender, EventArgs e)
		{
            //nudThreshold.Enabled = checkBinarize.Checked == true ? true : false;
			this._Render();
		}

		private void nudThreshold_ValueChanged(object sender, EventArgs e)
		{
			this._Render();
		}

		private void checkDrawArea_CheckedChanged(object sender, EventArgs e)
		{
			this._Render();
		}

        private void buttonAddAnalyzeAreaSet_Click(object sender, EventArgs e)
        {
			EditAnalyzeAreaSet editAnalyzeAreaSet = new EditAnalyzeAreaSet(
				this._Project,
				scrollZ.Value,
				scrollT.Value
			);
			editAnalyzeAreaSet.ShowDialog();

			if (editAnalyzeAreaSet.CreatedAnalyzeAreaSet)
			{
				this._IsDirty = true;

				AnalyzeAreaSet analyzeAreaSet = editAnalyzeAreaSet.AnalyzeAreaSet;
				this._Project.AddAnalyzeAreaSet(analyzeAreaSet);
				this._Render();
			}

			editAnalyzeAreaSet.Dispose();
		}

		private void buttonEditAnalyzeAreaSet_Click(object sender, EventArgs e)
		{
			if (dataAnalyzeAreaSets.SelectedRows.Count > 0)
			{
				AnalyzeAreaSet analyzeAreaSet = this._GetCurrentAnalyzeAreaSet();

				EditAnalyzeAreaSet editAnalyzeAreaSet = new EditAnalyzeAreaSet(
					analyzeAreaSet,
					this._Project,
					scrollZ.Value,
					scrollT.Value
				);
				editAnalyzeAreaSet.ShowDialog();

				if (editAnalyzeAreaSet.UpdatedAnalyzeAreaSet)
				{
					this._IsDirty = true;

					this._Render();
				}

				editAnalyzeAreaSet.Dispose();
			}
		}

		private void buttonRemoveAnalyzeAreaSet_Click(object sender, EventArgs e)
		{
			if (dataAnalyzeAreaSets.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dataAnalyzeAreaSets.SelectedRows[0];
				AnalyzeAreaSet analyzeAreaSet = this._GetCurrentAnalyzeAreaSet();

				if (MessageBox.Show("解析エリア '" + analyzeAreaSet.Name + "' を削除します。\nよろしいですか？", "解析エリアの削除", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this._IsDirty = true;
					this._Project.RemoveAnalyzeAreaSet(row.Index);
				}
			}
		}

		private void buttonExportAsCSV_Click(object sender, EventArgs e)
		{
            buttonExportAsCSV.Enabled = false;
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            if (this._Project.ExportAsCSV(dataAnalyzeAreaSets.CurrentCell.RowIndex,this._Spot))
            {
                this._Flash = "CSVを出力しました。";
            }
            else
            {
                if (this._Project.HasError())
                {
                    MessageBox.Show(this._Project.GetError());
                }

                this._Flash = "CSVを出力できませんでした。";
            }

			Cursor.Current = oldCursor;
			buttonExportAsCSV.Enabled = true;

            //this._Render();
		}

		private void dataAnalyzeAreaSets_SelectionChanged(object sender, EventArgs e)
		{
			if (dataAnalyzeAreaSets.SelectedRows.Count > 0)
			{
                this._SetTargetValueZ();
                buttonExportAsCSV.Enabled = false;
                chartSpot.Visible = false;
			}

			this._Render();
		}

        private void dataSliceAreaSets_SelectionChanged(object sender, EventArgs e)
		{
            try
            {
                Project project = this._Project;
                if (dataSliceAreaSets.Rows.Count >= this._Project.Z && tab.SelectedIndex == 1)
                {
                    int rowIndex = dataSliceAreaSets.CurrentCell.ColumnIndex;
                    int cellIndex = dataSliceAreaSets.CurrentCell.RowIndex;

                    int countCell = 0;
                    foreach (DataGridViewRow row in dataSliceAreaSets.Rows)
                    {
                        row.Cells[rowIndex].Value = "";
                        project.SliceAreas[rowIndex, countCell] = false;
                        countCell++;
                    }

                    dataSliceAreaSets.CurrentCell.Value = "×";
                    project.SliceAreas[rowIndex, cellIndex] = true;


                    nudT.Value = rowIndex + 1;
                    nudZ.Value = cellIndex + 1;
                }
            }
            catch (Exception)
            {
            }
		}

		private void _InitializeProject()
		{
			Project project = this._Project;

			this.Text = project.Name + " - Micro Image Analyzer";

            if (project.C >= 1)
            {
                this._Analyzer = this._Project.GetAnalyzer(1);
                this._InitializeAnalyzer();
            }
            
			scrollZ.Minimum = 1;
			scrollZ.Maximum = project.Z;
			scrollT.Minimum = 1;
			scrollT.Maximum = project.T;
			nudZ.Minimum = 1;
			nudZ.Maximum = project.Z;
			nudT.Minimum = 1;
			nudT.Maximum = project.T;

			nudThreshold.Minimum = 0;
            nudThreshold.Maximum = 65535;
			nudThreshold.Value = 450;

            this._InitializeAnalyzer();
            this._InitializeSlice();
		}

		private void _InitializeAnalyzer()
        {
            dataAnalyzeAreaSets.Columns.Clear();
			dataAnalyzeAreaSets.DataSource = null;
			dataAnalyzeAreaSets.DataSource = this._Project.AnalyzeAreaSets;

            for (int t = 1; t <= this._Project.T; t++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = t.ToString();
                column.HeaderText = "T" + t.ToString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                dataAnalyzeAreaSets.Columns.Add(column);
            }
		}

        private void _InitializeSlice()
        {
            Project project = this._Project;
            dataSliceAreaSets.DataSource = null;
            dataSliceAreaSets.Columns.Clear();

            Boolean[,] sliceArea = new Boolean[project.T, project.Z];
            for (int t = 1; t <= project.T; t++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = t.ToString();
                column.HeaderText = "T" + t.ToString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                dataSliceAreaSets.Columns.Add(column);

                if (project.SliceAreas == null)
                {
                    int targetz = this._getTargetZ(t);
                    for (int z = 1; z <= project.Z; z++)
                    {
                        if (targetz == z)
                        {
                            sliceArea[t - 1, z - 1] = true;
                        }
                        else
                        {
                            sliceArea[t - 1, z - 1] = false;
                        }
                    }
                }
            }

            if (project.SliceAreas == null)
            {
                project.SliceAreas = sliceArea;
            }


            int target_t = 1;
            int target_z = 1;
                    
            for (int z = 1; z <= project.Z; z++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = "Z" + z.ToString();

                for (int t = 1; t <= project.T; t++)
                {
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    if (project.SliceAreas[t - 1, z - 1])
                    {
                        cell.Value = "×";
                        if (t == 1)
                        {
                            target_t = t;
                            target_z = z;
                        }
                    }
                    else
                    {
                        cell.Value = "";
                    }

                    row.Cells.Add(cell);
                }

                dataSliceAreaSets.Rows.Add(row);
            }
            
            dataSliceAreaSets.CurrentCell = dataSliceAreaSets[target_t - 1,target_z - 1];
        }

        private int _getTargetZ(int t)
        {
            MicroImage microImage;
            Tiff tif;
            int maxZ = 1;
            int maxColor = 0;

            for (int z = 1; z <= this._Project.Z; z++)
            {
                microImage = this._Analyzer.GetMicroImage(z, t, "473");

                tif = microImage.GetImage16Bit();

                FieldValue[] res = tif.GetField(TiffTag.IMAGELENGTH);
                int height = res[0].ToInt();

                res = tif.GetField(TiffTag.IMAGEWIDTH);
                int width = res[0].ToInt();

                int stride = tif.ScanlineSize();
                byte[] buffer = new byte[stride];
                //max、min取得
                int max_value = 0;
                int min_value = 65536;

                for (int i = 0; i < height; i++)
                {
                    tif.ReadScanline(buffer, i);
                    for (int src = 0, dst = 0; src < buffer.Length; dst++)
                    {
                        int value16 = buffer[src++];
                        value16 = value16 + (buffer[src++] << 8);

                        if (max_value < value16)
                        {
                            max_value = value16;
                        }
                        if (min_value > value16)
                        {
                            min_value = value16;
                        }
                    }
                }

                int color_sum = max_value - min_value;

                if (maxColor < color_sum)
                {
                    maxZ = z;
                    maxColor = color_sum;
                }
            }

            return maxZ;
        }

        private void _SetTargetValueZ()
        {
            if (dataAnalyzeAreaSets.SelectedRows.Count > 0)
            {
                DataGridViewRow s_row = dataAnalyzeAreaSets.CurrentRow;
                AnalyzeAreaSet s_analyzeAreaSet = (AnalyzeAreaSet)s_row.DataBoundItem;

                //int selectZ = this._Analyzer.GetZ(s_analyzeAreaSet, scrollT.Value);

                int selectZ = 1;
                for (int z = 1; z <= this._Project.Z; z++)
                {
                    AnalyzeArea aa = s_analyzeAreaSet.GetAnalyzeArea(z, scrollT.Value);
                    if (aa.Enabled)
                    {
                        selectZ = z;
                        break;
                    }
                }

                if (scrollZ.Maximum < selectZ) scrollZ.Maximum = selectZ;
                if (scrollZ.Minimum > selectZ) scrollZ.Minimum = selectZ;
                if (nudZ.Maximum < selectZ) nudZ.Maximum = selectZ;
                if (nudZ.Minimum > selectZ) nudZ.Minimum = selectZ;

                scrollZ.Value = selectZ;
                nudZ.Value = selectZ;

                //AnalyzeArea analyzeArea = this._GetCurrentAnalyzeArea();
                //nudThreshold.Value = analyzeArea.Threshold;

                scrollZ.Enabled = false;
                nudZ.Enabled = false;
            }
            else
            {
                scrollZ.Enabled = true;
                nudZ.Enabled = true;
            }
        }

		private void _Render()
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

			if (this._Analyzer != null)
			{
				menuProjectSave.Enabled = true;
				menuProjectSaveAs.Enabled = true;
                menuTool.Enabled = true;
                
				panel.Enabled = true;

				checkDrawArea.Enabled = dataAnalyzeAreaSets.SelectedRows.Count > 0 ? true : false;
                checkBinarize.Enabled = dataAnalyzeAreaSets.SelectedRows.Count > 0 ? true : false;
                buttonAnalyzer.Enabled = dataAnalyzeAreaSets.SelectedRows.Count > 0 ? true : false;
                nudThreshold.Enabled = dataAnalyzeAreaSets.SelectedRows.Count > 0 ? true : false;

                this._SetTargetValueZ();

				foreach (DataGridViewRow row in dataAnalyzeAreaSets.Rows)
                {
                    if (this._Project.T <= row.Cells.Count)
                    {
                        AnalyzeAreaSet analyzeAreaSet = (AnalyzeAreaSet)row.DataBoundItem;
                        row.HeaderCell.Value = analyzeAreaSet.Name;

                        for (int t = 1; t <= this._Project.T; t++)
                        {
                            int targetZ = 1;
                            for(int z = 1; z <= this._Project.Z; z++){
                                AnalyzeArea aa = analyzeAreaSet.GetAnalyzeArea(z, t);
                                if (aa.Enabled)
                                {
                                    targetZ = z;
                                    break;
                                }
                            }
                            row.Cells[t - 1].Value = analyzeAreaSet.GetAnalyzeArea(targetZ, t).ToString();
                        }
                    }
				}

                dataAnalyzeAreaSets.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                MicroImage microImage;
                if (radioButtonPic473.Checked)
                {
                    microImage = this._GetCurrentMicroImage("473");
                }
                else
                {
                    microImage = this._GetCurrentMicroImage("561");
                }

                Image image;

				if (checkBinarize.Checked == true)
				{

                    int threshold = (int)nudThreshold.Value;
                    image = microImage.GetBinarizedImage(threshold);
				}
				else
				{
                    image = microImage.GetImage();
				}

				if (checkDrawArea.Checked == true && dataAnalyzeAreaSets.SelectedRows.Count > 0)
				{
					AnalyzeArea analyzeArea = this._GetCurrentAnalyzeArea();

					if (analyzeArea.Enabled == true)
					{
                        Image tmp = new Bitmap(image.Width, image.Height);
                        Graphics g = Graphics.FromImage(tmp);
                        g.DrawImage(image, 0, 0, image.Width, image.Height);

						Pen pen = new Pen(Color.FromArgb(191, Color.LightGray));
                        g.DrawEllipse(
							pen,
							analyzeArea.X - analyzeArea.R,
							analyzeArea.Y - analyzeArea.R,
							analyzeArea.R * 2,
							analyzeArea.R * 2
                        );

                        g.Dispose();

                        image = tmp;
					}
				}

                pictureMicroImage.Image = image;

			}
			else
			{
				menuProjectSave.Enabled = false;
				menuProjectSaveAs.Enabled = false;
                menuTool.Enabled = false;
                chartSpot.Visible = false;
                buttonExportAsCSV.Enabled = false;
                buttonAnalyzer.Enabled = false;
                nudThreshold.Enabled = false;

				panel.Enabled = false;
			}

            Cursor.Current = oldCursor;
			labelStatus.Text = this._Flash;
			this._Flash = "";
		}

		private MicroImage _GetCurrentMicroImage(string type)
		{
            return this._Analyzer.GetMicroImage(scrollZ.Value, scrollT.Value, type);
		}

		private AnalyzeAreaSet _GetCurrentAnalyzeAreaSet()
		{
			DataGridViewRow row = dataAnalyzeAreaSets.SelectedRows[0];
			AnalyzeAreaSet analyzeAreaSet = (AnalyzeAreaSet)row.DataBoundItem;
			return analyzeAreaSet;
		}

		private AnalyzeArea _GetCurrentAnalyzeArea()
		{
			AnalyzeAreaSet analyzeAreaSet = this._GetCurrentAnalyzeAreaSet();
			return analyzeAreaSet.GetAnalyzeArea(scrollZ.Value, scrollT.Value);
		}

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void SetSpotChart()
        {
            DataGridViewRow row = dataAnalyzeAreaSets.CurrentRow;
            if (row == null)
            {
                return;
            }

            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            labelStatus.Text = "";

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Maximum = this._Project.T;
            toolStripProgressBar1.Minimum = 1;

            AnalyzeAreaSet analyzeAreaSet = (AnalyzeAreaSet)row.DataBoundItem;

            chartSpot.Visible = true;
            chartSpot.Series.Clear();

            //グラフ設定
            string legend473Count = "473Count";
            string legend561Count = "561Count";
            string legendIntDen = "IntDen";

            chartSpot.Series.Add(legend473Count);
            chartSpot.Series.Add(legend561Count);
            chartSpot.Series.Add(legendIntDen);

            chartSpot.Series[legend473Count].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartSpot.Series[legend561Count].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartSpot.Series[legendIntDen].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartSpot.Series[legend473Count].LegendText = legend473Count;
            chartSpot.Series[legend561Count].LegendText = legend561Count;
            chartSpot.Series[legendIntDen].LegendText = legendIntDen;

            chartSpot.Series[legend473Count].IsValueShownAsLabel = false;
            chartSpot.Series[legend473Count].SmartLabelStyle.Enabled = false;
            chartSpot.Series[legend473Count].LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartSpot.Series[legend473Count].LabelBorderWidth = 0;
            chartSpot.Series[legend473Count].LabelForeColor = Color.FromArgb(0, 0, 0, 0);

            chartSpot.Series[legend561Count].IsValueShownAsLabel = false;
            chartSpot.Series[legend561Count].SmartLabelStyle.Enabled = false;
            chartSpot.Series[legend561Count].LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartSpot.Series[legend561Count].LabelBorderWidth = 0;
            chartSpot.Series[legend561Count].LabelForeColor = Color.FromArgb(0, 0, 0, 0);

            chartSpot.Series[legendIntDen].IsValueShownAsLabel = false;
            chartSpot.Series[legendIntDen].SmartLabelStyle.Enabled = false;
            chartSpot.Series[legendIntDen].LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartSpot.Series[legendIntDen].LabelBorderWidth = 0;
            chartSpot.Series[legendIntDen].LabelForeColor = Color.FromArgb(0, 0, 0, 0);

            chartSpot.Series[legendIntDen].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            //


            string[] xValues = new string[scrollT.Maximum];
            int[] yValues473Count = new int[scrollT.Maximum];
            int[] yValues561Count = new int[scrollT.Maximum];
            int[] yValuesIntDen = new int[scrollT.Maximum];

            for (int t = 1; t <= this._Project.T; t++)
            {
                xValues[t-1] = t.ToString();
                
                double[] spots = this._Analyzer.AnalyzeSpot(analyzeAreaSet, t, (int)nudThreshold.Value);

                yValues473Count[t - 1] = (int)spots[0];
                yValues561Count[t - 1] = (int)spots[1];
                yValuesIntDen[t - 1] = (int)spots[2];

                toolStripProgressBar1.Value = t;
                toolStripProgressBar1.PerformStep();
            }
            Spot spot = new Spot();
            spot._setCount473(yValues473Count);
            spot._setCount561(yValues561Count);
            spot._setIntDen(yValuesIntDen);
            this._Spot = spot;

            for (int i = 0; i < xValues.Length; i++)
            {
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp473Count = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp561Count = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                System.Windows.Forms.DataVisualization.Charting.DataPoint dpIntDen = new System.Windows.Forms.DataVisualization.Charting.DataPoint();

                dp473Count.SetValueXY(xValues[i], yValues473Count[i]);
                dp561Count.SetValueXY(xValues[i], yValues561Count[i]);
                dpIntDen.SetValueXY(xValues[i], yValuesIntDen[i]);

                dp473Count.IsValueShownAsLabel = true;
                dp561Count.IsValueShownAsLabel = true;
                dpIntDen.IsValueShownAsLabel = true;

                chartSpot.Series["473Count"].Points.Add(dp473Count);
                chartSpot.Series["561Count"].Points.Add(dp561Count);
                chartSpot.Series["IntDen"].Points.Add(dpIntDen); 
            }

            toolStripProgressBar1.Visible = false;
            Cursor.Current = oldCursor;
            labelStatus.Text = "解析が完了しました";
            this._Flash = "";

            buttonExportAsCSV.Enabled = true;
        }

        private void buttonAnalyzer_Click(object sender, EventArgs e)
        {
            this.SetSpotChart();
        }

        private void radioButtonPic561_CheckedChanged(object sender, EventArgs e)
        {
            this._Render();
        }

        private void radioButtonPic473_CheckedChanged(object sender, EventArgs e)
        {
            this._Render();
        }
	}
}
