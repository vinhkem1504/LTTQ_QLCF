using Bunifu.Framework.Lib;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
            LoadInfoNhanVien(UserInfo.maNV);
            if (!UserInfo.chucVu)
            {
                LoadDataDSNhanVien();
            }
            LoadDataHoaDon();
            LoadDataSanPham();
            LoadDataNguyenLieu();
            LoadListBan();
            ResetSP();
            ResetNV();
            ResetNL();
            ResetHDB();
        }

        private void bbtnUser_Click(object sender, EventArgs e)
        {
            if (UserInfo.chucVu)
            {
                bpaPages.SelectedIndex = 7;
            }
            else
            {
                bpaPages.SelectedIndex = 0;
            }

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
            LoadDataHoaDon();
            bpaPages.SelectedIndex = 3;
        }

        // chi tiết hóa đơn bán
        private void bbtnCreateBill_Click(object sender, EventArgs e)
        {
            foreach (var sp in db.DoUongs)
            {
                cbbCTB_TenSP.Items.Add(sp.TenDU);
            }
            if (txtHD_MaHD.Text != "")
            {
                // Load thành danh sách SP theo hóa đơn
                var result = from c in db.ChiTietHDBs
                             where c.MaHDB == txtHD_MaHD.Text
                             select new { Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia };
                dgvCTB_DSSP.DataSource = result.ToList();

                // Load thông tin
                lblTenHoaDon.Text = "Hóa đơn : ";
                lblTenHoaDon.Text = lblTenHoaDon.Text + txtHD_MaHD.Text;

                tinhTienHDB();

                if(string.Compare(txtHD_TrangThai.Text,"Đã thanh toán") == 0)
                {
                    btnCTB_ThanhToanHoaDon.Visible = false;
                    btnCTB_SuaSP.Enabled = false;
                    btnCTB_ThemSP.Enabled = false;
                    btnCTB_XoaSP.Enabled = false;
                }
                else
                {
                    btnCTB_ThanhToanHoaDon.Visible = true;
                    btnCTB_SuaSP.Enabled = true;
                    btnCTB_ThemSP.Enabled = true;
                    btnCTB_XoaSP.Enabled = true;
                }
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

        private void btnCTB_ThanhToanHoaDon_Click(object sender, EventArgs e)
        {
            string[] l_string = lblTenHoaDon.Text.Split(' ');
            string maHDB = l_string[3];
            DataTable dtSP = new DataTable();
            foreach (DataGridViewColumn col in dgvCTB_DSSP.Columns)
            {
                dtSP.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvCTB_DSSP.Rows)
            {
                DataRow dRow = dtSP.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dtSP.Rows.Add(dRow);
            }

            //dgvSP = (DataTable)dgvCTB_DSSP.DataSource;
            string tongTien = txtCTB_TongTien.Text;
            DateTime ngayLap = dtHD_Ngaylap.Value;
            string maNV = txtHD_MaNV.Text;
            frmHoaDon cTietHDB = new frmHoaDon(maHDB, dtSP, tongTien, ngayLap, maNV);
            cTietHDB.ShowDialog();

            LoadListBan();
            dgvBan_ListHDB.DataSource = null;
            bpaPages.SelectedIndex = 8;
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
        private void btnBan_ThanhToan_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvBan_ListHDB.Rows.Count > 0)
                {
                    string maHDB = dgvBan_ListHDB.CurrentRow.Cells[0].Value.ToString();
                    string tongTien = dgvBan_ListHDB.CurrentRow.Cells[3].Value.ToString();
                    string maNV = dgvBan_ListHDB.CurrentRow.Cells[1].Value.ToString();
                    DateTime ngayLap = DateTime.Parse(dgvBan_ListHDB.CurrentRow.Cells[2].Value.ToString());
                    var result = from hdb in db.ChiTietHDBs
                                 where hdb.MaHDB == maHDB
                                 select new { hdb.DoUong.TenDU, hdb.SoLuongBan, hdb.DoUong.DonGia };

                    dgvCTB_DSSP.DataSource = result.ToList();
                    DataTable dtSP = new DataTable();
                    foreach (DataGridViewColumn col in dgvCTB_DSSP.Columns)
                    {
                        dtSP.Columns.Add(col.Name);
                    }

                    foreach (DataGridViewRow row in dgvCTB_DSSP.Rows)
                    {
                        DataRow dRow = dtSP.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }
                        dtSP.Rows.Add(dRow);
                    }
                    frmHoaDon cTietHDB = new frmHoaDon(maHDB, dtSP, tongTien, ngayLap, maNV);
                    cTietHDB.ShowDialog();

                    var maBan = db.HoaDonBans.Find(maHDB);

                    foreach (var table in db.Bans)
                    {
                        if (string.Compare(table.MaBan, maBan.MaBan) == 0)
                        {
                            table.TrangThai = true;
                        }
                    }
                    db.SaveChanges();
                    LoadListBan();
                    dgvBan_ListHDB.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Chọn hóa đơn muốn thanh toán !");
            }
        }

        private void bbtnLogout_Click(object sender, EventArgs e)
        {
            UserInfo.userName = "";
            UserInfo.passWord = "";
            UserInfo.email = "";
            UserInfo.chucVu = new bool();
            UserInfo.maNV = "";
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
            LoadListBan();
            bpaPages.SelectedIndex = 8;
        }

        private void btnBan_ThanhToan_Click(object sender, EventArgs e)
        {
            bpaPages.SelectedIndex = 4;
        }

        private void btnSP_CTSP_Click(object sender, EventArgs e)
        {
            if (txtSP_MaSp.Text != "")
            {
                // Load thành phần nguyên liệu
                var result = from c in db.CongThucDoUongs
                             where c.MaDU == txtSP_MaSp.Text
                             select new { c.NguyenLieu.MaNL, c.NguyenLieu.TenNL, c.SoLuong };
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
            txtNV_MaNV.Enabled = false;
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
            txtKho_MaNL.Enabled = false;
        }

        // Icon right click - tìm kiếm nguyên liệu
        private void bunifuTextBox2_OnIconRightClick(object sender, EventArgs e)
        {
            Search_DSNL(btxtSearch_NL.Text);
        }

        private void dgvSP_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietSP();
            txtSP_MaSp.Enabled = false;
        }

        private void dgvHD_DSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChiTietHDB();
            txtHD_MaHD.Enabled = false;
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
                lblCTN_TenHDN.Text = "Hóa đơn : ";
                lblCTN_TenHDN.Text = lblCTN_TenHDN.Text + txtHDN_MaHDN.Text;
                tinhTienHDN();
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

        // cập nhật thông tin nhân viên
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            updateInfoNhanVien();
        }

        // nhân viên chấm công
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            var chamCong = new ChiTietCaLam();
            var calam = from ca in db.CaLams
                        where ca.TenCa == cbbTTNV_CaLV.Text
                        select ca;
            var c = calam.First();

            chamCong.MaNV = txtTTNV_MaNV.Text;
            chamCong.MaCa = c.MaCa;
            chamCong.NgayLamViec = DateTime.Now;

            try
            {
                db.ChiTietCaLams.Add(chamCong);
                db.SaveChanges();
                MessageBox.Show("Chấm công thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hôm nay đã chấm công rồi !");
            }

        }

        // xem lương
        private void btnTTNV_Luong_Click(object sender, EventArgs e)
        {
            QLCafeEntities1 dt = new QLCafeEntities1();
            int thang = int.Parse(cbbTTNV_Thang.Text);
            int nam = int.Parse(txtTTNV_Nam.Text);
            try
            {
                var ctl = from ct in dt.ChiTietLuongs
                          where ct.MaNV == txtTTNV_MaNV.Text && ct.Thang == thang && nam == ct.Nam
                          select ct;
                var luong = ctl.First();
                txtTTNV_Luong.Text = luong.Luong.ToString();
            }
            catch (Exception ex)
            {
                txtTTNV_Luong.Text = "0";
            }

        }
        
        private void btnSP_ThemVaoHD_Click(object sender, EventArgs e)
        {
            /*ObjectParameter sl = new ObjectParameter("sL", typeof(int));
            db.Cau1_proc(txtSP_MaSp.Text, 2022, sl);
            if(sl.Value.ToString() != "")
            {
                MessageBox.Show("Đã bán được " + sl.Value.ToString() + " sản phẩm");
            }
            else
            {
                MessageBox.Show("Đã bán được 0 sản phẩm");
            }*/

        }

        private void btnDSNV_ChiTietNV_Click(object sender, EventArgs e)
        {
            try
            {
                LoadInfoNhanVien(txtNV_MaNV.Text);
                bpaPages.SelectedIndex = 7;
                if(UserInfo.maNV != txtNV_MaNV.Text)
                {
                    btnTTNV_ChamCong.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Hãy chọn nhân viên muốn xem thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHD_ThemHD_Click(object sender, EventArgs e)
        {
            frmHoaDonBan hdb = new frmHoaDonBan();
            hdb.ShowDialog();
        }

        private void btnBan_Them_Click_1(object sender, EventArgs e)
        {
            string maHDB = "";
            if (dgvBan_ListHDB.Rows.Count > 0)
            {
                maHDB = dgvBan_ListHDB.CurrentRow.Cells[0].Value.ToString();
                LoadChiTietHDB(maHDB);
            }
            else
                MessageBox.Show("Chọn hóa đơn");
        }

        private void cbbCTB_TenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = from sp in db.DoUongs
                         where sp.TenDU == cbbCTB_TenSP.Text
                         select new { sp.DonGia };
            txtCTB_DonGia.Text = result.First().DonGia.ToString();
            txtCTB_SL.Text = "1";
        }
        private void btnCTB_ThemSP_Click(object sender, EventArgs e)
        {
            addSanPham();

        }

        private void btnCTB_XoaSP_Click(object sender, EventArgs e)
        {
            delSanPham();

        }

        private void btnCTB_SuaSP_Click(object sender, EventArgs e)
        {
            updateSanPham();

        }
        #endregion


        #region Method

        //Load chi tiết hóa đơn
        private void LoadChiTietHDB(string MaHDB)
        {
            foreach (var sp in db.DoUongs)
            {
                cbbCTB_TenSP.Items.Add(sp.TenDU);
            }

            // Load thành danh sách SP theo hóa đơn
            var result = from c in db.ChiTietHDBs
                            where c.MaHDB == MaHDB
                            select new { Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia };
            dgvCTB_DSSP.DataSource = result.ToList();

            // Load thông tin
            lblTenHoaDon.Text = "Hóa đơn : ";
            lblTenHoaDon.Text = lblTenHoaDon.Text + MaHDB;

            var r = from v in db.Cau6_view
                         join hdb in db.HoaDonBans on v.MaHDB equals hdb.MaHDB
                         where hdb.MaBan == MaHDB
                         select new { v.TriGia };
            dgvBan_ListHDB.DataSource = result.ToList();

            tinhTienHDB();

            bpaPages.SelectedIndex = 4;


        }

        //Load info nhân viên
        void LoadInfoNhanVien(string maNV)
        {
            cbbTTNV_CaLV.Items.Clear();
            cbbTTNV_Thang.Items.Clear();
            txtTTNV_MaNV.Enabled = false;
            var infoNV = db.NhanViens.Find(maNV);
            txtTTNV_MaNV.Text = infoNV.MaNV.ToString();
            txtTTNV_HoTen.Text = infoNV.HoTen.ToString();
            txtTTNV_DiaChi.Text = infoNV.DiaChi.ToString();
            txtTTNV_SDT.Text = infoNV.SDT.ToString();
            dtTTNV_NgaySinh.Text = infoNV.NgaySinh.ToString();

            for (int i = 1; i < 13; i++)
            {
                cbbTTNV_Thang.Items.Add(i);
            }
            cbbTTNV_Thang.SelectedIndex = 0;
            foreach (var calam in db.CaLams)
            {
                cbbTTNV_CaLV.Items.Add(calam.TenCa);
            }
            cbbTTNV_CaLV.SelectedIndex = 0;
        }

        void LoadDataDSNhanVien()
        {
            //Phải join bảng để có lương
            var result = from c in db.NhanViens
                         select new { MaNV = c.MaNV, TenNV = c.HoTen, DiaChi = c.DiaChi, SDT = c.SDT, NgaySinh = c.NgaySinh, NgayNhapViec = c.NgayNhanViec, Luong = c.Luong.ToString()};
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
                         select new { MaNV = c.MaNV, TenNV = c.HoTen, DiaChi = c.DiaChi, SDT = c.SDT, NgaySinh = c.NgaySinh, NgayNhapViec = c.NgayNhanViec, Luong = c.Luong.ToString() };

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
            dtHD_Ngaylap.Text = dgvHD_DSHD.CurrentRow.Cells[2].Value.ToString();
            bool done = bool.Parse(dgvHD_DSHD.CurrentRow.Cells[3].Value.ToString());
            if (done == true)
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
            cbbCTB_TenSP.Text = dgvCTB_DSSP.CurrentRow.Cells[0].Value.ToString();
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
            txtCTN_DonGia.Text = dgvCTN_DSNL.CurrentRow.Cells[3].Value.ToString();
            txtCTN_SoLuong.Text = dgvCTN_DSNL.CurrentRow.Cells[2].Value.ToString();
        }

        // update thông tin nhân viên
        private void updateInfoNhanVien()
        {
            var result = from c in db.NhanViens
                         where c.MaNV == txtTTNV_MaNV.Text
                         select c;

            var userInfo = new NhanVien();
            userInfo = result.First();
            userInfo.HoTen = txtTTNV_HoTen.Text;
            userInfo.DiaChi = txtTTNV_DiaChi.Text;
            userInfo.SDT = txtTTNV_SDT.Text;
            userInfo.NgaySinh = DateTime.Parse(dtTTNV_NgaySinh.Text);
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tính tiền hóa đơn bán
        private void tinhTienHDB()
        {
            float tongTien = 0;
            for (int i = 0; i < dgvCTB_DSSP.Rows.Count; i++)
            {
                int sl = 0;
                float donGia = 0;
                sl = int.Parse(dgvCTB_DSSP.Rows[i].Cells[1].Value.ToString());
                donGia = float.Parse(dgvCTB_DSSP.Rows[i].Cells[2].Value.ToString());
                tongTien += sl * donGia;
            }

            txtCTB_TongTien.Text = tongTien.ToString();
        }

        // Tính tiền hóa đơn Nhập
        private void tinhTienHDN()
        {
            float tongTien = 0;
            for (int i = 0; i < dgvCTN_DSNL.Rows.Count; i++)
            {
                int sl = 0;
                float donGia = 0;
                sl = int.Parse(dgvCTN_DSNL.Rows[i].Cells[2].Value.ToString());
                donGia = float.Parse(dgvCTN_DSNL.Rows[i].Cells[3].Value.ToString());
                tongTien += sl * donGia;
            }

            txtCTN_TongTien.Text = tongTien.ToString();
        }

        //Sửa sản phẩm
        private void updateSanPham()
        {
            string[] l_string = lblTenHoaDon.Text.Split(' ');
            string MaHDB = l_string[3];

            if (cbbCTB_TenSP.Text != "")
            {
                var result = from c in db.ChiTietHDBs
                             where c.MaHDB == MaHDB && c.DoUong.TenDU == cbbCTB_TenSP.Text
                             select c;
                var up = new ChiTietHDB();
                up.MaHDB = result.First().MaHDB;
                up.MaDU = result.First().MaDU;
                up.KhuyenMai = result.First().KhuyenMai;
                up.SoLuongBan = int.Parse(txtCTB_SL.Text);

                db.ChiTietHDBs.Remove(result.First());
                db.ChiTietHDBs.Add(up);
                db.SaveChanges();
                MessageBox.Show("Sửa thành công !");
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm trước !");
                return;
            }

            var result1 = from c in db.ChiTietHDBs
                          where c.MaHDB == MaHDB
                          select new { Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia };
            dgvCTB_DSSP.DataSource = result1.ToList();
            tinhTienHDB();
        }
        //Xóa sản phẩm
        private void delSanPham()
        {
            string[] l_string = lblTenHoaDon.Text.Split(' ');
            string MaHDB = l_string[3];

            try
            {
                string tenSP = dgvCTB_DSSP.CurrentRow.Cells[0].Value.ToString();
                var result = from c in db.ChiTietHDBs
                             where c.DoUong.TenDU == tenSP && c.MaHDB == MaHDB
                             select c;
                db.ChiTietHDBs.Remove(result.First());
                db.SaveChanges();
                MessageBox.Show("Xóa thành công !");
                //MessageBox.Show(dgvCTB_DSSP.Rows.Count.ToString());

                var result1 = from c in db.ChiTietHDBs
                              where c.MaHDB == MaHDB
                              select new { Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia };
                dgvCTB_DSSP.DataSource = result1.ToList();

                if (dgvCTB_DSSP.Rows.Count == 0)
                {
                    var hdb = db.HoaDonBans.Find(MaHDB);
                    db.HoaDonBans.Remove(hdb);
                    LoadListBan();
                    db.SaveChanges();
                    bpaPages.SelectedIndex = 8;
                }
            }
            catch
            {
                MessageBox.Show("Không có sản phẩm !");
            }

            tinhTienHDB();
        }
        // Thêm SP
        private void addSanPham()
        {
            string maSp = "";
            if (cbbCTB_TenSP.Text != "")
            {
                var result = from sp in db.DoUongs
                             where sp.TenDU == cbbCTB_TenSP.Text
                             select new { sp.MaDU };
                maSp = result.First().MaDU;
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm trước !");
                return;
            }


            var r = new ChiTietHDB();
            string[] l_string = lblTenHoaDon.Text.Split(' ');
            r.MaHDB = l_string[3];
            r.MaDU = maSp;
            r.SoLuongBan = int.Parse(txtCTB_SL.Text);
            r.KhuyenMai = null;

            int d = 0;
            for (int i = 0; i < dgvCTB_DSSP.Rows.Count; i++)
            {
                string ten = dgvCTB_DSSP.Rows[i].Cells[0].Value.ToString();
                var sp = from c in db.DoUongs
                         where c.TenDU == ten
                         select new { c.MaDU };
                if (r.MaDU == sp.First().MaDU)
                {
                    var hdb = from c in db.ChiTietHDBs
                              where c.MaHDB == r.MaHDB && c.DoUong.TenDU == ten
                              select c;

                    var up = new ChiTietHDB();
                    up.MaHDB = hdb.First().MaHDB;
                    up.MaDU = hdb.First().MaDU;
                    up.KhuyenMai = hdb.First().KhuyenMai;
                    up.SoLuongBan = r.SoLuongBan + (int)dgvCTB_DSSP.Rows[i].Cells[1].Value;

                    db.ChiTietHDBs.Remove(hdb.First());
                    db.ChiTietHDBs.Add(up);
                    //r.SoLuongBan += (int)dgvCTB_DSSP.Rows[i].Cells[1].Value;
                    d++;
                    break;
                }
            }

            if (d == 0)
                db.ChiTietHDBs.Add(r);

            db.SaveChanges();

            LoadListBan();
            MessageBox.Show("Thêm thành công !");

            var result1 = from c in db.ChiTietHDBs
                          where c.MaHDB == r.MaHDB
                          select new { Ten = c.DoUong.TenDU, SoLuong = c.SoLuongBan, DonGia = c.DoUong.DonGia };
            dgvCTB_DSSP.DataSource = result1.ToList();

            tinhTienHDB();

        }


        private void LoadListBan()
        {
            QLCafeEntities1 dt = new QLCafeEntities1();
            floBan_ListBan.Controls.Clear();
            foreach (var table in dt.Bans)
            {
                table.TrangThai = true;
                //db.SaveChanges();
            }
            //db.SaveChanges();

            foreach (var table in dt.Bans)
            {
                var result = from hdb in dt.HoaDonBans
                             where hdb.MaBan == table.MaBan
                             select hdb;
                foreach (var b in result)
                {
                    if(b.TrangThai == false)
                    {
                        table.TrangThai = false;
                        break;
                    }
                }
                //db.SaveChanges();
            }
            db.SaveChanges();
            /*
            foreach (var hdb in db.HoaDonBans)
            {
                if (!hdb.TrangThai)
                {
                    foreach (var ban in db.Bans)
                    {
                        if (ban.MaBan == hdb.MaBan)
                        {
                            ban.TrangThai = false;
                            //db.SaveChanges();
                        }
                    }
                }
            }
            db.SaveChanges();*/
            /*
            foreach (var ban in db.Bans)
            {
                foreach(var hdb in db.HoaDonBans)
                {
                    if (!hdb.TrangThai)
                    {
                        ban.TrangThai = false;
                    }
                }
            }
            
            */
            foreach (var table in dt.Bans)
            {
                Button btn = new Button() { Width = 110, Height = 80 };
                btn.Text = table.MaBan.ToString();
                if (table.TrangThai) 
                {
                    btn.Click += new EventHandler(newHDB_TheoBan);
                    //LoadListBan();
                }
                else
                {
                    btn.Click += LoadListHDB_Ban;
                }
                if (table.TrangThai) btn.BackColor = Color.LightGoldenrodYellow;
                else btn.BackColor = Color.OrangeRed;
                floBan_ListBan.Controls.Add(btn);
            }
        }

        private void newHDB_TheoBan(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            frmHoaDonBan hdb = new frmHoaDonBan(btn.Text);
            hdb.ShowDialog();
            LoadListBan();
        }

        private void LoadListHDB_Ban(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            /*var result = from hdb in db.HoaDonBans join ctb in db.ChiTietHDBs on hdb.MaHDB equals ctb.MaHDB join du in db.DoUongs on ctb.MaDU equals du.MaDU
                         where hdb.MaBan == btn.Text && hdb.TrangThai == true
                         select new { hdb.MaHDB, hdb.MaNV, hdb.TrangThai};
            dgvBan_ListHDB.DataSource = result.ToList();*/

            var result = from v in db.Cau6_view
                         join hdb in db.HoaDonBans on v.MaHDB equals hdb.MaHDB
                         where hdb.MaBan == btn.Text && hdb.TrangThai == false
                         select new { v.MaHDB, v.MaNV, v.NgayLap, v.TriGia };
            dgvBan_ListHDB.DataSource = result.ToList();
        }
        void ResetNV()
        {
            txtNV_MaNV.Text = "";
            txtNV_TenNV.Text = "";
            txtNV_DiaChi.Text = "";
            txtNV_SDT.Text = "";
            dtNV_NTNS.Value = DateTime.Now;
            dtNV_NgayNhanViec.Value = DateTime.Now;
            txtNV_LuongCB.Text = "0";
            txtNV_MaNV.Enabled = true;
        }
        void ResetSP()
        {
            txtSP_MaSp.Text = "";
            txtSP_TenSp.Text = "";
            txtSP_DonGia.Text = "0";
            txtSP_MaSp.Enabled = true;
        }
        void ResetNL()
        {
            txtKho_MaNL.Text = "";
            txtKho_TenNL.Text = "";
            txtKho_Donvi.Text = "";
            txtKho_SL.Text = "0";
            txtKho_MaNL.Enabled = true;
        }
        void ResetHDB()
        {
            txtHD_MaHD.Text = "";
            txtHD_MaNV.Text = "";
            txtHD_TrangThai.Text = "";
            txtHD_Ghichu.Text = "";
            txtHD_MaHD.Enabled=true;
        }
        //Kiểm tra tính hoàn chỉnh dữ liệu của thông tin
        void KiemTraNV()
        {
            int dnv = 0;
            if (txtNV_MaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!");
                dnv=1;
            }
            if(txtNV_TenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!");
                dnv = 1;
            }
            if(txtNV_DiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                dnv = 1;
            }
            if (txtNV_SDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
                dnv = 1;
            }
            if (decimal.Parse(txtNV_LuongCB.Text) == 0)
            {
                MessageBox.Show("Bạn chưa nhập lương!");
                dnv = 1;
            }
            if (dnv == 1)
            {
                ResetNV();
            }
        }
        void KiemTraSP()
        {
            int dsp = 0;
            if (txtSP_MaSp.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm!");
                dsp = 1;
            }
            if (txtSP_TenSp.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm!");
                dsp = 1;
            }
            if (decimal.Parse(txtSP_DonGia.Text) == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!");
                dsp = 1;
            }
            if (dsp == 1)
            {
                ResetSP();
            }
        }
        void KiemTraNL()
        {
            int dnl = 0;
            if (txtKho_MaNL.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nguyên liệu!");
                dnl = 1;
            }
            if (txtKho_TenNL.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nguyên liệu!");
                dnl = 1;
            }
            if (txtKho_Donvi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị nguyên liệu!");
                dnl = 1;
            }
            if (float.Parse(txtKho_SL.Text) == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng nguyên liệu!");
                dnl = 1;
            }
            if (dnl == 1)
            {
                ResetNL();
            }
        }
        void KiemTraHDB()
        {
            int dhdb = 0;
            if(txtHD_MaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn!");
                dhdb = 1;
            }
            if(txtHD_MaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!");
                dhdb = 1;
            }
            if(txtHD_TrangThai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập trạng thái!");
                dhdb = 1;
            }
            if(dhdb == 1)
            {
                ResetHDB();
            }
        }
        //Thêm nhân viên
        private void btnNV_ThemNV_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien() { MaNV = txtNV_MaNV.Text, HoTen = txtNV_TenNV.Text, DiaChi = txtNV_DiaChi.Text, SDT = txtNV_SDT.Text, NgaySinh = DateTime.Parse(dtNV_NTNS.Text), NgayNhanViec = DateTime.Parse(dtNV_NgayNhanViec.Text), Luong = decimal.Parse(txtNV_LuongCB.Text) };
            KiemTraNV();
            if (txtNV_MaNV.Text != "")
            {
                if (txtNV_MaNV.Text == dgvNhanVien_DSNV.CurrentRow.Cells[0].Value.ToString())
                {
                    ResetNV();
                }
                else
                {
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadDataDSNhanVien();
                }
            }
        }
        //Sửa nhân viên
        private void btnNV_XoaNV_Click(object sender, EventArgs e)
        {
            var result = from c in db.NhanViens
                         where c.MaNV == txtNV_MaNV.Text
                         select c;

            var nv = new NhanVien();
            nv = result.First();
            nv.HoTen = txtNV_TenNV.Text;
            nv.DiaChi = txtNV_DiaChi.Text;
            nv.SDT = txtNV_SDT.Text;
            nv.NgaySinh = DateTime.Parse(dtNV_NTNS.Text);
            nv.NgayNhanViec = DateTime.Parse(dtNV_NgayNhanViec.Text);
            nv.Luong = decimal.Parse(txtNV_LuongCB.Text);
            KiemTraNV();
            if(txtNV_TenNV.Text != "")
            {
                db.SaveChanges();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataDSNhanVien();
        }
        //Xóa nhân viên
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Có hay Không",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    NhanVien nv = db.NhanViens.Where(p => p.MaNV == txtNV_MaNV.Text).SingleOrDefault();
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa!");
                }
                LoadDataDSNhanVien();
            }
        }
        //Thêm sản phẩm
        private void btnSP_ThemSp_Click(object sender, EventArgs e)
        {
            DoUong sp = new DoUong() { MaDU = txtSP_MaSp.Text, TenDU = txtSP_TenSp.Text, DonGia = decimal.Parse(txtSP_DonGia.Text) };
            KiemTraSP();
            if (txtSP_MaSp.Text != "") 
            {
                if (txtSP_MaSp.Text == dgvSP_DSSP.CurrentRow.Cells[0].Value.ToString())
                {
                    ResetSP();
                }
                else
                {
                    db.DoUongs.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadDataSanPham();
                }   
            }  
        }
        //Sửa sản phẩm
        private void btnSP_SuaSp_Click(object sender, EventArgs e)
        {
            var result = from c in db.DoUongs
                         where c.MaDU == txtSP_MaSp.Text
                         select c;

            var sp = new DoUong();
            sp = result.First();
            sp.TenDU = txtSP_TenSp.Text;
            sp.DonGia = decimal.Parse(txtSP_DonGia.Text);
            KiemTraSP();
            if (txtSP_MaSp.Text != "")
            {
                db.SaveChanges();
                LoadDataSanPham();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }
        //Xóa sản phẩm
        private void btnSP_XoaSp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Có hay Không",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DoUong sp = db.DoUongs.Where(p => p.MaDU == txtSP_MaSp.Text).SingleOrDefault();
                    db.DoUongs.Remove(sp);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa!");
                }
                LoadDataSanPham();
            }
        }
        //Thêm Nhiên liệu
        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            ResetNL();
            NguyenLieu nl = new NguyenLieu() { MaNL = txtKho_MaNL.Text, TenNL = txtKho_TenNL.Text, DonVi = txtKho_Donvi.Text, SoLuongTon = float.Parse(txtKho_SL.Text) };
            KiemTraNL();
            if(txtKho_MaNL.Text != "")
            {
                if (txtKho_MaNL.Text == dgvKho.CurrentRow.Cells[0].Value.ToString())
                {
                    ResetNL();
                }
                else
                {
                    db.NguyenLieux.Add(nl);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadDataNguyenLieu();
                }               
            }     
        }
        //Sửa thông tin nguyên liệu
        private void btnSuaHDN_Click(object sender, EventArgs e)
        {
            string maNL = "";
            maNL = txtKho_MaNL.Text;
            if(maNL != "")
            {
                NguyenLieu nl = db.NguyenLieux.Where(p => p.MaNL == maNL).SingleOrDefault();
                nl.TenNL = txtKho_TenNL.Text;
                nl.DonVi = txtKho_Donvi.Text;
                nl.SoLuongTon = int.Parse(txtKho_SL.Text);
                KiemTraNL();
                db.SaveChanges();
                LoadDataNguyenLieu();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*var result = from c in db.NguyenLieux
                         where c.MaNL == txtKho_MaNL.Text
                         select c;

            var nl = new NguyenLieu();
            nl = result.First();*/
            /*NguyenLieu nl = db.NguyenLieux.Where(p => p.MaNL == maNL).SingleOrDefault();
            nl.TenNL = txtKho_TenNL.Text;
            nl.DonVi = txtKho_Donvi.Text;
            nl.SoLuongTon = int.Parse(txtKho_SL.Text);
            KiemTraNL();
            if (txtKho_MaNL.Text != "")
            {
                db.SaveChanges();
                LoadDataNguyenLieu();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
        //Xóa nguyên liệu
        private void btnXoaHDN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Có hay Không",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    NguyenLieu nl = db.NguyenLieux.Where(p => p.MaNL == txtKho_MaNL.Text).SingleOrDefault();
                    db.NguyenLieux.Remove(nl);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa!");
                }
                LoadDataNguyenLieu();
            }
        }
        //Sửa thông tin hóa đơn
        private void btnHD_SuaHD_Click(object sender, EventArgs e)
        {
            /*var result = from c in db.HoaDonBans
                         where c.MaBan == txtHD_MaHD.Text
                         select c;

            var hdb = new HoaDonBan();
            hdb = result.First();*/
            HoaDonBan hdb = db.HoaDonBans.Where(p => p.MaHDB == txtHD_MaHD.Text).SingleOrDefault();
            hdb.MaNV = txtHD_MaNV.Text;
            hdb.NgayLap = DateTime.Parse(dtHD_Ngaylap.Text);
            if (txtHD_TrangThai.Text == "Đã thanh toán")
            {
                hdb.TrangThai = true;
            }
            if (txtHD_TrangThai.Text == "Chưa thanh toán")
            {
                hdb.TrangThai = false;
            }
            KiemTraHDB();
            if(txtHD_MaHD.Text != "")
            {
                db.SaveChanges();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataHoaDon();
        }
        //Xóa hóa đơn bán
        private void btnHD_XoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Có hay Không",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    HoaDonBan hdb = db.HoaDonBans.Where(p => p.MaHDB == txtHD_MaHD.Text).SingleOrDefault();
                    db.HoaDonBans.Remove(hdb);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa!");
                }
                LoadDataHoaDon();
            }
        }
        // Thong Ke
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                chart1.Visible = true;
                chart2.Visible = false;
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Thang";
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                /*    var result = from c in db.cau7_func(bdtpStartDate.Value, bdtpEndDate.Value)
                                 join x in db.cau8_func(bdtpStartDate.Value, bdtpEndDate.Value)
                                 on c.Thang equals x.Thang
                                 select new { c.Thang, c.DTBan, x.DTNhap };
                */

                var result = db.cau9_func(int.Parse(btnYear.Text));

                DataTable data = new DataTable();
                data.Columns.Add("Thang", typeof(int));
                data.Columns.Add("DTNhap", typeof(int));
                data.Columns.Add("DTBan", typeof(int));



                foreach (var i in result)
                {
                    DataRow row;
                    row = data.NewRow();
                    row["Thang"] = i.Thanga.Value;
                    row["DTBan"] = i.DTBan;
                    row["DTNhap"] = i.DTNhap;
                    data.Rows.Add(row);
                }


                for (int i = 0; i < data.Rows.Count; i++)
                {

                    chart1.Series["Ban"].Points.AddXY(data.Rows[i]["Thang"], data.Rows[i]["DTBan"]);
                    chart1.Series["Nhap"].Points.AddXY(data.Rows[i]["Thang"], data.Rows[i]["DTNhap"]);


                }

                lbDT.Text = "Thống kê năm " + btnYear.Text;

                //    dtgv.DataSource = data;
            }
            catch (Exception err)
            {
                //throw err;
                MessageBox.Show("Hãy chọn năm muốn xem");
            }

        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            try
            {
                var result = db.Cau2_view;
                chart1.Visible = false;
                chart2.Visible = true;
                lbDT.Text = "Top 5 đồ uống bán chạy nhất năm 2022";
                chart2.ChartAreas["ChartArea1"].AxisX.Title = "Ma do uong";
                chart2.ChartAreas["ChartArea1"].AxisY.Title = "SL Ban";

                //    dtgv.DataSource = result.ToList();

                DataTable data = new DataTable();
                data.Columns.Add("MaDU", typeof(string));
                data.Columns.Add("SLBan", typeof(int));

                foreach (var i in result)
                {
                    DataRow row;
                    row = data.NewRow();
                    row["MaDU"] = i.MaDU;
                    row["SLBan"] = i.SLBan.Value;
                    data.Rows.Add(row);
                }

                for (int i = 0; i < data.Rows.Count; i++)
                {

                    chart2.Series["SLBan"].Points.AddXY(data.Rows[i]["MaDU"], data.Rows[i]["SLBan"]);

                }
            }
            catch (Exception err)
            {
                //throw err;
                MessageBox.Show("Hãy chọn năm muốn xem");
            }

        }

        private void btnDoanhThu_Tong_Click(object sender, EventArgs e)
        {
            try
            {
                var tongDTBan = db.cau7_func(int.Parse(btnYear.Text));
                var tongDTNhap = db.cau8_func(int.Parse(btnYear.Text));

                //    txtSum.Text = "Ban: " + tongDTBan;

                DataTable data = new DataTable();
                data.Columns.Add("DTBan", typeof(int));
                DataTable data1 = new DataTable();
                data1.Columns.Add("DTNhap", typeof(int));



                foreach (var i in tongDTBan)
                {
                    DataRow row;
                    row = data.NewRow();

                    row["DTBan"] = i.DTBan;
                    data.Rows.Add(row);
                }

                foreach (var i in tongDTNhap)
                {
                    DataRow row;
                    row = data1.NewRow();
                    row["DTNhap"] = i.DTNhap;
                    data1.Rows.Add(row);
                }



                txtSum.Text = "Ban: " + data.Rows[0][0].ToString() + " Nhap: " + data1.Rows[0][0].ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Hãy chọn năm muốn xem");
            }
        }
    }
}
#endregion