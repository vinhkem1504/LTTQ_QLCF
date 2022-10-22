using System;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmMain : Form
    {
        bool exit = true;
        public frmMain()
        {
            InitializeComponent();
        }
        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 0;
            bpaPages.AllowTransitions = false;
        }
        
        private void bbtnUser_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 0;
            //bpaPages.Transition.MinTime = 1000;
        }

        private void bbtnProduct_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 1;
        }

        private void bbtnIngredientStorage_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 2;
        }

        private void bbtnBill_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 3;
        }

        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }
        
        private void bbtnSale_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 5;
        }
        #endregion


        private void bbtnTK_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            frmHoaDon cTietHDB = new frmHoaDon();
            cTietHDB.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                if (MessageBox.Show("Thoát chương trình ?", "Thoát ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            frmPhieuNhap nhap = new frmPhieuNhap();
            nhap.ShowDialog();
        }

        private void bbtnLogout_Click(object sender, EventArgs e)
        {
            exit = false;
            this.Close();
            //Form frm = Application.OpenForms["frmLogin"];
            //frm.ShowDialog();
        }
    }
}
