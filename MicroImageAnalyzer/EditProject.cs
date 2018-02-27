using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MicroImageAnalyzer
{
	public partial class EditProject : Form
	{
		public Project Project;
		public bool UpdatedProject = false;

		private string _Flash = "";

		public EditProject(Project project)
		{
			InitializeComponent();

			this.Project = project;

			textX.Text = this.Project.X.ToString();
			textY.Text = this.Project.Y.ToString();
			textZ.Text = this.Project.Z.ToString();
			textT.Text = this.Project.T.ToString();

			textX.TextChanged += new System.EventHandler(this.textX_TextChanged);
			textY.TextChanged += new System.EventHandler(this.textY_TextChanged);
			textZ.TextChanged += new System.EventHandler(this.textZ_TextChanged);
			textT.TextChanged += new System.EventHandler(this.textT_TextChanged);

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
			if (this.Project.IsValid())
			{
				this.UpdatedProject = true;
				this.Close();
			}
			else
			{
				if (this.Project.HasError())
				{
					MessageBox.Show(this.Project.GetError());
				}

				this.UpdatedProject = false;
				this._Flash = "プロジェクト設定を変更できませんでした。";
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.UpdatedProject = false;
			this.Close();
		}

		private void _Render()
		{
			if (this.Project.IsValid())
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
	}
}
