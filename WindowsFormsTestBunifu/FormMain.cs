using System;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 0;
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
<<<<<<< HEAD

        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }
=======
>>>>>>> ad83f22a0bb2f6c712aa928543141bb36d045400
        #endregion

        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }
    }
}
