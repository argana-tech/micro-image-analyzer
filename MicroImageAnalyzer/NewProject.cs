using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace MicroImageAnalyzer
{
	public partial class NewProject : Form
	{
		public Project Project;
		public bool CreatedProject;

		private string _Flash = "";

		public NewProject()
		{
			InitializeComponent();

			this.Project = new Project();

			this._EnableEventHandlers();

			this._Render();
		}

		private void buttonBrowseSourceFolder_Click(object sender, EventArgs e)
		{
            buttonBrowseSourceFolder.Enabled = false;
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "画像が格納されているフォルダを選択してください。";
            dialog.ShowNewFolderButton = false;
            dialog.SelectedPath = GetFolderDialogMemory();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(path, "*tif", System.IO.SearchOption.TopDirectoryOnly);
                if (files.Length != 0)
                {
                    textSourceFolder.Text = path;
                    textFormat.Text = Path.GetFileName(files[0]);
                }
                else
                {
                    textSourceFolder.Text = "";
                    textFormat.Text = "";
                    this._Flash = "画像ファイルが正しく選択されませんでした。";
                }
            }

            Cursor.Current = oldCursor;
            buttonBrowseSourceFolder.Enabled = true;    

			this._Render();
		}

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            buttonBrowseSourceFolder.Enabled = false;
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string path = textSourceFolder.Text;
            string format = textFormat.Text;

            if (this.Project.SetSourceStackFolder(path,format))
            {
                Project project = this.Project;

                this._DisableEventHandlers();

                textProjectFileName.Text = project.ProjectFileName.ToString().Replace(".project", "");
                textProjectName.Text = project.Name.ToString();
                textX.Text = project.X.ToString();
                textY.Text = project.Y.ToString();
                textZ.Text = project.Z.ToString();
                textT.Text = project.T.ToString();
                textImageCount.Text = project.T.ToString();

                this._EnableEventHandlers();
            }
            else
            {
                if (this.Project.HasError())
                {
                    MessageBox.Show(this.Project.GetError());
                }

                this._Flash = "画像ファイルが正しく選択されませんでした。";
            }

            Cursor.Current = oldCursor;
            buttonBrowseSourceFolder.Enabled = true;

            this._Render();
        }

		private void buttonBrowseDestinationFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "プロジェクトを保存するフォルダを選択してください。";
			dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = GetFolderDialogMemory();

			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = dialog.SelectedPath;
                SetFolderDialogMemory(path);

				if (this.Project.SetDestinationFolder(path))
				{
					textDestinationFolder.Text = path;
				}
				else
				{
					if (this.Project.HasError())
					{
						MessageBox.Show(this.Project.GetError());
					}

					textDestinationFolder.Text = "";
					this._Flash = "プロジェクトフォルダが正しく選択されませんでした。";
				}
			}

			this._Render();
		}

        private string GetFolderDialogMemory()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Application.UserAppDataPath + "\\folderDialogMemory.log", Encoding.GetEncoding("Shift_JIS")))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void SetFolderDialogMemory(string path)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.UserAppDataPath + "\\folderDialogMemory.log", false, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    sw.Write(path);
                }
            }
            catch (Exception)
            {
            }
        }

        private void textProjectFileName_TextChanged(object sender, EventArgs e)
        {
            if (textProjectFileName.Text.Length > 0)
            {
                this.Project.ProjectFileName = textProjectFileName.Text + ".project";
                this.Project.ProjectImagesFolderName = textProjectFileName.Text + ".images";
            }
            else
            {
                MessageBox.Show("入力形式が正しくありません。");
                textProjectFileName.Text = this.Project.ProjectFileName.Replace(".project","");
            }
            this._Render();
        }

        private void textProjectName_TextChanged(object sender, EventArgs e)
        {
            this.Project.Name = textProjectName.Text;

            this._Render();
        }

		private void textX_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.Project.X = int.Parse(textX.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				textX.Text = this.Project.X.ToString();
			}

			this._Render();
		}

		private void textY_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.Project.Y = int.Parse(textY.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				textY.Text = this.Project.Y.ToString();
			}

			this._Render();
		}

		private void textZ_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.Project.Z = int.Parse(textZ.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				textZ.Text = this.Project.Z.ToString();
			}

			this._Render();
		}

		private void textT_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.Project.T = int.Parse(textT.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				textT.Text = this.Project.T.ToString();
			}

			this._Render();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			buttonOK.Enabled = false;
			Cursor oldCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

            bool updateChecker = true;
            if (System.IO.File.Exists(this.Project.GetProjectFileName()))
            {
                if (MessageBox.Show(this.Project.GetProjectFileName() + "はすでに登録されています。\n上書きしてよろしいですか？", "上書きの許可", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    updateChecker = false;
                    this._Flash = "処理を中断しました。";
                }
            }
            if (updateChecker)
            {
                this.Project.SetDestinationProjectFileName(this.Project.ProjectFileName);
                this.Project.SetDestinationProjectImagesFolderName(this.Project.ProjectImagesFolderName);

                bool createChecker = false;
                createChecker = this.Project.CreateStack();

                if (createChecker)
                {
                    this.CreatedProject = true;
                    this.Close();
                }
                else
                {
                    if (this.Project.HasError())
                    {
                        MessageBox.Show(this.Project.GetError());
                    }

                    this.CreatedProject = false;
                    this._Flash = "プロジェクトを作成できませんでした。";
                }
            }
			Cursor.Current = oldCursor;
			buttonOK.Enabled = true;

			this._Render();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void _Render()
		{
			if (this.Project.CanCreate())
			{
				buttonOK.Enabled = true;
			}
			else
			{
				buttonOK.Enabled = false;
			}

			labelStatus.Text = this._Flash;
			this._Flash = "";
		}

		private void _EnableEventHandlers()
		{
			textX.TextChanged += new EventHandler(textX_TextChanged);
			textY.TextChanged += new EventHandler(textY_TextChanged);
			textZ.TextChanged += new EventHandler(textZ_TextChanged);
			textT.TextChanged += new EventHandler(textT_TextChanged);
		}

		private void _DisableEventHandlers()
		{
			textX.TextChanged -= new EventHandler(textX_TextChanged);
			textY.TextChanged -= new EventHandler(textY_TextChanged);
			textZ.TextChanged -= new EventHandler(textZ_TextChanged);
			textT.TextChanged -= new EventHandler(textT_TextChanged);
		}

        private void NewProject_Load(object sender, EventArgs e)
        {

        }
	}
}
