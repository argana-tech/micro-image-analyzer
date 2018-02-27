using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using BitMiracle.LibTiff.Classic;

namespace MicroImageAnalyzer
{
	public class MicroImage
	{
		public string File;
		public int C;
		public int Z;
		public int T;

		private Image _Image = null;
        private Bitmap _BinarizedImage = null;
		private int _BinarizedImageThreshold;

		public MicroImage(string file, int c, int z, int t)
		{
			this.File = file;
			this.C = c;
			this.Z = z;
			this.T = t;
		}

        public Tiff GetImage16Bit()
        {
            Tiff _image16Bit = Tiff.Open(this.File, "r");

            return _image16Bit;
        }

		public Image GetImage()
		{
			if (this._Image != null)
			{
				return (Image)this._Image.Clone();
			}

            Tiff tif = Tiff.Open(this.File, "r");
            Bitmap tiff8bit = getBitmap8Bit(tif);
            tif.Dispose();

            this._Image = tiff8bit;

            return (Image)this._Image.Clone();
            //
            //Image image = Image.FromFile(this.File);
            //this._Image = image;

            //return (Image)this._Image.Clone();
		}

        private static Bitmap getBitmap8Bit(Tiff tif)
        {
            FieldValue[] res = tif.GetField(TiffTag.IMAGELENGTH);
            int height = res[0].ToInt();

            res = tif.GetField(TiffTag.IMAGEWIDTH);
            int width = res[0].ToInt();

            int stride = tif.ScanlineSize();
            byte[] buffer = new byte[stride];

            Bitmap result = new Bitmap(width, height);

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
            //main
            for (int i = 0; i < height; i++)
            {
                Rectangle imgRect = new Rectangle(0, i, width, 1);

                tif.ReadScanline(buffer, i);

                //convert
                for (int src = 0, dst = 0; src < buffer.Length; dst++)
                {
                    int value16 = buffer[src++];
                    value16 = value16 + (buffer[src++] << 8);
                    //buffer8Bit[dst] = (byte)(value16 / 257.0 + 0.5);
                    double percent = (double)255 / ((double)max_value - (double)min_value);
                    double pixel_data = ((double)value16 - (double)min_value) * percent;

                    value16 = (int)pixel_data;

                    if (value16 > 255)
                    {
                        value16 = 255;
                    }
                    Color color = Color.FromArgb(255, value16, value16, value16);   //
                    result.SetPixel((int)dst, i, color);    //
                }
            }

            return result;
        }

		public Bitmap GetBinarizedImage(int threshold)
		{
			if (this._BinarizedImage != null && this._BinarizedImageThreshold == threshold)
			{
				return (Bitmap)this._BinarizedImage.Clone();
			}

            Bitmap bitmap = new Bitmap(this.GetImage());
            Tiff tif = GetImage16Bit();

            int stride = tif.ScanlineSize();
            byte[] buffer = new byte[stride];

            for (int y = 0; y < bitmap.Height; y++)
            {
                Rectangle imgRect = new Rectangle(0, y, bitmap.Width, 1);

                tif.ReadScanline(buffer, y);

                //convert
                for (int src = 0, dst = 0; src < buffer.Length; dst++)
                {
                    int value16 = buffer[src++];
                    value16 = value16 + (buffer[src++] << 8);
                    if (value16 <= threshold)
                    {
                        bitmap.SetPixel(dst, y, Color.Black);
                    }
                    else
                    {
                        bitmap.SetPixel(dst, y, Color.White);
                    }
                }
            }

            this._BinarizedImage = bitmap;
            this._BinarizedImageThreshold = threshold;

            return (Bitmap)bitmap.Clone();
		}

        public double AnalyzeSpot(AnalyzeArea analyzeArea, int threshold)
        {
            double return_data = 0;

            if (analyzeArea.Enabled == false)
            {
                return return_data;
            }

            Bitmap image = this.GetBinarizedImage(threshold);
            Bitmap analyzeAreaImage = analyzeArea.GetImage(image.Width, image.Height);

            int startX = analyzeArea.X - analyzeArea.R - 1;
            startX = startX < 0 ? 0 : startX;

            int endX = analyzeArea.X + analyzeArea.R + 1;
            endX = endX > image.Width ? image.Width : endX;

            int startY = analyzeArea.Y - analyzeArea.R - 1;
            startY = startY < 0 ? 0 : startY;

            int endY = analyzeArea.Y + analyzeArea.R + 1;
            endY = endY > image.Height ? image.Height : endY;

            ConnectedComponents components = ConnectedComponents.Analyze(image);
            Dictionary<int, int> labels = new Dictionary<int, int>();

            //選択部分の取得
            Bitmap imageEllipse = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(imageEllipse);
            g.Clear(Color.Black);
            g.FillEllipse(Brushes.White, analyzeArea.X - analyzeArea.R, analyzeArea.Y - analyzeArea.R, analyzeArea.R * 2, analyzeArea.R * 2);
            g.Dispose();

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    int label = components.Labels[x, y];
                    Color color = imageEllipse.GetPixel(x, y);

                    if (label <= 0 || (color.R == 0 && color.G == 0 && color.B == 0))
                    {
                        continue;
                    }

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

            return labels.Count;
        }

        private bool CheckColor(Color area)
        {
            if (area.R == 255 && area.G == 255 && area.B == 255)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

		public int AnalyzeArea(AnalyzeArea analyzeArea)
		{
			if (analyzeArea.Enabled == false)
			{
				return 0;
			}

			Bitmap image = new Bitmap(this.GetImage());
			Bitmap analyzeAreaImage = analyzeArea.GetImage(image.Width, image.Height);

			int pixels = 0;

			int startX = analyzeArea.X - analyzeArea.R - 1;
			startX = startX < 0 ? 0 : startX;

			int endX = analyzeArea.X + analyzeArea.R + 1;
			endX = endX > image.Width ? image.Width : endX;

			int startY = analyzeArea.Y - analyzeArea.R - 1;
			startY = startY < 0 ? 0 : startY;

			int endY = analyzeArea.Y + analyzeArea.R + 1;
			endY = endY > image.Height ? image.Height : endY;

			for (int x = startX; x < endX; x++)
			{
				for (int y = startY; y < endY; y++)
				{
					Color analyzeAreaColor = analyzeAreaImage.GetPixel(x, y);

					if (analyzeAreaColor.R == 255 && analyzeAreaColor.G == 255 && analyzeAreaColor.B == 255)
					{
						Color color = image.GetPixel(x, y);
						int average = (int)((color.R + color.G + color.B) / 3);

						if (average > analyzeArea.Threshold)
						{
							pixels++;
						}
					}
				}
			}

			return pixels;
		}

        public double AnalyzeLuminance(AnalyzeArea analyzeArea, int threshold)
        {
            if (analyzeArea.Enabled == false)
            {
                return 0;
            }
            Bitmap image = this.GetBinarizedImage(threshold);
            //Bitmap analyzeAreaImage = analyzeArea.GetImage(image.Width, image.Height);

            Tiff tif = this.GetImage16Bit();

            int stride = tif.ScanlineSize();
            byte[] buffer = new byte[stride];
            //for (int i = 0; i < image.Height; i++)
            //{
            //    tif.ReadScanline(buffer, i);
            //    for (int src = 0, dst = 0; src < buffer.Length; dst++)
            //    {
            //        int value16 = buffer[src++];
            //        value16 = value16 + (buffer[src++] << 8);
            //    }
            //}

            double luminance = 0;

            int startX = analyzeArea.X - analyzeArea.R - 1;
            startX = startX < 0 ? 0 : startX;

            int endX = analyzeArea.X + analyzeArea.R + 1;
            endX = endX > image.Width ? image.Width : endX;

            int startY = analyzeArea.Y - analyzeArea.R - 1;
            startY = startY < 0 ? 0 : startY;

            int endY = analyzeArea.Y + analyzeArea.R + 1;
            endY = endY > image.Height ? image.Height : endY;

            //選択部分の取得
            Bitmap imageEllipse = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(imageEllipse);
            g.Clear(Color.Black);
            g.FillEllipse(Brushes.White, analyzeArea.X - analyzeArea.R, analyzeArea.Y - analyzeArea.R, analyzeArea.R * 2, analyzeArea.R * 2);
            g.Dispose();

            for (int y = startY; y < endY; y++)
            {
                tif.ReadScanline(buffer, y);
                for (int x = startX; x < endX; x++)
                {
                    Color analyzeAreaColor = image.GetPixel(x, y);
                    Color ellipseColor = imageEllipse.GetPixel(x, y);

                    if (analyzeAreaColor.R == 255 && analyzeAreaColor.G == 255 && analyzeAreaColor.B == 255 && ellipseColor.R == 255 && ellipseColor.G == 255 && ellipseColor.B == 255)
                    {
                        int src = x * 2;
                        int value16 = buffer[src++];
                        value16 = value16 + (buffer[src++] << 8);
                        luminance += value16;
                    }
                }
            }
            return luminance;
        }
	}
}
