using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuDataGridView.Transitions;

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

        private void bbtnFinace_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 2;
        }

        #endregion
    }
}
