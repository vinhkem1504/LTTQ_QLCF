namespace WindowsFormsTestBunifu
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btxtUserName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btxtPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.blblFogotPassword = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.blblRegister = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bimgUser = new Bunifu.Framework.UI.BunifuImageButton();
            this.bimgEye = new Bunifu.Framework.UI.BunifuImageButton();
            this.bbtnLogin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bimgPassword = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.bimgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bimgEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bimgPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // btxtUserName
            // 
            this.btxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btxtUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btxtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btxtUserName.HintForeColor = System.Drawing.Color.Empty;
            this.btxtUserName.HintText = "";
            this.btxtUserName.isPassword = false;
            this.btxtUserName.LineFocusedColor = System.Drawing.Color.Blue;
            this.btxtUserName.LineIdleColor = System.Drawing.Color.Gray;
            this.btxtUserName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.btxtUserName.LineThickness = 3;
            this.btxtUserName.Location = new System.Drawing.Point(158, 115);
            this.btxtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.btxtUserName.Name = "btxtUserName";
            this.btxtUserName.Size = new System.Drawing.Size(341, 44);
            this.btxtUserName.TabIndex = 2;
            this.btxtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btxtPassword
            // 
            this.btxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btxtPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btxtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btxtPassword.HintForeColor = System.Drawing.Color.Empty;
            this.btxtPassword.HintText = "";
            this.btxtPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btxtPassword.isPassword = false;
            this.btxtPassword.LineFocusedColor = System.Drawing.Color.Blue;
            this.btxtPassword.LineIdleColor = System.Drawing.Color.Gray;
            this.btxtPassword.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.btxtPassword.LineThickness = 3;
            this.btxtPassword.Location = new System.Drawing.Point(158, 213);
            this.btxtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btxtPassword.Name = "btxtPassword";
            this.btxtPassword.Size = new System.Drawing.Size(341, 44);
            this.btxtPassword.TabIndex = 3;
            this.btxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btxtPassword.OnValueChanged += new System.EventHandler(this.btxtPassword_OnValueChanged);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(206, 18);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(186, 34);
            this.bunifuCustomLabel1.TabIndex = 7;
            this.bunifuCustomLabel1.Text = "ĐĂNG NHẬP";
            // 
            // blblFogotPassword
            // 
            this.blblFogotPassword.AutoSize = true;
            this.blblFogotPassword.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blblFogotPassword.ForeColor = System.Drawing.Color.SeaGreen;
            this.blblFogotPassword.Location = new System.Drawing.Point(416, 359);
            this.blblFogotPassword.Name = "blblFogotPassword";
            this.blblFogotPassword.Size = new System.Drawing.Size(117, 16);
            this.blblFogotPassword.TabIndex = 10;
            this.blblFogotPassword.Text = "quên mật khẩu ?";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(125, 478);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(205, 19);
            this.bunifuCustomLabel2.TabIndex = 11;
            this.bunifuCustomLabel2.Text = "Bạn chưa có tài khoản ?";
            // 
            // blblRegister
            // 
            this.blblRegister.AutoSize = true;
            this.blblRegister.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blblRegister.ForeColor = System.Drawing.Color.SeaGreen;
            this.blblRegister.Location = new System.Drawing.Point(347, 475);
            this.blblRegister.Name = "blblRegister";
            this.blblRegister.Size = new System.Drawing.Size(86, 23);
            this.blblRegister.TabIndex = 12;
            this.blblRegister.Text = "Đăng kí";
            // 
            // bimgUser
            // 
            this.bimgUser.BackColor = System.Drawing.SystemColors.Control;
            this.bimgUser.Image = ((System.Drawing.Image)(resources.GetObject("bimgUser.Image")));
            this.bimgUser.ImageActive = null;
            this.bimgUser.Location = new System.Drawing.Point(77, 115);
            this.bimgUser.Name = "bimgUser";
            this.bimgUser.Size = new System.Drawing.Size(57, 56);
            this.bimgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bimgUser.TabIndex = 14;
            this.bimgUser.TabStop = false;
            this.bimgUser.Zoom = 10;
            // 
            // bimgEye
            // 
            this.bimgEye.BackColor = System.Drawing.SystemColors.Control;
            this.bimgEye.Image = ((System.Drawing.Image)(resources.GetObject("bimgEye.Image")));
            this.bimgEye.ImageActive = null;
            this.bimgEye.Location = new System.Drawing.Point(506, 243);
            this.bimgEye.Name = "bimgEye";
            this.bimgEye.Size = new System.Drawing.Size(27, 26);
            this.bimgEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bimgEye.TabIndex = 15;
            this.bimgEye.TabStop = false;
            this.bimgEye.Zoom = 10;
            this.bimgEye.Click += new System.EventHandler(this.bimgEye_Click);
            // 
            // bbtnLogin
            // 
            this.bbtnLogin.ActiveBorderThickness = 1;
            this.bbtnLogin.ActiveCornerRadius = 20;
            this.bbtnLogin.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bbtnLogin.ActiveForecolor = System.Drawing.Color.White;
            this.bbtnLogin.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bbtnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.bbtnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bbtnLogin.BackgroundImage")));
            this.bbtnLogin.ButtonText = "Đăng Nhập";
            this.bbtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bbtnLogin.Font = new System.Drawing.Font("Century Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbtnLogin.ForeColor = System.Drawing.Color.SeaGreen;
            this.bbtnLogin.IdleBorderThickness = 1;
            this.bbtnLogin.IdleCornerRadius = 20;
            this.bbtnLogin.IdleFillColor = System.Drawing.Color.White;
            this.bbtnLogin.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bbtnLogin.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bbtnLogin.Location = new System.Drawing.Point(212, 316);
            this.bbtnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.bbtnLogin.Name = "bbtnLogin";
            this.bbtnLogin.Size = new System.Drawing.Size(193, 59);
            this.bbtnLogin.TabIndex = 1;
            this.bbtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bimgPassword
            // 
            this.bimgPassword.BackColor = System.Drawing.SystemColors.Control;
            this.bimgPassword.Image = ((System.Drawing.Image)(resources.GetObject("bimgPassword.Image")));
            this.bimgPassword.ImageActive = null;
            this.bimgPassword.Location = new System.Drawing.Point(77, 213);
            this.bimgPassword.Name = "bimgPassword";
            this.bimgPassword.Size = new System.Drawing.Size(57, 56);
            this.bimgPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bimgPassword.TabIndex = 13;
            this.bimgPassword.TabStop = false;
            this.bimgPassword.Zoom = 10;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 552);
            this.Controls.Add(this.blblRegister);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.blblFogotPassword);
            this.Controls.Add(this.bimgPassword);
            this.Controls.Add(this.bimgUser);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.bimgEye);
            this.Controls.Add(this.btxtPassword);
            this.Controls.Add(this.btxtUserName);
            this.Controls.Add(this.bbtnLogin);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bimgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bimgEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bimgPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 bbtnLogin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox btxtUserName;
        private Bunifu.Framework.UI.BunifuMaterialTextbox btxtPassword;
        private Bunifu.Framework.UI.BunifuImageButton bimgEye;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton bimgUser;
        private Bunifu.Framework.UI.BunifuCustomLabel blblFogotPassword;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel blblRegister;
        private Bunifu.Framework.UI.BunifuImageButton bimgPassword;
    }
}