namespace Final_Project
{
	partial class LoginPage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
			this.materialFlatButtonLogin = new MaterialSkin.Controls.MaterialFlatButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.materialFlatButtonSignUp = new MaterialSkin.Controls.MaterialFlatButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(560, 131);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(218, 25);
			this.textBoxUsername.TabIndex = 0;
			this.textBoxUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxUsername_KeyDown);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(560, 184);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '●';
			this.textBoxPassword.Size = new System.Drawing.Size(218, 25);
			this.textBoxPassword.TabIndex = 1;
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassword_KeyDown);
			// 
			// materialLabel1
			// 
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(443, 132);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(95, 24);
			this.materialLabel1.TabIndex = 5;
			this.materialLabel1.Text = "Username";
			// 
			// materialLabel2
			// 
			this.materialLabel2.AutoSize = true;
			this.materialLabel2.Depth = 0;
			this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel2.Location = new System.Drawing.Point(100, 200);
			this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel2.Name = "materialLabel2";
			this.materialLabel2.Size = new System.Drawing.Size(0, 24);
			this.materialLabel2.TabIndex = 6;
			// 
			// materialLabel3
			// 
			this.materialLabel3.AutoSize = true;
			this.materialLabel3.Depth = 0;
			this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel3.Location = new System.Drawing.Point(444, 185);
			this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel3.Name = "materialLabel3";
			this.materialLabel3.Size = new System.Drawing.Size(94, 24);
			this.materialLabel3.TabIndex = 7;
			this.materialLabel3.Text = "Password";
			// 
			// materialFlatButtonLogin
			// 
			this.materialFlatButtonLogin.AutoSize = true;
			this.materialFlatButtonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButtonLogin.Depth = 0;
			this.materialFlatButtonLogin.Location = new System.Drawing.Point(539, 296);
			this.materialFlatButtonLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButtonLogin.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButtonLogin.Name = "materialFlatButtonLogin";
			this.materialFlatButtonLogin.Primary = false;
			this.materialFlatButtonLogin.Size = new System.Drawing.Size(67, 36);
			this.materialFlatButtonLogin.TabIndex = 8;
			this.materialFlatButtonLogin.Text = "Log in";
			this.materialFlatButtonLogin.UseVisualStyleBackColor = true;
			this.materialFlatButtonLogin.Click += new System.EventHandler(this.materialFlatButtonLogin_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(560, 215);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(89, 19);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "顯示密碼";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// materialFlatButtonSignUp
			// 
			this.materialFlatButtonSignUp.AutoSize = true;
			this.materialFlatButtonSignUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButtonSignUp.Depth = 0;
			this.materialFlatButtonSignUp.Location = new System.Drawing.Point(635, 296);
			this.materialFlatButtonSignUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButtonSignUp.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButtonSignUp.Name = "materialFlatButtonSignUp";
			this.materialFlatButtonSignUp.Primary = false;
			this.materialFlatButtonSignUp.Size = new System.Drawing.Size(79, 36);
			this.materialFlatButtonSignUp.TabIndex = 10;
			this.materialFlatButtonSignUp.Text = "sign up";
			this.materialFlatButtonSignUp.UseVisualStyleBackColor = true;
			this.materialFlatButtonSignUp.Click += new System.EventHandler(this.materialFlatButtonSignUp_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Final_Project.Properties.Resources.LoginWallpaper1;
			this.pictureBox1.Location = new System.Drawing.Point(31, 95);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(392, 291);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// LoginPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 420);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.materialFlatButtonSignUp);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.materialFlatButtonLogin);
			this.Controls.Add(this.materialLabel3);
			this.Controls.Add(this.materialLabel2);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "LoginPage";
			this.Text = "Login Page";
			this.Shown += new System.EventHandler(this.Login_Shown);
			this.VisibleChanged += new System.EventHandler(this.Login_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxPassword;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private MaterialSkin.Controls.MaterialLabel materialLabel2;
		private MaterialSkin.Controls.MaterialLabel materialLabel3;
		private MaterialSkin.Controls.MaterialFlatButton materialFlatButtonLogin;
		private System.Windows.Forms.CheckBox checkBox1;
		private MaterialSkin.Controls.MaterialFlatButton materialFlatButtonSignUp;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}