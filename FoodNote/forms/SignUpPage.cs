using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Final_Project.forms
{
	public partial class SignUpPage : MaterialForm
	{
		private readonly MaterialSkinManager materialSkinManager;
		public SignUpPage()
		{
			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);

			this.StartPosition = FormStartPosition.CenterScreen;

			InitializeComponent();
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
				materialFlatButtonSignUp.PerformClick();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '●';
		}

		private void materialFlatButtonSignUp_Click(object sender, EventArgs e)
		{
			string username = textBoxUsername.Text;
			string password = textBoxPassword.Text;
			if(username.Length == 0 || password.Length == 0)
			{
				MessageBox.Show("請輸入帳號和密碼");
			}
			if(Program.authService.signUp(username, password))
			{
				MessageBox.Show("註冊成功");
				this.Close();
			}
			else
			{
				MessageBox.Show("註冊失敗，使用者名稱相同");
			}
		}

		private void SignUp_Shown(object sender, EventArgs e)
		{
			textBoxUsername.Focus();
		}
	}
}
