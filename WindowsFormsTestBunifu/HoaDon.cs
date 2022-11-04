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
    public partial class frmHoaDon : Form
    {
        bool success = false;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (success != true)
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
            else
            {
                e.Cancel = false;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Đã in hóa đơn thành công !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                success = true;
                this.Close();
            }
            
        }
    }
}
