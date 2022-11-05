using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmMain : Form
    {

        QLCafeEntities1 db = new QLCafeEntities1();

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
            LoadDataNhanVien();
            LoadDataHoaDon();
            LoadDataSanPham();
            LoadDataNguyenLieu();
        }
        
        private void bbtnUser_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 0;
            
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

        // chi tiết hóa đơn bán
        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            if (txtHD_MaHD.Text != "")
            {
                // Load thành danh sách SP theo hóa đơn
                var result = from c in db.ChiTietHDBs
                             where c.MaHDB == txtHD_MaHD.Text
                             select new {Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia};
                dgvCTB_DSSP.DataSource = result.ToList();

                // Load thông tin
                lblTenHoaDon.Text = lblTenHoaDon.Text + txtHD_MaHD.Text;

                //txtCTB_TongTien.Text = (int.Parse(txtCTB_SL.Text) * int.Parse(txtCTB_DonGia.Text)).ToString();

                bpaPages.SelectedIndex = 4;
            }
            else
            {
                MessageBox.Show("Chưa chọn hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
            if(txtSP_MaSp.Text != "")
            {
                // Load thành phần nguyên liệu
                var result = from c in db.CongThucDoUongs
                             where c.MaDU == txtSP_MaSp.Text
                             select c;
                dgvCTSP_DSNL.DataSource = result.ToList();

                // Load thông tin
                txtCTSP_MaSp.Text = txtSP_MaSp.Text;
                txtCTSP_TenSp.Text = txtSP_TenSp.Text;
                txtCTSP_DonGia.Text = txtSP_DonGia.Text;
                bpaPages.SelectedIndex = 6;
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        // tìm kiếm nvien
        private void btxtNV_Search_Click(object sender, EventArgs e)
        {
            Search_DSNV(btxtNV_Search.Text);
        }
        // Cell Click kho
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietNguyenLieu();
        }

        // Icon right click - tìm kiếm nguyên liệu
        private void bunifuTextBox2_OnIconRightClick(object sender, EventArgs e)
        {
            Search_DSNL(btxtSearch_NL.Text);
        }

        private void dgvSP_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietSP();
        }

        private void dgvHD_DSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietHDB();
        }

        private void dgvCTB_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietSP_HDB();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 3;
        }

        private void btnLsuNhap_Click(object sender, EventArgs e)
        {
            var result = from c in db.HoaDonNhaps
                         select new { MaHDN = c.MaHDN, MaNV = c.MaNV, MaNCC = c.MaNCC, NgayLap = c.NgayLap };
            dgvHDN_DSNhap.DataSource = result.ToList();

            bpaPages.SelectedIndex = 9;
        }

        private void dgvHDN_DSNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietHDN();
        }

        private void btnHDN_ChiTiet_Click(object sender, EventArgs e)
        {

            if (txtHDN_MaHDN.Text != "")
            {
                // Load thành danh sách NL theo hóa đơn nhập
                var result = from c in db.ChiTietHDNs
                             where c.MaHDN == txtHDN_MaHDN.Text
                             select new { TenNL = c.NguyenLieu.TenNL, TenNCC = c.HoaDonNhap.NhaCungCap.TenNCC, SoLuong = c.SoLuongNhap, DonGia = c.NguyenLieu.DonGia };
                dgvCTN_DSNL.DataSource = result.ToList();

                // Load thông tin
                lblCTN_TenHDN.Text = lblCTN_TenHDN.Text + txtHDN_MaHDN.Text;

                //txtCTB_TongTien.Text = (int.Parse(txtCTB_SL.Text) * int.Parse(txtCTB_DonGia.Text)).ToString();

                bpaPages.SelectedIndex = 10;
            }
            else
            {
                MessageBox.Show("Chưa chọn hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 9;
        }

        private void dgvCTN_DSNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietNL_HDN();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_OnIconRightClick(object sender, EventArgs e)
        {
            Search_DSSP(txtSearch_SP.Text);
        }

        private void bunifuTextBox3_OnIconRightClick(object sender, EventArgs e)
        {
            Search_HD(txtSearch_HDB.Text);
        }

        private void txtSearch_HDN_OnIconRightClick(object sender, EventArgs e)
        {
            Search_HDN(txtSearch_HDN.Text);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmPhieuNhap nhap = new frmPhieuNhap();
            nhap.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 2;
        }
        #endregion


        #region Method
        void LoadDataNhanVien()
        {
            var result = from c in db.NhanViens
                         select new { MaNV = c.MaNV, TenNV = c.HoTen, DiaChi = c.DiaChi, SDT = c.SDT, NgaySinh = c.NgaySinh, NgayNhapViec = c.NgayNhanViec, Luong = c.ChiTietNhanVien.Luong.ToString() };
            dgvNhanVien_DSNV.DataSource = result.ToList();
        }

        //In thông tin nhân viên
        void ChiTietLoadNhanVien()
        {
            txtNV_MaNV.Text = dgvNhanVien_DSNV.CurrentRow.Cells[0].Value.ToString();
            txtNV_TenNV.Text = dgvNhanVien_DSNV.CurrentRow.Cells[1].Value.ToString();
            txtNV_DiaChi.Text = dgvNhanVien_DSNV.CurrentRow.Cells[2].Value.ToString();
            txtNV_SDT.Text = dgvNhanVien_DSNV.CurrentRow.Cells[3].Value.ToString();
            dtNV_NTNS.Text = dgvNhanVien_DSNV.CurrentRow.Cells[4].Value.ToString();
            dtNV_NgayNhanViec.Text = dgvNhanVien_DSNV.CurrentRow.Cells[5].Value.ToString();
            txtNV_LuongCB.Text = dgvNhanVien_DSNV.CurrentRow.Cells[6].Value.ToString();
        }

        // Tìm kiếm nhân viên
        void Search_DSNV(string s)
        {
            var result = from c in db.NhanViens
                         where c.MaNV == s
                         select new { MaNV = c.MaNV, TenNV = c.HoTen, DiaChi = c.DiaChi, SDT = c.SDT, NgaySinh = c.NgaySinh, NgayNhapViec = c.NgayNhanViec, Luong = c.ChiTietNhanVien.Luong.ToString() };

            dgvNhanVien_DSNV.DataSource = result.ToList();
        }

        // LoadData hóa đơn
        void LoadDataHoaDon()
        {
            var result = from c in db.HoaDonBans
                         select new { MaHD = c.MaHDB, MaNV = c.MaNV, NgayLap = c.NgayLap, TrangThai = c.TrangThai };
            dgvHD_DSHD.DataSource = result.ToList();
            
        }

        // Load thông tin hóa đơn
        void ChiTietHDB()
        {
            txtHD_MaHD.Text = dgvHD_DSHD.CurrentRow.Cells[0].Value.ToString();
            txtHD_MaNV.Text = dgvHD_DSHD.CurrentRow.Cells[1].Value.ToString();
            dtHD_Ngaylap.Text =dgvHD_DSHD.CurrentRow.Cells[2].Value.ToString();
            bool done = bool.Parse(dgvHD_DSHD.CurrentRow.Cells[3].Value.ToString());
            if ( done == true)
            {
                txtHD_TrangThai.Text = "Đã thanh toán";
            }
            else
            {
                txtHD_TrangThai.Text = "Chưa thanh toán";
            }
            txtHD_Ghichu.Text = "";
        }

        // Load sản phẩm
        void LoadDataSanPham()
        {
            var result = from c in db.DoUongs
                         select new { MaSP = c.MaDU, TenSP = c.TenDU, DonGia = c.DonGia };
            dgvSP_DSSP.DataSource = result.ToList();
            
        }

        // Load chi tiết SP
        void ChiTietSP()
        {
            txtSP_MaSp.Text = dgvSP_DSSP.CurrentRow.Cells[0].Value.ToString();
            txtSP_TenSp.Text = dgvSP_DSSP.CurrentRow.Cells[1].Value.ToString();
            txtSP_DonGia.Text = dgvSP_DSSP.CurrentRow.Cells[2].Value.ToString();

        }

        // Load danh sách nguyên liệu
        void LoadDataNguyenLieu()
        {
            var result = from c in db.NguyenLieux
                         select new { MaNL = c.MaNL, TenNL = c.TenNL, DonVi = c.DonVi, SLTon = c.SoLuongTon };
            dgvKho.DataSource = result.ToList();
        }

        // Load chi tiết nguyên liệu
        void ChiTietNguyenLieu()
        {
            txtKho_MaNL.Text = dgvKho.CurrentRow.Cells[0].Value.ToString();
            txtKho_TenNL.Text = dgvKho.CurrentRow.Cells[1].Value.ToString();
            txtKho_Donvi.Text = dgvKho.CurrentRow.Cells[2].Value.ToString();
            txtKho_SL.Text = dgvKho.CurrentRow.Cells[3].Value.ToString();
        }

        // Tìm kiếm nguyên liệu
        void Search_DSNL(string s)
        {
            var result = from c in db.NguyenLieux
                         where c.MaNL == s
                         select new { MaNL = c.MaNL, TenNL = c.TenNL, DonVi = c.DonVi, SLTon = c.SoLuongTon };
            
            dgvKho.DataSource = result.ToList();
        }

        // TÌm kiếm sản phẩm
        void Search_DSSP(string s)
        {
            var result = from c in db.DoUongs
                         where c.MaDU == s
                         select new { MaSP = c.MaDU, TenSP = c.TenDU, DonGia = c.DonGia };

            dgvSP_DSSP.DataSource = result.ToList();
        }

        // Tìm kiếm hóa đơn nhập
        void Search_HDN(string s)
        {
            var result = from c in db.HoaDonNhaps
                         where c.MaHDN == s
                         select new { MaHDN = c.MaHDN, MaNV = c.MaNV, MaNCC = c.MaNCC, NgayLap = c.NgayLap };
            dgvHDN_DSNhap.DataSource = result.ToList();
        }

        // Tìm kiếm hóa đơn bán
        void Search_HD(string s)
        {
            var result = from c in db.HoaDonBans
                         where c.MaHDB == s
                         select new { MaHD = c.MaHDB, MaNV = c.MaNV, NgayLap = c.NgayLap, TrangThai = c.TrangThai };
            dgvHD_DSHD.DataSource = result.ToList();
        }

        // Cell click chi tiết bán
        void ChiTietSP_HDB()
        {
            txtCTB_TenSP.Text = dgvCTB_DSSP.CurrentRow.Cells[0].Value.ToString();
            txtCTB_SL.Text = dgvCTB_DSSP.CurrentRow.Cells[1].Value.ToString();
            txtCTB_DonGia.Text = dgvCTB_DSSP.CurrentRow.Cells[2].Value.ToString();

        }

        // Cell click load danh sách nhập
        void ChiTietHDN()
        {
            txtHDN_MaHDN.Text = dgvHDN_DSNhap.CurrentRow.Cells[0].Value.ToString();
            txtHDN_MaNV.Text = dgvHDN_DSNhap.CurrentRow.Cells[1].Value.ToString();
            txtHDN_MaNCC.Text = dgvHDN_DSNhap.CurrentRow.Cells[2].Value.ToString();
            dtHDN_NgayNhap.Text = dgvHDN_DSNhap.CurrentRow.Cells[3].Value.ToString();
        }

        //Cell click load danh sách NL theo HDn
        void ChiTietNL_HDN()
        {
            txtCTN_TenNL.Text = dgvCTN_DSNL.CurrentRow.Cells[0].Value.ToString();
            txtCTN_TenNCC.Text = dgvCTN_DSNL.CurrentRow.Cells[1].Value.ToString();
            txtCTN_DonGia.Text = dgvCTN_DSNL.CurrentRow.Cells[2].Value.ToString();
            txtCTN_SoLuong.Text = dgvCTN_DSNL.CurrentRow.Cells[3].Value.ToString();
        }


        #endregion

        
    }
}
