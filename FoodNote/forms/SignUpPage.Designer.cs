namespace Final_Project.forms
{
	partial class SignUpPage
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
			this.materialFlatButtonSignUp = new MaterialSkin.Controls.MaterialFlatButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// materialFlatButtonSignUp
			// 
			this.materialFlatButtonSignUp.AutoSize = true;
			this.materialFlatButtonSignUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButtonSignUp.Depth = 0;
			this.materialFlatButtonSignUp.Location = new System.Drawing.Point(185, 234);
			this.materialFlatButtonSignUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButtonSignUp.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButtonSignUp.Name = "materialFlatButtonSignUp";
			this.materialFlatButtonSignUp.Primary = false;
			this.materialFlatButtonSignUp.Size = new System.Drawing.Size(79, 36);
			this.materialFlatButtonSignUp.TabIndex = 16;
			this.materialFlatButtonSignUp.Text = "sign up";
			this.materialFlatButtonSignUp.UseVisualStyleBackColor = true;
			this.materialFlatButtonSignUp.Click += new System.EventHandler(this.materialFlatButtonSignUp_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(175, 183);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(89, 19);
			this.checkBox1.TabIndex = 15;
			this.checkBox1.Text = "顯示密碼";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// materialLabel3
			// 
			this.materialLabel3.AutoSize = true;
			this.materialLabel3.Depth = 0;
			this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel3.Location = new System.Drawing.Point(59, 153);
			this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel3.Name = "materialLabel3";
			this.materialLabel3.Size = new System.Drawing.Size(94, 24);
			this.materialLabel3.TabIndex = 14;
			this.materialLabel3.Text = "Password";
			// 
			// materialLabel1
			// 
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(58, 100);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(95, 24);
			this.materialLabel1.TabIndex = 13;
			this.materialLabel1.Text = "Username";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(175, 152);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '●';
			this.textBoxPassword.Size = new System.Drawing.Size(218, 25);
			this.textBoxPassword.TabIndex = 12;
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassword_KeyDown);
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(175, 99);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(218, 25);
			this.textBoxUsername.TabIndex = 11;
			this.textBoxUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxUsername_KeyDown);
			// 
			// SignUpPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 288);
			this.Controls.Add(this.materialFlatButtonSignUp);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.materialLabel3);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "SignUpPage";
			this.Text = "Sign Up Page";
			this.Shown += new System.EventHandler(this.SignUp_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialFlatButton materialFlatButtonSignUp;
		private System.Windows.Forms.CheckBox checkBox1;
		private MaterialSkin.Controls.MaterialLabel materialLabel3;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxUsername;
	}
}