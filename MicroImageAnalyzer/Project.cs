using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using BitMiracle.LibTiff.Classic;

namespace MicroImageAnalyzer
{
	[Serializable()]
	public class Project
	{
		public const string ImageInfoTextFileExt = "txt";
		public const string ImageFileExt = "tif";

		public const int DefaultR = 10;
		public const int DefaultThreshold = 200;
        
		private string _SourceFolder = "";
        private string _SourceFormat = "";
		private string _DestinationFolder = "";
        
        private string _DestinationProjectFileName = "";
        private string _DestinationProjectImagesFolderName = "";

        public string ProjectFileName;
        public string ProjectImagesFolderName;
		public string Folder;
		public string Name;
		public int C;
        public int X;
        public int Y;
        public int Z;
		public int T;
        public Boolean[,] SliceAreas = null;

		public BindingList<AnalyzeAreaSet> AnalyzeAreaSets = new BindingList<AnalyzeAreaSet>();

		private string _Error = "";

		public Project()
		{
		}

		private void _Initialize(Project project)
		{
			this._SourceFolder = "";
			this._DestinationFolder = "";

            this.ProjectFileName = project.ProjectFileName;
            this.ProjectImagesFolderName = project.ProjectImagesFolderName;
            this.Folder = project.Folder;
			this.Folder = project.Folder;
			this.Name = project.Name;
			this.C = project.C;
			this.X = project.X;
			this.Y = project.Y;
			this.Z = project.Z;
			this.T = project.T;

            this.SliceAreas = project.SliceAreas;
			this.AnalyzeAreaSets = project.AnalyzeAreaSets;

			this._Error = "";
		}

		public Analyzer GetAnalyzer(int c)
		{
			Analyzer analyzer = new Analyzer(this, c);
			return analyzer;
		}

		public string GetProjectFile()
		{
			return Path.Combine(this.Folder, ProjectFileName);
		}

		public string GetImagesFolder()
		{
			return Path.Combine(this.Folder, ProjectImagesFolderName);
		}

		public string GetImageFileName(int c, int z, int t)
		{
			return string.Format("{0}_C{1:D3}Z{2:D3}T{3:D3}.{4}",
				this.Name,
				c,
				z,
				t,
				ImageFileExt
			);
		}

		public string GetImageFile(int c, int z, int t, string type)
		{
            string imagesFolder = this.GetImagesFolder() + type;
			string imageFileName = this.GetImageFileName(c, z, t);

			return Path.Combine(imagesFolder, imageFileName);
		}
        
        public string GetProjectFileName()
        {
            return Path.Combine(this._DestinationFolder, this.ProjectFileName);
        }

		public void AddAnalyzeAreaSet(AnalyzeAreaSet analyzeAreaSet)
		{
			this.AnalyzeAreaSets.Add(analyzeAreaSet);
		}

		public AnalyzeAreaSet GetAnalyzeAreaSet(int index)
		{
			return this.AnalyzeAreaSets[index];
		}

		public void RemoveAnalyzeAreaSet(int index)
		{
			this.AnalyzeAreaSets.RemoveAt(index);
		}

        public bool SetSourceStackFolder(string stackFolder, string formatFile)
        {
            if (!this._SetNameFromStackTextFile(formatFile))
            {
                return false;
            }
            if (this._CheckStackImages(stackFolder, formatFile))
            {
                this._SourceFolder = stackFolder;
                this._SourceFormat = formatFile;
                return true;
            }

            this._SourceFormat = "";
            return false;
        }

        private bool _CheckStackImages(string stackFolder, string formatFile, Boolean create = false)
        {
            try
            {
                string getFileFormat = formatFile.Replace("[x]", "*").Replace("[nm]", "*").Replace("[t]", "*");
                string[] files = Directory.GetFiles(stackFolder, getFileFormat, System.IO.SearchOption.TopDirectoryOnly);

                string regex_str_473 = formatFile.Replace("[x]", @"([\d]{1})").Replace("[nm]", "473").Replace("[t]", @"([\d]+)").Replace(".", @"\.");
                Regex regex_file_473 = new Regex(@"" + regex_str_473 + "$", RegexOptions.IgnoreCase);
                
                string regex_str_561 = formatFile.Replace("[x]", @"([\d]{1})").Replace("[nm]", "561").Replace("[t]", @"([\d]+)").Replace(".", @"\.");
                Regex regex_file_561 = new Regex(@"" + regex_str_561 + "$", RegexOptions.IgnoreCase);

                int tcount_473 = 0;
                int tcount_561 = 0;
                int fd_count = 0;
                int width = 0;
                int height = 0;
                                
                foreach (string stackFile in files)
                {
                    string filename = Path.GetFileName(stackFile);

                    Match match_file_473 = regex_file_473.Match(filename);
                    Match match_file_561 = regex_file_561.Match(filename);
                    if (match_file_473.Success)
                    {
                        tcount_473++;
                    }
                    if (match_file_561.Success)
                    {
                        tcount_561++;
                    }
                    if ((match_file_473.Success || match_file_561.Success) && (fd_count == 0 || width == 0 || height == 0))
                    {
                        using (Tiff tif = Tiff.Open(stackFile, "r"))
                        {
                            FieldValue[] value = tif.GetField(TiffTag.IMAGEWIDTH);
                            width = value[0].ToInt();

                            value = tif.GetField(TiffTag.BITSPERSAMPLE);
                            short bpp = value[0].ToShort();
                            if (bpp != 16)
                            {
                                this.SetError("ファイルの種類が16bitではありません。");
                                return false;
                            }
                            value = tif.GetField(TiffTag.SAMPLESPERPIXEL);
                            short spp = value[0].ToShort();
                            if (spp != 1)
                            {
                                this.SetError("ファイルが解析できませんでした。");
                                return false;
                            }

                            value = tif.GetField(TiffTag.PHOTOMETRIC);
                            Photometric photo = (Photometric)value[0].ToInt();
                            if (photo != Photometric.MINISBLACK && photo != Photometric.MINISWHITE)
                            {
                                this.SetError("ファイルが解析できませんでした。");
                                return false;
                            }

                            value = tif.GetField(TiffTag.IMAGELENGTH);
                            height = value[0].ToInt();

                            fd_count = 1;
                            while (tif.ReadDirectory())
                            {
                                fd_count += 1;
                            }
                        }
                        //Image img = Image.FromFile(stackFile);

                        //FrameDimension fd = new FrameDimension(img.FrameDimensionsList[0]);
                        //fd_count = img.GetFrameCount(fd);
                        //width = img.Width;
                        //height = img.Height;

                        //img.Dispose();
                    }
                }

                if (tcount_473 ==0)
                {
                    this.SetError("473のファイルがみつかりませんでした。");
                    return false;
                }

                if (tcount_561 ==0)
                {
                    this.SetError("561のファイルがみつかりませんでした。");
                    return false;
                }

                if (fd_count == 0)
                {
                    this.SetError("Stackファイルが見つかりませんでした。");
                    return false;
                }

                if(create == false){
                    this.T = (tcount_473 < tcount_561) ? tcount_473 : tcount_561;
                    this.Z = (int)(System.Math.Floor((double)(fd_count)));
                    this.C = 1;
                    this.X = width;
                    this.Y = height;
                }

                return true;
            }
            catch (Exception e)
            {
                this.SetError(e.Message);
                return false;
            }
        }

        private bool _CheckStackImagesCount(string stackFolder, string stackFormat, int c, int z, int t)
        {
            try
            {
                string getFileFormat = stackFormat.Replace("[x]", "*").Replace("[nm]", "*").Replace("[t]", "*");
                string[] files = Directory.GetFiles(stackFolder, getFileFormat, System.IO.SearchOption.TopDirectoryOnly);

                string regex_str_473 = stackFormat.Replace("[x]", @"([\d]{1})").Replace("[nm]", "473").Replace("[t]", @"([\d]+)").Replace(".", @"\.");
                Regex regex_file_473 = new Regex(@"" + regex_str_473 + "$", RegexOptions.IgnoreCase);

                string regex_str_561 = stackFormat.Replace("[x]", @"([\d]{1})").Replace("[nm]", "561").Replace("[t]", @"([\d]+)").Replace(".", @"\.");
                Regex regex_file_561 = new Regex(@"" + regex_str_561 + "$", RegexOptions.IgnoreCase);

                int tcount_473 = 0;
                int tcount_561 = 0;
                int fd_count = 0;

                string filename = "";

                Match match_file_473;
                Match match_file_561;

                foreach (string stackFile in files)
                {
                    filename = Path.GetFileName(stackFile);

                    match_file_473 = regex_file_473.Match(filename);
                    match_file_561 = regex_file_561.Match(filename);
                    if (match_file_473.Success)
                    {
                        tcount_473++;
                    }
                    if (match_file_561.Success)
                    {
                        tcount_561++;
                    }
                    if ((match_file_473.Success || match_file_561.Success) && fd_count == 0)
                    {
                        using (Tiff tif = Tiff.Open(stackFile, "r"))
                        {
                            fd_count = 1;
                            while (tif.ReadDirectory())
                            {
                                fd_count += 1;
                            }
                        }
                    }
                }

                int count = c * z * t;

                if (tcount_473 * fd_count >= count && tcount_561 * fd_count >= count)
                {
                    return true;
                }
                else
                {
                    this.SetError("設定内容と画像データが一致しませんでした。");
                    return false;
                }
            }
            catch (Exception e)
            {
                this.SetError(e.Message);
                return false;
            }
        }

        private bool _SetNameFromStackTextFile(string format)
        {
            Regex regex = new Regex(@"([^\\]+)w\[x\][^\\]+\.tif$", RegexOptions.IgnoreCase);
            Match match = regex.Match(format);

            if (match.Success)
            {
                this.Name = match.Groups[1].Value;
                this.ProjectFileName = match.Groups[1].Value + ".project";
                this.ProjectImagesFolderName = match.Groups[1].Value + ".images";
                return true;
            }

            return false;
        }

		private bool _SetNameFromTextFile(string textFile)
		{
			Regex regex = new Regex(@"((\d+)-(\d+)-(\d+)(\w+)?)\.txt$");
			Match match = regex.Match(textFile);

			if (match.Success)
			{
                this.Name = match.Groups[1].Value;
                this.ProjectFileName = match.Groups[1].Value + ".project";
                this.ProjectImagesFolderName = match.Groups[1].Value + ".images";
				return true;
            }

			return false;
		}

        private bool _SetNameFromTextFileNonText(string sourceFolder)
        {
            string[] imageFiles = Directory.GetFiles(sourceFolder, "*." + ImageFileExt);
            bool checker = false;
            int maxC = 0;
            int maxZ = 0;
            int maxT = 0;
            foreach (string imageFilePath in imageFiles)
            {
                string imageFile = Path.GetFileName(imageFilePath);
                string imageFileToLower = imageFile.ToLower();

                Regex regexc = new Regex(@"c([\d]{1,3})");
                Match matchc = regexc.Match(imageFileToLower);

                Regex regexz = new Regex(@"z([\d]{1,3})");
                Match matchz = regexz.Match(imageFileToLower);

                Regex regext = new Regex(@"t([\d]{1,3})");
                Match matcht = regext.Match(imageFileToLower);

                if (matchc.Success && matchz.Success && matcht.Success)
                {
                    int matchC = int.Parse(matchc.Groups[1].Value);
                    int matchZ = int.Parse(matchz.Groups[1].Value);
                    int matchT = int.Parse(matcht.Groups[1].Value);

                    maxC = maxC < matchC ? matchC : maxC;
                    maxZ = maxZ < matchZ ? matchZ : maxZ;
                    maxT = maxT < matchT ? matchT : maxT;

                    if (!checker)
                    {
                        string matchName = imageFile.Replace(".tif", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"c[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"C[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"z[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"Z[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"t[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"T[\d]{1,3}", "");
                        matchName = System.Text.RegularExpressions.Regex.Replace(matchName, @"[^a-zA-Z0-9]*$", "");

                        this.Name = matchName;
                        this.ProjectFileName = matchName + ".project";
                        this.ProjectImagesFolderName = matchName + ".images";

                        checker = true;
                    }
                }
            }
            this.C = maxC;
            this.Z = maxZ;
            this.T = maxT;

            return checker;
        }

		private bool _ParseImageInfoTextFile(string textFile)
		{
			Dictionary<string, string> data = this._LoadImageInfoTextFile(textFile);

			if (data == null)
			{
				return false;
			}

			if (data.ContainsKey("Channel Dimension") && data["Channel Dimension"] != null)
			{
				Regex regex = new Regex(@"([0-9]+),\s+[0-9.]+ - [0-9.]+ \[Ch\]");
				Match match = regex.Match(data["Channel Dimension"]);

				if (match.Success)
				{
					this.C = int.Parse(match.Groups[1].Value);
				}
			}

			if (data.ContainsKey("X Dimension *") && data["X Dimension *"] != null)
			{
				Regex regex = new Regex(@"([0-9.]+),\s+[0-9.]+ - [0-9.]+ \[um\], ([0-9.]+) \[um/Pixel\]");
				Match match = regex.Match(data["X Dimension *"]);

				if (match.Success)
				{
					this.X = int.Parse(match.Groups[1].Value);
				}
			}

			if (data.ContainsKey("Y Dimension *") && data["Y Dimension *"] != null)
			{
				Regex regex = new Regex(@"([0-9.]+),\s+[0-9.]+ - [0-9.]+ \[um\], ([0-9.]+) \[um/Pixel\]");
				Match match = regex.Match(data["Y Dimension *"]);

				if (match.Success)
				{
					this.Y = int.Parse(match.Groups[1].Value);
				}
			}

			if (data.ContainsKey("Z Dimension") && data["Z Dimension"] != null)
			{
				Regex regex = new Regex(@"([0-9.]+),\s+[0-9.]+ - -[0-9.]+ \[um\], ([0-9.]+) \[um/Slice\]");
				Match match = regex.Match(data["Z Dimension"]);

				if (match.Success)
				{
					this.Z = int.Parse(match.Groups[1].Value);
				}
			}

			if (data.ContainsKey("T Dimension") && data["T Dimension"] != null)
			{
				Regex regex = new Regex(@"([0-9.]+),  [0-9.]+ - [0-9.]+ \[s\], Interval ([0-9:.]+)");
				Match match = regex.Match(data["T Dimension"]);

				if (match.Success)
				{
					this.T = int.Parse(match.Groups[1].Value);
				}
			}

			return true;
		}

		private Dictionary<string, string> _LoadImageInfoTextFile(string textFile)
		{
			try
			{
				using (StreamReader reader = new StreamReader(textFile))
				{
					Dictionary<string, string> data = new Dictionary<string, string>();
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						char[] delimiters = { '\t' };
						string[] words = line.Split(delimiters);

						if (words.Length != 2)
						{
							continue;
						}

						for (int i = 0; i < words.Length; i++)
						{
							Regex regex = new Regex(@"(^""|""$)");
							words[i] = regex.Replace(words[i], "");
						}

						data[words[0]] = words[1];
					}

					if (data.Count > 0)
					{
						return data;
					}
				}
			}
			catch (Exception)
			{
			}

			return null;
		}

		public bool SetDestinationFolder(string destinationFolder)
		{
			this.ClearError();

			this._DestinationFolder = destinationFolder;

			return true;
		}

        public bool SetDestinationProjectFileName(string ProjectFileName)
        {
            this._DestinationProjectFileName = ProjectFileName;

            return true;
        }

        public bool SetDestinationProjectImagesFolderName(string ProjectImagesFolderName)
        {
            this._DestinationProjectImagesFolderName = ProjectImagesFolderName;

            return true;
        }
        //

		public bool IsValid()
		{
			if (this.C <= 0)
			{
				return false;
			}

			if (
				this.X <= 0
				|| this.Y <= 0
				|| this.Z <= 0
				|| this.T <= 0
                || this.Name == ""
			)
			{
				return false;
			}

			return true;
		}

		public bool CanCreate()
		{
		if (this.IsValid() == false)
			{
				return false;
			}

			return this._SourceFolder != null && this._SourceFolder != ""
				&& this._DestinationFolder != null && this._DestinationFolder != ""
				;
		}

        private void StackCopy(string folder, string format, string imagesFolder, int c, int this_Z, int this_T, string type)
        {
            Regex regex_file_format;
            if (type == "473")
            {
                regex_file_format = new Regex(@"" + format.Replace("[x]", @"([\d]{1})").Replace("[nm]", "473").Replace("[t]", @"([\d]+)").Replace(".", @"\.") + "$", RegexOptions.IgnoreCase);
            }
            else
            {
                regex_file_format = new Regex(@"" + format.Replace("[x]", @"([\d]{1})").Replace("[nm]", "561").Replace("[t]", @"([\d]+)").Replace(".", @"\.") + "$", RegexOptions.IgnoreCase);
            }

            string getFileFormat = format.Replace("[x]", "*").Replace("[nm]", type).Replace("[t]", "*");
            string[] allImageFiles = Directory.GetFiles(folder, getFileFormat);

            int[] tValues = new int[allImageFiles.Length];

            int count = 0;
            Match match_file;
            foreach (string imageFilePath in allImageFiles)
            {
                match_file = regex_file_format.Match(Path.GetFileName(imageFilePath));
                if (match_file.Success)
                {
                    tValues[count] = int.Parse(match_file.Groups[2].Value);
                    count++;
                }
            }

            Array.Sort(tValues);

            string getTFileFormat = "";
            string[] imageTFiles;
            string source_file = "";
            for (int t = 1; t <= this.T; t++)
            {
                getTFileFormat = format.Replace("[x]", "*").Replace("[nm]", type).Replace("[t]", tValues[t - 1].ToString());
                imageTFiles = Directory.GetFiles(folder, getTFileFormat);

                source_file = imageTFiles[0];

                using (Tiff tif = Tiff.Open(source_file, "r"))
                {
                    string fileName;
                    string destination;

                    for (int z = 1; z <= this_Z; z++)
                    {

                        fileName = this.GetImageFileName(c, z, t);

                        destination = Path.Combine(imagesFolder, fileName);

                        tif.ReadDirectory();

                        FieldValue[] res = tif.GetField(TiffTag.IMAGELENGTH);
                        int height = res[0].ToInt();

                        res = tif.GetField(TiffTag.IMAGEWIDTH);
                        int width = res[0].ToInt();

                        res = tif.GetField(TiffTag.BITSPERSAMPLE);
                        short bpp = res[0].ToShort();

                        res = tif.GetField(TiffTag.SAMPLESPERPIXEL);
                        short spp = res[0].ToShort();

                        int stride = tif.ScanlineSize();
                        byte[] buffer = new byte[stride];

                        Bitmap resultIndex = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);

                        Tiff output = Tiff.Open(destination, "w");
                        output.SetField(TiffTag.IMAGEWIDTH, width);
                        output.SetField(TiffTag.IMAGELENGTH, height);
                        output.SetField(TiffTag.SAMPLESPERPIXEL, spp);
                        output.SetField(TiffTag.BITSPERSAMPLE, bpp);
                        output.SetField(TiffTag.ROWSPERSTRIP, height);
                        output.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.INCH);
                        output.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                        output.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                        output.SetField(TiffTag.COMPRESSION, Compression.NONE);
                        output.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);

                        for (int i = 0; i < height; i++)
                        {
                            tif.ReadScanline(buffer, i);
                            output.WriteScanline(buffer, i);
                        }
                        output.Dispose();
                    }
                }
            }
        }

        public bool CreateStack()
        {
            this.ClearError();

            //if (!this._CheckStackImages(this._SourceFolder, this._SourceFormat, true))
            //{
            //    return false;
            //}
            if (!this._CheckStackImagesCount(this._SourceFolder, this._SourceFormat, this.C, this.Z, this.T))
            {
                return false;
            }
            if (this._DestinationFolder == null || this._DestinationFolder == "")
            {
                this.SetError("保存先フォルダが指定されていません。");
                return false;
            }

            string imagesFolder = Path.Combine(this._DestinationFolder, ProjectImagesFolderName);
            string imagesFolder473 = imagesFolder + "473";
            string imagesFolder561 = imagesFolder + "561";

            if (Directory.Exists(imagesFolder473) == false)
            {
                try
                {
                    Directory.CreateDirectory(imagesFolder473);
                }
                catch (Exception e)
                {
                    this.SetError(e.Message);
                    return false;
                }
            }
            if (Directory.Exists(imagesFolder561) == false)
            {
                try
                {
                    Directory.CreateDirectory(imagesFolder561);
                }
                catch (Exception e)
                {
                    this.SetError(e.Message);
                    return false;
                }
            }


            int errorCount = 0;

            for (int c = 1; c <= this.C; c++)
            {
                    try
                    {
                        this.StackCopy(this._SourceFolder, this._SourceFormat, imagesFolder473, c, this.Z, this.T, "473");
                        this.StackCopy(this._SourceFolder, this._SourceFormat, imagesFolder561, c, this.Z, this.T, "561");
                    }
                    catch (Exception)
                    {
                        errorCount++;
                    }
            }

            if (errorCount > 0)
            {
                MessageBox.Show(errorCount.ToString() + "個のファイルのコピーができませんでした。");
            }

            string oldFolder = this.Folder;
            this.Folder = this._DestinationFolder;

            if (this.Save())
            {
                return true;
            }   

            this.Folder = oldFolder;
            return true;
        }

		public bool Create()
		{
			this.ClearError();

            //if (!this._CheckImages(this._SourceFolder))
            //{
            //    return false;
            //}

			if (this._DestinationFolder == null || this._DestinationFolder == "")
			{
				this.SetError("保存先フォルダが指定されていません。");
				return false;
			}

            string imagesFolder = Path.Combine(this._DestinationFolder, this._DestinationProjectImagesFolderName);
            string imagesFolder473 = Path.Combine(this._DestinationFolder, this._DestinationProjectImagesFolderName) + "473";
            string imagesFolder561 = Path.Combine(this._DestinationFolder, this._DestinationProjectImagesFolderName) + "561";

            if (Directory.Exists(imagesFolder473) == false)
            {
                try
                {
                    Directory.CreateDirectory(imagesFolder473);
                }
                catch (Exception e)
                {
                    this.SetError(e.Message);
                    return false;
                }
            }
            if (Directory.Exists(imagesFolder561) == false)
            {
                try
                {
                    Directory.CreateDirectory(imagesFolder561);
                }
                catch (Exception e)
                {
                    this.SetError(e.Message);
                    return false;
                }
            }
            
			int errorCount = 0;
            try
            {
                CopyDirectory(this._SourceFolder + "473", imagesFolder473, true);
                CopyDirectory(this._SourceFolder + "561", imagesFolder561, true);

            }
            catch (IOException)
            {
                errorCount++;
            }


			if (errorCount > 0)
			{
				MessageBox.Show("ファイルのコピーに失敗しました。");
			}

			string oldFolder = this.Folder;
			this.Folder = this._DestinationFolder;

            string oldProjectFileName = this.ProjectFileName;
            this.ProjectFileName = this._DestinationProjectFileName;

            string oldProjectImagesFolderName = this.ProjectImagesFolderName;
            this.ProjectImagesFolderName = this._DestinationProjectImagesFolderName;

			if (this.Save())
			{
				return true;
			}

            this.Folder = oldFolder;
            this.ProjectFileName = oldProjectFileName;
            this.ProjectImagesFolderName = oldProjectImagesFolderName;
			return false;
		}

        public static void CopyDirectory(string stSourcePath, string stDestPath, bool bOverwrite)
        {
            if (!System.IO.Directory.Exists(stDestPath))
            {
                System.IO.Directory.CreateDirectory(stDestPath);
                System.IO.File.SetAttributes(stDestPath, System.IO.File.GetAttributes(stSourcePath));
                bOverwrite = true;
            }
            if (bOverwrite)
            {
                foreach (string stCopyFrom in System.IO.Directory.GetFiles(stSourcePath))
                {
                    string stCopyTo = System.IO.Path.Combine(stDestPath, System.IO.Path.GetFileName(stCopyFrom));
                    System.IO.File.Copy(stCopyFrom, stCopyTo, true);
                }
            }
            else
            {
                foreach (string stCopyFrom in System.IO.Directory.GetFiles(stSourcePath))
                {
                    string stCopyTo = System.IO.Path.Combine(stDestPath, System.IO.Path.GetFileName(stCopyFrom));

                    if (!System.IO.File.Exists(stCopyTo))
                    {
                        System.IO.File.Copy(stCopyFrom, stCopyTo, false);
                    }
                }
            }
            foreach (string stCopyFrom in System.IO.Directory.GetDirectories(stSourcePath))
            {
                string stCopyTo = System.IO.Path.Combine(stDestPath, System.IO.Path.GetFileName(stCopyFrom));
                CopyDirectory(stCopyFrom, stCopyTo, bOverwrite);
            }
        }

		public bool Load(string path)
		{
            string pFileName = Path.GetFileName(path);


            this.ProjectFileName = pFileName;
            this.ProjectImagesFolderName = pFileName.Replace(".project", ".images");

            this.Folder = path.Replace(pFileName, "");

			try
			{
				FileStream stream = new FileStream(this.GetProjectFile(), FileMode.Open, FileAccess.Read);
				BinaryFormatter formatter = new BinaryFormatter();
				Project project = (Project)formatter.Deserialize(stream);
				stream.Close();

                project.ProjectFileName = this.ProjectFileName;
                project.ProjectImagesFolderName = this.ProjectImagesFolderName;
                project.Folder = this.Folder;

				this._Initialize(project);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;
			}
		}

		public bool Save()
		{
			try
			{
				FileStream stream = new FileStream(this.GetProjectFile(), FileMode.Create, FileAccess.Write);
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, this);
				stream.Close();

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				return false;
			}
		}

		public bool SaveAs()
		{
			this.ClearError();

            this._SourceFolder = Path.Combine(this.Folder, ProjectImagesFolderName);
			return this.Create();
		}

        public bool ExportAsCSV(int index, Spot spot)
		{
			this.ClearError();

            Analyzer analyzer = this.GetAnalyzer(1);
            AnalyzeAreaSet analyzeAreaSet = this.GetAnalyzeAreaSet(index);

            string fileName = this.Name + "-" + analyzeAreaSet.Name + ".csv";
            string file = "";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = fileName;
            dialog.Filter = "CSVファイル(*.csv)|*.csv";
            dialog.Title = "保存先のファイルを選択してください";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file = dialog.FileName;
            }
            else
            {
                this.SetError("出力を中断しました。");
                return false;
            }

            if (File.Exists(file))
            {
                DialogResult result = MessageBox.Show(string.Format("'{0}' は既に存在します。\n新しいファイルに置き換えますか？", fileName), "CSVで出力", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    this.SetError("出力を中断しました。");
                    return false;
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    string[] times = new string[this.T + 1];
                    string[] count473 = new string[this.T + 1];
                    string[] count561 = new string[this.T + 1];
                    string[] intDen = new string[this.T + 1];

                    for (int t = 1; t <= this.T; t++)
                    {
                        times[t] = "T" + t.ToString();
                    }

                    this._WriteCSVLine(sw, times);

                    count473[0] = "Count473";
                    count561[0] = "Count561";
                    intDen[0] = "IntDen";

                    int[] valueCount473 = spot._getCount473();
                    int[] valueCount561 = spot._getCount561();
                    int[] valueIntDen = spot._getIntDen();

                    for (int t = 1; t <= this.T; t++)
                    {
                        count473[t] = valueCount473[t-1].ToString();
                        count561[t] = valueCount561[t - 1].ToString();
                        intDen[t] = valueIntDen[t - 1].ToString();
                    }

                    this._WriteCSVLine(sw, count473);
                    this._WriteCSVLine(sw, count561);
                    this._WriteCSVLine(sw, intDen);

                }
            }
            catch (Exception e)
            {
                this.SetError(e.Message);
                return false;
            }


			return true;
		}

		private void _WriteCSVLine(StreamWriter sw, string[] values)
		{
			string line = String.Join(",", values);
			sw.WriteLine(line);
		}


		public Project SetError(string error)
		{
			this._Error = error;
			return this;
		}

		public string GetError()
		{
			return this._Error;
		}

		public bool HasError()
		{
			return this._Error != null && this._Error != "";
		}

		public Project ClearError()
		{
			this._Error = "";
			return this;
		}
	}
}
