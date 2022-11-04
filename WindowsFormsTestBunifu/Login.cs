using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmLogin : Form
    {
        private string AdminCode = "";

        public frmLogin()
        {
            InitializeComponent();
        }
        #region Methods

        private void makeEmpty()
        {

        }

        #endregion
        #region events
        private void btxtPassword_OnValueChanged(object sender, EventArgs e)
        {
            btxtPassword.UseSystemPasswordChar = true;
        }

        // Load form
        private void Login_Load(object sender, EventArgs e)
        {
            bimgUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\user.png");
            bimgPassword.Image = Image.FromFile(Application.StartupPath + "\\Images\\lock.png");
            //btxtUsername.LeftIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\user.png");
            //btxtPassword.LeftIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\lock.png");
            //bimgEye.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            picReturnLogin.Image = Image.FromFile(Application.StartupPath + "\\Images\\arrow-small-left.png");
        }

        // Ẩn hiện mật khẩu
        private void bimgEye_Click(object sender, EventArgs e)
        {
            btxtPassword.UseSystemPasswordChar = !btxtPassword.UseSystemPasswordChar;
            if (btxtPassword.UseSystemPasswordChar)
            {
                btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            }
            else
            {
                btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye.png");
            }
            
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 0;
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size + 1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X + 1, lbl.Location.Y - 3);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size - 1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X - 1, lbl.Location.Y + 3);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 0;

        }

        // click Quên MK
        private void blblFogotPassword_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 1;
        }

        //click Đăng nhập
        private void bbtnLogin_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            this.Hide();
            
            frmMain.ShowDialog();
            this.Show();
        }

        //thoát không đăng nhập
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion


    }
}
