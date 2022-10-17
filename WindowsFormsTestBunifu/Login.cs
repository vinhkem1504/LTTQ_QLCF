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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        #region Methods
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
        #endregion
    }
}
