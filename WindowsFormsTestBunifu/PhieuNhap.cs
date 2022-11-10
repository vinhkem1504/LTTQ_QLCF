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
        QLCafeEntities db = new QLCafeEntities();
        public frmPhieuNhap()
        {
            InitializeComponent();
        }


        #region Events
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            SetupImportContractInfo();
            LoadCbbNhaCungCap();
            LoadCbbMaNguyenLieu();
        }

        private void btnXacNhanLap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lập hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            success = true;
            this.Close();
        }

        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chưa hoàn tất thanh toán! Chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                success = true;
                this.Close();
            }

        }

        private void frmPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
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
        }
        
        #endregion
        #region Method
        void LoadCbbNhaCungCap()
        {
            cbbTenNCC.DataSource = (from ncc in db.NhaCungCaps select ncc.TenNCC).ToList();
            cbbTenNCC.SelectedIndex = -1;
        }

        void LoadCbbMaNguyenLieu()
        {
            cbbMaNL.DataSource = (from nl in db.NguyenLieux select nl.TenNL).ToList();
            cbbMaNL.SelectedIndex = -1;
        }

        private void SetupImportContractInfo()
        {
            //Tạo mã phiếu nhập
            string maPhieuNhap = "HDN" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            int id = 0;
            do
            {
                if (true)
                {
                    return;
                }
            } while (true);
        }

        #endregion

        private void btnThemNCC_Click(object sender, EventArgs e)
        {

        }
    }
}
