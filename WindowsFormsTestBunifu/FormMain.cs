using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmMain : Form
    {

        QLCafeEntities db = new QLCafeEntities();

        bool exit = true;
        public frmMain()
        {
            InitializeComponent();
        }
        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 8;
            bpaPages.AllowTransitions = false;
        }
        
        private void bbtnUser_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 0;
            LoadDataNhanVien();
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

        private void btnBan_Them_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 1;
        }

        private void bpicLogo_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 8;
        }

        private void btnBan_ThanhToan_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }

        private void btnSP_CTSP_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 6;
        }

        private void btnChiTietSP_Return_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 1;
        }

        // Cell Click nhân viên
        private void dgvNhanVien_DSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietLoadNhanVien();
        }
        #endregion
        #region Method
        void LoadDataNhanVien()
        {
            dgvNhanVien_DSNV.DataSource = db.NhanViens.ToList();
        }

        //In thông tin nhân viên
        void ChiTietLoadNhanVien()
        {
            txtNV_MaNV.Text = dgvNhanVien_DSNV.CurrentRow.Cells[0].Value.ToString();
            txtNV_TenNV.Text = dgvNhanVien_DSNV.CurrentRow.Cells[1].Value.ToString();
            txtNV_DiaChi.Text = dgvNhanVien_DSNV.CurrentRow.Cells[2].Value.ToString();
            txtNV_SDT.Text = dgvNhanVien_DSNV.CurrentRow.Cells[3].Value.ToString();
            dtNV_NTNS.Value =DateTime.Parse(dgvNhanVien_DSNV.CurrentRow.Cells[4].Value.ToString());
            dtNV_NgayNhanViec.Value = DateTime.Parse(dgvNhanVien_DSNV.CurrentRow.Cells[5].Value.ToString());
            txtNV_LuongCB.Text = dgvNhanVien_DSNV.CurrentRow.Cells[6].Value.ToString();
        }

        // Tìm kiếm nhân viên
        void Search_DSNV(string s)
        {

            var result = from c in db.NhanViens
                         where c.MaNV == s
                         select c;
            dgvNhanVien_DSNV.DataSource = result.ToList();
        }

        // Load
        #endregion

        private void btxtNV_Search_Click(object sender, EventArgs e)
        {
            Search_DSNV(btxtNV_Search.Text);
        }

        private void btxtNV_Search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
