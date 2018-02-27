using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace MicroImageAnalyzer
{
	public class ConnectedComponents
	{
		public int[,] Labels;
		public int Count;

		public ConnectedComponents(int[,] labels, int count)
		{
			this.Labels = labels;
			this.Count = count;
		}

		public int X
		{
			get
			{
				return this.Labels.GetLength(0);
			}
		}

		public int Y
		{
			get
			{
				return this.Labels.GetLength(1);
			}
		}

		public int GetMinXOf(int label)
		{
			int min = -1;

			for (int y = 0; y < this.Y; y++)
			{
				for (int x = 0; x < this.X; x++)
				{
					if (this.Labels[x, y] == label)
					{
						if (min == -1 || x <= min)
						{
							min = x;
						}
					}
				}
			}

			return min;
		}

		public int GetMaxXOf(int label)
		{
			int max = -1;

			for (int y = 0; y < this.Y; y++)
			{
				for (int x = 0; x < this.X; x++)
				{
					if (this.Labels[x, y] == label)
					{
						if (max == -1 || x >= max)
						{
							max = x;
						}
					}
				}
			}

			return max;
		}

		public int GetMinYOf(int label)
		{
			int min = -1;

			for (int y = 0; y < this.Y; y++)
			{
				for (int x = 0; x < this.X; x++)
				{
					if (this.Labels[x, y] == label)
					{
						if (min == -1 || y <= min)
						{
							min = y;
						}
					}
				}
			}

			return min;
		}

		public int GetMaxYOf(int label)
		{
			int max = -1;

			for (int y = 0; y < this.Y; y++)
			{
				for (int x = 0; x < this.X; x++)
				{
					if (this.Labels[x, y] == label)
					{
						if (max == -1 || y >= max)
						{
							max = y;
						}
					}
				}
			}

			return max;
		}

		public static ConnectedComponents Analyze(Bitmap bitmap)
		{
			int[,] labels = new int[bitmap.Width, bitmap.Height];

			int labelCount = 1;

			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					Color color = bitmap.GetPixel(x, y);

					if (color.R == 255 && color.G == 255 && color.B == 255)
					{
						int leftLabel = x > 0 ? labels[x - 1, y] : 0;
						int upLabel = y > 0 ? labels[x, y - 1] : 0;

                        //int leftupLabel = 0;
                        //if (x > 0 && y > 0)
                        //{
                        //    leftupLabel = labels[x - 1, y - 1];   
                        //}
                        //else if (x > 0)
                        //{
                        //    leftupLabel = labels[x - 1, y];
                        //}
                        //else if (y > 0)
                        //{
                        //    leftupLabel = labels[x, y - 1];
                        //}

                        if (x > 0 && leftLabel > 0 && y > 0 && upLabel > 0 && leftLabel != upLabel)
						{
							if (leftLabel < upLabel)
							{
								labels[x, y] = leftLabel;
								_FixLabels(labels, upLabel, leftLabel, x, y);
							}
							else
							{
								labels[x, y] = upLabel;
								_FixLabels(labels, leftLabel, upLabel, x, y);
							}
						}
                        //else if (x > 0 && y > 0 && leftupLabel > 0)
                        //{
                        //    labels[x, y] = leftupLabel;
                        //}
                        else if (x > 0 && leftLabel > 0)
                        {
                            labels[x, y] = leftLabel;
                        }
                        else if (y > 0 && upLabel > 0)
                        {
                            labels[x, y] = upLabel;
                        }
                        else
                        {
                            labels[x, y] = labelCount++;
                        }
					}
				}
			}

			int fixedCount = 1;
			Dictionary<int, int> labeled = new Dictionary<int, int>();

			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					int label = labels[x, y];

					if (label == 0)
					{
						continue;
					}

					if (!labeled.ContainsKey(label))
					{
						labeled[label] = fixedCount++;
					}

					labels[x, y] = labeled[label];
				}
			}

			return new ConnectedComponents(labels, labeled.Count);
		}

		public static void _FixLabels(int[,] labels, int from, int to, int maxX, int maxY)
		{
			for (int y = 0; y < labels.GetLength(1); y++)
			{
				for (int x = 0; x < labels.GetLength(0); x++)
				{
					if (y >= maxY && x >= maxX)
					{
						break;
					}

					if (labels[x, y] == from)
					{
						labels[x, y] = to;
					}
				}
			}
		}
	}
}
