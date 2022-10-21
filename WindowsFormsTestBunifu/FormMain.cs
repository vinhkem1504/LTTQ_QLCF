﻿using System;
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
        #endregion

        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }

        private void bbtnSale_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 5;
        }

        private void bbtnTK_Click(object sender, EventArgs e)
        {

        }
    }
}
