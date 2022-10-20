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
            btxtPassword.isPassword = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            bimgUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\user.png");
            bimgPassword.Image = Image.FromFile(Application.StartupPath + "\\Images\\lock.png");
            bimgEye.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
        }

        private void bimgEye_Click(object sender, EventArgs e)
        {
            btxtPassword.isPassword = !btxtPassword.isPassword;
            if (btxtPassword.isPassword)
            {
                bimgEye.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            }
            else
            {
                bimgEye.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye.png");
            }
            
        }

        private void blblRegister_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 1;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 0;
        }


        #endregion

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size +1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X + 1, lbl.Location.Y - 3);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size - 1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X - 1, lbl.Location.Y +3 );
        }
    }
}
