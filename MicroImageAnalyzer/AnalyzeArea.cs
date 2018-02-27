using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace MicroImageAnalyzer
{
	[Serializable()]
	public class AnalyzeArea
	{
		public bool Enabled;
		public int X;
		public int Y;
		public int R;
		public int Threshold;
        
		private int _CachedX;
		private int _CachedY;
		private string _CachedString;
		private Bitmap _CachedImage;

		public AnalyzeArea()
		{
            this.SetAttributes(true, -1, -1, 0, 0);
		}

        public AnalyzeArea(bool enabled, int x, int y, int r, int threshold)
		{
            this.SetAttributes(enabled, x, y, r, threshold);
		}

        public void SetAttributes(bool enabled, int x, int y, int r, int threshold)
		{
			this.Enabled = enabled;
			this.X = x;
			this.Y = y;
            this.R = r;
            this.Threshold = threshold;
		}

		public void SetFromAnalyzeArea(AnalyzeArea analyzeArea)
		{
			this.SetAttributes(
				analyzeArea.Enabled,
				analyzeArea.X,
				analyzeArea.Y,
				analyzeArea.R,
				analyzeArea.Threshold
			);
		}

		public Bitmap GetImage(int x, int y)
		{
			if (this._CachedImage != null && x == this._CachedX && y == this._CachedY && this.ToString() == this._CachedString)
			{
				return (Bitmap)this._CachedImage.Clone();
			}

			Bitmap image = new Bitmap(x, y);

			Graphics g = Graphics.FromImage(image);
			g.Clear(Color.Black);
			g.FillEllipse(Brushes.White, this.X - this.R, this.Y - this.R, this.R * 2, this.R * 2);
			g.Dispose();

			this._CachedImage = image;
			this._CachedX = x;
			this._CachedY = y;
			this._CachedString = this.ToString();

			return (Bitmap)image.Clone();
		}

		public bool IsValid()
		{
			if (this.Enabled == false)
			{
				return true;
			}

			if (this.X == -1)
			{
				return false;
			}

			if (this.Y == -1)
			{
				return false;
			}

			if (this.R == 0)
			{
				return false;
			}

			if (this.Threshold == 0)
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
			if (this.Enabled == false)
			{
				return "-";
			}

			string x = this.X == -1 ? "-" : this.X.ToString();
			string y = this.Y == -1 ? "-" : this.Y.ToString();
			string r = this.R == 0 ? "-" : this.R.ToString();
			string threshold = this.Threshold == 0 ? "-" : this.Threshold.ToString();

			return string.Format("X{0}, Y{1}, R{2}, T{3}", x, y, r, threshold);
		}
	}
}
