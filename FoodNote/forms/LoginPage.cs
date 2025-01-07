using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_Project
{
	public partial class LoginPage : MaterialForm
	{
		private readonly MaterialSkinManager materialSkinManager;
		public string username;

		public LoginPage()
		{
			// 初始化 MaterialSkinManager
			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);

			this.StartPosition = FormStartPosition.CenterScreen;

			InitializeComponent();

			textBoxUsername.Focus();
		}


		// 當在帳號 TextBox 按下 Enter
		private void TextBoxUsername_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) // 判斷是否按下 Enter 鍵
			{
				e.SuppressKeyPress = true; // 禁止系統預設音效
				textBoxPassword.Focus(); // 切換到密碼輸入框
			}
		}

		// 當在密碼 TextBox 按下 Enter
		private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) 
			{
				e.SuppressKeyPress = true; 
				materialFlatButtonLogin.PerformClick(); 
			}
		}


		private void materialFlatButtonLogin_Click(object sender, EventArgs e)
		{
			string username = textBoxUsername.Text;
			string password = textBoxPassword.Text;

			if (Program.authService.logIn(username, password))
			{
				this.username = username;

				MessageBox.Show("登入成功");
				MainScreen mainScreen = new MainScreen(this);
				mainScreen.Show();
			}
			else
			{
				MessageBox.Show("Invalid username or password");
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '●';
		}

		private void Login_Shown(object sender, EventArgs e)
		{
			textBoxUsername.Focus();
			if (this.Visible)
			{
				this.textBoxUsername.Text = "";
				this.textBoxPassword.Text = "";
				this.checkBox1.Checked = false;

				this.username = null;
			}
		}

		private void materialFlatButtonSignUp_Click(object sender, EventArgs e)
		{
			SignUpPage signUpPage = new SignUpPage();
			signUpPage.ShowDialog();

			textBoxUsername.Text = "";
			textBoxPassword.Text = "";	
		}
	}
}
