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
    public partial class frmPhieuNhap : Form
    {
        bool success = false;

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lập hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            success = true;
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chưa hoàn tất thanh toán! Chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                success = true;
                this.Close();
            }

        }

        private void frmPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(success != true)
            {
                if (MessageBox.Show("Bạn chưa hoàn tất thanh toán! Chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
