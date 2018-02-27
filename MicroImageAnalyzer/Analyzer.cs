using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.IO;

namespace MicroImageAnalyzer
{
	public class Analyzer
	{
		private Project _Project;
		public int C;
        public MicroImage[,] MicroImages;
        public MicroImage[,] MicroImages561;

		public Analyzer(Project project, int c)
		{
			this._Project = project;
			this.C = c;

            MicroImage[,] microImages = new MicroImage[this._Project.Z, this._Project.T];
            MicroImage[,] microImages561 = new MicroImage[this._Project.Z, this._Project.T];

			for (int z = 1; z <= this._Project.Z; z++)
			{
				for (int t = 1; t <= this._Project.T; t++)
				{
                    string file = this._Project.GetImageFile(this.C, z, t, "473");
                    string file561 = this._Project.GetImageFile(this.C, z, t, "561");
                    microImages[z - 1, t - 1] = new MicroImage(file, this.C, z, t);
                    microImages561[z - 1, t - 1] = new MicroImage(file561, this.C, z, t);
				}
			}

            this.MicroImages = microImages;
            this.MicroImages561 = microImages561;
		}

		public MicroImage GetMicroImage(int z, int t, string type)
		{
			z = z < 1 ? 1 : z > this._Project.Z ? this._Project.Z : z;
			t = t < 1 ? 1 : t > this._Project.T ? this._Project.T : t;

            MicroImage microImage;
            if (type == "473")
            {
                microImage = this.MicroImages[z - 1, t - 1];
            }
            else
            {
                microImage = this.MicroImages561[z - 1, t - 1];
            }

			if (microImage == null)
			{
				System.Windows.Forms.MessageBox.Show(string.Format("Z{0,D3}, T{0,D3} の画像はありません。", z, t));
			}

			return microImage;
		}

        public double[] AnalyzeSpot(AnalyzeAreaSet analyzeAreaSet, int t, int threshold)
        {
            int targetZ = 0;
            //AnalyzeArea analyzeArea = analyzeAreaSet.GetAnalyzeArea(1, t);
            AnalyzeArea analyzeArea = new AnalyzeArea();
			for (int z = 1; z <= this._Project.Z; z++)
            {
                analyzeArea = analyzeAreaSet.GetAnalyzeArea(z, t);

                if (analyzeArea.Enabled)
                {
                    targetZ = z;
                    break;
                }
            }

            if (targetZ == 0)
            {
                return new double[3];
            }

            double[] spots = new double[3];
            MicroImage microImage473 = this.GetMicroImage(targetZ, t, "473");
            MicroImage microImage561 = this.GetMicroImage(targetZ, t, "561");

            //spots[0] = analyzeArea.Count473;
            //spots[1] = analyzeArea.Count561;

            spots[0] = microImage473.AnalyzeSpot(analyzeArea, threshold);
            spots[1] = microImage561.AnalyzeSpot(analyzeArea, threshold);

            //Integrated Density
            spots[2] = microImage473.AnalyzeLuminance(analyzeArea, threshold);

            return spots;
        }

        public int GetZ(AnalyzeAreaSet analyzeAreaSet, int t)
        {
            int targetZ = 1;
            //AnalyzeArea analyzeArea = analyzeAreaSet.GetAnalyzeArea(1, t);
            AnalyzeArea analyzeArea = new AnalyzeArea();
            for (int z = 1; z <= this._Project.Z; z++)
            {
                analyzeArea = analyzeAreaSet.GetAnalyzeArea(z, t);

                if (analyzeArea.Enabled)
                {
                    targetZ = z;
                    break;
                }
            }

            return targetZ;
        }
	}
}
