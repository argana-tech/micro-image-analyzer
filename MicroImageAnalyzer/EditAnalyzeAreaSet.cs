using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using BitMiracle.LibTiff.Classic;

namespace MicroImageAnalyzer
{
	public partial class EditAnalyzeAreaSet : Form
	{
		private Project _Project;
		private Analyzer _Analyzer;

		public string EditMode = "";
		public AnalyzeAreaSet AnalyzeAreaSet;
		public bool CreatedAnalyzeAreaSet = false;
		public bool UpdatedAnalyzeAreaSet = false;

        private Image defaultMoveImage = null;
		private string _Flash;

		public EditAnalyzeAreaSet(Project project, int currentZ, int currentT)
		{
			this.EditMode = "Create";

			AnalyzeAreaSet analyzeAreaSet = new AnalyzeAreaSet(project.Z, project.T);
			this._Initialize(analyzeAreaSet, project, currentZ, currentT);
		}

		public EditAnalyzeAreaSet(AnalyzeAreaSet analyzeAreaSet, Project project, int currentZ, int currentT)
		{
			this.EditMode = "Update";

			this._Initialize(analyzeAreaSet, project, currentZ, currentT);
		}
        
		private void pictureMicroImage_MouseMove(object sender, MouseEventArgs e)
        {
            this._RenderMicroImageMove();

            int x = (e.X * this._Project.X) / pictureMicroImage.Width;
            int y = (e.Y * this._Project.Y) / pictureMicroImage.Height;
            int r = (int)nudR.Value;

            if (checkEnabled.Checked == true)
            {
                Image src = pictureMicroImage.Image;
                Image image = new Bitmap(src.Width, src.Height);

                Graphics g = Graphics.FromImage(image);
                g.DrawImage(src, 0, 0, src.Width, src.Height);

                Pen pen = new Pen(Color.FromArgb(95, Color.LightGray), this._Project.X / 200);
                g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);

                g.Dispose();

                pictureMicroImage.Image = image;
            }

            labelPointX.Text = x.ToString();
            labelPointY.Text = y.ToString();
		}

		private void pictureMicroImage_MouseLeave(object sender, EventArgs e)
        {
            defaultMoveImage = null;

            this._RenderMicroImage();
            labelPointX.Text = "";
            labelPointY.Text = "";
		}

		private void pictureMicroImage_MouseClick(object sender, MouseEventArgs e)
        {
            defaultMoveImage = null;

            this._ClearCurrentAnalyzeArea();
            int x = (e.X * this._Project.X) / pictureMicroImage.Width;
            int y = (e.Y * this._Project.Y) / pictureMicroImage.Height;

            nudX.Value = x;
            nudY.Value = y;

            this._SetCurrentAnalyzeArea();
		}

		private void dataAnalyzeAreas_SelectionChanged(object sender, EventArgs e)
		{
			DataGridViewCell cell = dataAnalyzeAreas.SelectedCells[0];
			nudT.Value = cell.ColumnIndex + 1;

			this.checkEnabled.CheckedChanged -= new System.EventHandler(this.checkEnabled_CheckedChanged);
			this.nudX.ValueChanged -= new System.EventHandler(this.nudX_ValueChanged);
			this.nudY.ValueChanged -= new System.EventHandler(this.nudY_ValueChanged);
			this.nudR.ValueChanged -= new System.EventHandler(this.nudR_ValueChanged);
			this.nudThreshold.ValueChanged -= new System.EventHandler(this.nudThreshold_ValueChanged);

			AnalyzeArea analyzeArea = this._GetCurrentAnalyzeArea();
			checkEnabled.Checked = analyzeArea.Enabled;
			nudX.Value = analyzeArea.X == -1 ? 0 : analyzeArea.X;
            nudY.Value = analyzeArea.Y == -1 ? 0 : analyzeArea.Y;
            nudR.Value = analyzeArea.R == 0 ? this._Project.X * Project.DefaultR / 100 : analyzeArea.R;
            //nudR.Value = analyzeArea.R == 0 ? Project.DefaultR : analyzeArea.R;
			nudThreshold.Value = analyzeArea.Threshold == 0 ? Project.DefaultThreshold : analyzeArea.Threshold;

			this.checkEnabled.CheckedChanged += new System.EventHandler(this.checkEnabled_CheckedChanged);
			this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
			this.nudY.ValueChanged += new System.EventHandler(this.nudY_ValueChanged);
			this.nudR.ValueChanged += new System.EventHandler(this.nudR_ValueChanged);
			this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
		}

		private void scrollT_Scroll(object sender, ScrollEventArgs e)
		{
			nudT.Value = scrollT.Value;
		}

		private void nudT_ValueChanged(object sender, EventArgs e)
		{
			scrollT.Value = (int)nudT.Value;
			dataAnalyzeAreas[scrollT.Value - 1, 0].Selected = true;
			this._Render();
		}

		private void checkBinarize_CheckedChanged(object sender, EventArgs e)
		{
			this._Render();
		}

		private void checkEnabled_CheckedChanged(object sender, EventArgs e)
        {

            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this._ClearCurrentAnalyzeArea();

            this._SetCurrentAnalyzeArea();
            this._Render();

            Cursor.Current = oldCursor;
		}

		private void nudX_ValueChanged(object sender, EventArgs e)
		{
			this._SetCurrentAnalyzeArea();
			this._Render();
		}

		private void nudY_ValueChanged(object sender, EventArgs e)
		{
			this._SetCurrentAnalyzeArea();
			this._Render();
		}

		private void nudR_ValueChanged(object sender, EventArgs e)
		{
			this._SetCurrentAnalyzeArea();
			this._Render();
		}

		private void nudThreshold_ValueChanged(object sender, EventArgs e)
		{
			this._SetCurrentAnalyzeArea();
			this._Render();
		}

        private void buttonFill_Click(object sender, EventArgs e)
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            int t = scrollT.Value;

            FillSource source = this._GetCurrentFillSource();
            int threshold = (int)nudThreshold.Value;

            for (int tw = 1; tw <= this._Project.T; tw++)
            {
                this._ClearCurrentAnalyzeArea(tw);
                source = this._Fill(this._getTargetZ(tw), tw, source, threshold);
            }

            nudT.Value = t;
            Cursor.Current = oldCursor;
        }

        private int _getTargetZ(int t)
        {
            int tarZ = 1;
            Boolean[,] area = this._Project.SliceAreas;

            for (int z = 1; z <= this._Project.Z; z++)
            {
                if (area[t-1, z-1])
                {
                    tarZ = z;
                    break;
                }
            }

            return tarZ;
        }

		private FillSource _Fill(int z, int t, FillSource source, int threshold)
		{
            MicroImage microImage = this._Analyzer.GetMicroImage(z, t, "473");
            //MicroImage microImage561 = this._Analyzer.GetMicroImage(z, t, "561");
            Bitmap image = microImage.GetBinarizedImage(threshold);
            //Bitmap image561 = microImage561.GetBinarizedImage(threshold);

            ConnectedComponents components = ConnectedComponents.Analyze(image);
            //ConnectedComponents components561 = ConnectedComponents.Analyze(image561);

			Dictionary<int, int> labels = new Dictionary<int, int>();

            int sMinX = (source.MinX < 1) ? 0 : source.MinX;
            int sMaxX = (source.MaxX < 1) ? 0 : source.MaxX;
            int sMinY = (source.MinY < 1) ? 0 : source.MinY;
            int sMaxY = (source.MaxY < 1) ? 0 : source.MaxY;

			if (source.Label > 0)
			{
                for (int x = sMinX; x <= sMaxX; x++)
				{
                    for (int y = sMinY; y <= sMaxY; y++)
					{
						int label = components.Labels[x, y];

						if (label <= 0)
						{
							continue;
						}

						if (source.Components.Labels[x, y] == source.Label)
						{
							if (labels.ContainsKey(label))
							{
								labels[label]++;
							}
							else
							{
								labels[label] = 1;
							}
						}
					}
				}
			}

			int max = 0;

			foreach (KeyValuePair<int, int> label in labels)
			{
				if (max == 0)
				{
					max = label.Key;
				}
				else if (label.Value >= labels[max]) // TODO: 等しい場合の処理 中心が近いものなど
				{
					max = label.Key;
				}
			}

			nudT.Value = t;

			FillSource newSource = new FillSource(components, max);

			if (max == 0)
			{
				checkEnabled.Checked = false;
			}
			else
			{
				int xLength = newSource.MaxX - newSource.MinX;
				int yLength = newSource.MaxY - newSource.MinY;
				int longer = xLength > yLength ? xLength : yLength;

				checkEnabled.Checked = true;
				nudX.Value = newSource.MinX + (int)(xLength / 2);
                nudY.Value = newSource.MinY + (int)(yLength / 2);

                if (nudR.Maximum < ((int)(longer / 2) + 3))
                {
                    nudR.Value = nudR.Maximum;
                }
                else
                {
                    nudR.Value = (int)(longer / 2) + 3; // TODO: 3 shold be defined some where else.
                }
				
                nudThreshold.Value = threshold;
			}

            ////*************************** SPOT 解析 ***************************


            ////選択部分の取得
            //Bitmap imageEllipse = new Bitmap(image.Width, image.Height);
            //Graphics g = Graphics.FromImage(imageEllipse);
            //g.Clear(Color.Black);
            //g.FillEllipse(Brushes.White, (int)nudX.Value - (int)nudR.Value, (int)nudY.Value - (int)nudR.Value, (int)nudR.Value * 2, (int)nudR.Value * 2);
            //g.Dispose();

            //Dictionary<int, int> spotlabels = new Dictionary<int, int>();
            //Dictionary<int, int> spotlabels561 = new Dictionary<int, int>();

            //int startX = (int)nudX.Value - (int)nudR.Value - 1;
            //startX = startX < 0 ? 0 : startX;

            //int endX = (int)nudX.Value + (int)nudR.Value + 1;
            //endX = endX > image.Width ? image.Width : endX;

            //int startY = (int)nudY.Value - (int)nudR.Value - 1;
            //startY = startY < 0 ? 0 : startY;

            //int endY = (int)nudY.Value + (int)nudR.Value + 1;
            //endY = endY > image.Height ? image.Height : endY;

            //for (int x = startX; x < endX; x++)
            //{
            //    for (int y = startY; y < endY; y++)
            //    {
            //        int label = components.Labels[x, y];
            //        Color color = imageEllipse.GetPixel(x, y);

            //        if (label <= 0 || (color.R == 0 && color.G == 0 && color.B == 0))
            //        {
            //            continue;
            //        }

            //        if (spotlabels.ContainsKey(label))
            //        {
            //            spotlabels[label]++;
            //        }
            //        else
            //        {
            //            spotlabels[label] = 1;
            //        }
            //    }
            //}

            //for (int x = startX; x < endX; x++)
            //{
            //    for (int y = startY; y < endY; y++)
            //    {
            //        int label = components561.Labels[x, y];
            //        Color color = imageEllipse.GetPixel(x, y);

            //        if (label <= 0 || (color.R == 0 && color.G == 0 && color.B == 0))
            //        {
            //            continue;
            //        }

            //        if (spotlabels561.ContainsKey(label))
            //        {
            //            spotlabels561[label]++;
            //        }
            //        else
            //        {
            //            spotlabels561[label] = 1;
            //        }
            //    }
            //}
            //nudCount473.Value = spotlabels.Count;
            //nudCount561.Value = spotlabels561.Count;
            ////**************************************************

            this._SetCurrentAnalyzeArea();

			return newSource;
		}

		private FillSource _GetCurrentFillSource()
		{
			AnalyzeArea analyzeArea = this._GetCurrentAnalyzeArea();
			Bitmap analyzeAreaImage = analyzeArea.GetImage(this._Project.X, this._Project.Y);

			int[,] labels = new int[analyzeAreaImage.Width, analyzeAreaImage.Height];

			for (int x = 0; x < analyzeAreaImage.Width; x++)
			{
				for (int y = 0; y < analyzeAreaImage.Height; y++)
				{
					Color color = analyzeAreaImage.GetPixel(x, y);
					if (color.R == 255 && color.G == 255 && color.B == 255)
					{
						labels[x, y] = 1;
					}
					else
					{
						labels[x, y] = 0;
					}
				}
			}

			ConnectedComponents components = new ConnectedComponents(labels, 1);

			return new FillSource(components, 1);
		}

		private void textName_TextChanged(object sender, EventArgs e)
		{
			this._SetCurrentAnalyzeArea();
			this._Render();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (this.AnalyzeAreaSet.IsValid())
			{
				if (this.EditMode == "Create")
				{
					this.CreatedAnalyzeAreaSet = true;
				}
				else
				{
					this.UpdatedAnalyzeAreaSet = true;
				}

				this.Close();
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void _Initialize(AnalyzeAreaSet analyzeAreaSet, Project project, int currentZ, int currentT)
		{
			InitializeComponent();

			if (this.EditMode == "Create")
			{
				this.Text = "解析エリアを追加";
				buttonOK.Text = "追加";
			}
			else
			{
				this.Text = "解析エリアを編集";
				buttonOK.Text = "保存";
			}

			this._Project = project;
			this.AnalyzeAreaSet = analyzeAreaSet;

			// initialize dataAnalyzeAreas
			for (int t = 1; t <= project.T; t++)
			{
				DataGridViewColumn column = new DataGridViewTextBoxColumn();
				column.Name = t.ToString();
				column.HeaderText = "T" + t.ToString();
				column.SortMode = DataGridViewColumnSortMode.NotSortable;

				dataAnalyzeAreas.Columns.Add(column);
			}

            DataGridViewRow row = new DataGridViewRow();
            row.HeaderCell.Value = "AREA";

            for (int t = 1; t <= project.T; t++)
            {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = this.AnalyzeAreaSet.GetAnalyzeArea(this._getTargetZ(t), t).ToString();
                row.Cells.Add(cell);
            }

            dataAnalyzeAreas.Rows.Add(row);

			// initialize comboC

            if (project.C >= 1)
            {
                this._Analyzer = this._Project.GetAnalyzer(1);
                this._Render();
            }

			// initialize scrolls, nuds
			scrollT.Minimum = 1;
			scrollT.Maximum = project.T;
			nudT.Minimum = 1;
			nudT.Maximum = project.T;

			int smaller = project.X > project.Y ? project.Y : project.X;

			nudX.Minimum = 0;
			nudX.Maximum = project.X - 1;
			nudY.Minimum = 0;
			nudY.Maximum = project.Y - 1;
			nudR.Minimum = 1;
			nudR.Maximum = Math.Floor((decimal)(smaller / 2));
			nudThreshold.Minimum = 0;
			nudThreshold.Maximum = 65535;


			pictureMicroImage.MouseMove += new MouseEventHandler(pictureMicroImage_MouseMove);
			pictureMicroImage.MouseLeave += new EventHandler(pictureMicroImage_MouseLeave);
			pictureMicroImage.MouseClick += new MouseEventHandler(pictureMicroImage_MouseClick);
			dataAnalyzeAreas.SelectionChanged += new EventHandler(dataAnalyzeAreas_SelectionChanged);

			nudT.Value = currentT;

			dataAnalyzeAreas[currentT - 1, 0].Selected = true;

			textName.Text = analyzeAreaSet.Name;

			this._Render();
		}

		private void _Render()
		{
			buttonOK.Enabled = this.AnalyzeAreaSet.IsValid() ? true : false;

			this._RenderMicroImage();

			labelStatus.Text = this._Flash;
			this._Flash = "";
		}

		private void _RenderMicroImage()
        {
            MicroImage microImage = radioButtonPic473.Checked ? this._GetCurrentMicroImage("473") : this._GetCurrentMicroImage("561");
            
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

            if (checkEnabled.Checked == true && nudX.Value > 0 && nudY.Value > 0 && nudR.Value > 0)
            {
                int x = (int)nudX.Value;
                int y = (int)nudY.Value;
                int r = (int)nudR.Value;

                Image tmp = new Bitmap(image.Width, image.Height);
                Graphics g = Graphics.FromImage(tmp);
                g.DrawImage(image, 0, 0, image.Width, image.Height);

                Pen pen = new Pen(Color.FromArgb(191, Color.LightGray), this._Project.X / 200);
                g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
                g.Dispose();

                image = tmp;
            }

			pictureMicroImage.Image = image;
		}

        private void _RenderMicroImageMove()
        {
            MicroImage microImage = radioButtonPic473.Checked ? this._GetCurrentMicroImage("473") : this._GetCurrentMicroImage("561");

            Image image;

            if (defaultMoveImage == null)
            {
                if (checkBinarize.Checked == true)
                {
                    int threshold = (int)nudThreshold.Value;
                    image = microImage.GetBinarizedImage(threshold);
                }
                else
                {
                    image = microImage.GetImage();
                }

                if (checkEnabled.Checked == true && nudX.Value > 0 && nudY.Value > 0 && nudR.Value > 0)
                {
                    int x = (int)nudX.Value;
                    int y = (int)nudY.Value;
                    int r = (int)nudR.Value;

                    Image tmp = new Bitmap(image.Width, image.Height);
                    Graphics g = Graphics.FromImage(tmp);
                    g.DrawImage(image, 0, 0, image.Width, image.Height);

                    Pen pen = new Pen(Color.FromArgb(191, Color.LightGray), this._Project.X / 200);
                    g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
                    g.Dispose();

                    image = tmp;
                }
                defaultMoveImage = (Image)image.Clone();
            }
            else
            {
                image = defaultMoveImage;
            }
            pictureMicroImage.Image = image;
        }

		private MicroImage _GetCurrentMicroImage(string type)
        {
            return this._Analyzer.GetMicroImage(this._getTargetZ(scrollT.Value), scrollT.Value, type);
		}

		private void _SetCurrentAnalyzeArea()
		{
			AnalyzeArea analyzeArea = this._GetCurrentAnalyzeArea();
			this.AnalyzeAreaSet.Name = textName.Text;
			analyzeArea.Enabled = checkEnabled.Checked;
			analyzeArea.X = (int)nudX.Value;
			analyzeArea.Y = (int)nudY.Value;
			analyzeArea.R = (int)nudR.Value;
            analyzeArea.Threshold = (int)nudThreshold.Value;

			DataGridViewCell cell = dataAnalyzeAreas[scrollT.Value - 1, 0];
			cell.Value = analyzeArea.ToString();
		}

        private void _ClearCurrentAnalyzeArea(int t = 0)
        {
            if (t == 0)
            {
                t = scrollT.Value;
            }

            for (int z = 1; z <= this._Project.Z; z++)
            {
                AnalyzeArea analyzeArea = this.AnalyzeAreaSet.GetAnalyzeArea(z, t);
                this.AnalyzeAreaSet.Name = textName.Text;
                analyzeArea.Enabled = false;
                analyzeArea.X = -1;
                analyzeArea.Y = -1;
                analyzeArea.R = 0;
                analyzeArea.Threshold = 0;
            }
        }

		private AnalyzeArea _GetCurrentAnalyzeArea()
		{
            return this.AnalyzeAreaSet.GetAnalyzeArea(this._getTargetZ(scrollT.Value), scrollT.Value);
		}

        private void EditAnalyzeAreaSet_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonPix473_CheckedChanged(object sender, EventArgs e)
        {
            this._Render();
        }

        private void radioButtonPic561_CheckedChanged(object sender, EventArgs e)
        {
            this._Render();
        }
	}


	public class FillSource
	{
		public ConnectedComponents Components;
		public int Label;

		public FillSource(ConnectedComponents components, int label)
		{
			this.Components = components;
			this.Label = label;
		}

		public int MinX
		{
			get
			{
				return this.Components.GetMinXOf(this.Label);
			}
		}

		public int MaxX
		{
			get
			{
				return this.Components.GetMaxXOf(this.Label);
			}
		}

		public int MinY
		{
			get
			{
				return this.Components.GetMinYOf(this.Label);
			}
		}

		public int MaxY
		{
			get
			{
				return this.Components.GetMaxYOf(this.Label);
			}
		}
	}
}
