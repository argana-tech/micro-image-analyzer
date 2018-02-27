using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroImageAnalyzer
{
	[Serializable()]
	public class AnalyzeAreaSet
	{
		public string Name;
		public AnalyzeArea[,] AnalyzeAreas;

		public AnalyzeAreaSet()
		{
		}

		public AnalyzeAreaSet(int initZ, int initT)
		{
			this.Name = "";

			this.AnalyzeAreas = new AnalyzeArea[initZ, initT];

			for (int z = 0; z < initZ; z++)
			{
				for (int t = 0; t < initT; t++)
				{
					this.AnalyzeAreas[z, t] = new AnalyzeArea();
				}
			}
		}

		public AnalyzeArea GetAnalyzeArea(int z, int t)
		{
			return this.AnalyzeAreas[z - 1, t - 1];
		}

		public bool IsValid()
		{
			if (this.Name == "")
			{
				return false;
			}

			for (int z = 0; z < this.AnalyzeAreas.GetLength(0); z++)
			{
				for (int t = 0; t < this.AnalyzeAreas.GetLength(1); t++)
				{
					AnalyzeArea analyzeArea = this.AnalyzeAreas[z, t];
					if (analyzeArea.IsValid() == false)
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
