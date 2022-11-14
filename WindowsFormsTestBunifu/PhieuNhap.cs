using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmPhieuNhap : Form
    {
        ChiTietHDN result = new ChiTietHDN();
        bool success = false;
        QLCafeEntities db = new QLCafeEntities();
        bool confirmMode = false;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }


        #region Events
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            SetupImportContractInfo();
            LoadCbbMaNhaCungCap();
            LoadCbbMaNguyenLieu();
        }

        private void btnXacNhanLap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lập hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Xử lý dữ liệu
            HoaDonNhap hdn = new HoaDonNhap()
            {
                MaHDN = txtMaPhieuNhap.Text,
                NgayLap = dtpNgayLap.Value,
                MaNV = UserInfo.maNV,
                MaNCC = txtTenNCC.Text
            };
            db.HoaDonNhaps.Add(hdn);
            db.SaveChanges();
            success = true;
            this.Close();
        }

        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chưa hoàn tất thanh toán! Chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Xử lý dữ liệu

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
        private void cbbMaNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNL.SelectedIndex == -1)
            {
                return;
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(cbbMaNL.Text);
            txtTenNL.Text = nguyenLieu.TenNL;
            txtDonViNL.Text = nguyenLieu.DonVi;
            txtDonGiaNL.Text = nguyenLieu.DonGia.ToString();
        }
        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedIndex == -1)
            {
                return;
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(cbbMaNCC.Text);
            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDiaChiNCC.Text = nhaCungCap.DiaChi;
            txtDienThoaiNCC.Text = nhaCungCap.SDT;
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (!confirmMode)
            {
                cbbMaNCC.DropDownStyle = ComboBoxStyle.DropDown;
                txtTenNCC.ReadOnly = txtDiaChiNCC.ReadOnly = txtDienThoaiNCC.ReadOnly = false;
                txtTenNCC.Text = "";
            }
            else
            {
                confirmMode = !confirmMode;
                if (db.NhaCungCaps.Find(cbbMaNCC.Text) != null)
                {
                    return;
                }
            }
        }
        #endregion
        #region Method
        void LoadCbbMaNhaCungCap()
        {
            cbbMaNCC.DataSource = (from ncc in db.NhaCungCaps select ncc.MaNCC).ToList();
            //cbbTenNCC.ValueMember = 
        }

        void LoadCbbMaNguyenLieu()
        {
            cbbMaNL.DataSource = (from nl in db.NguyenLieux select nl.MaNL).ToList();
        }

        private void SetupImportContractInfo()
        {
            //Tạo mã phiếu nhập
            string maPhieuNhap = "HDN" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            txtMaPhieuNhap.Text = Autocode(db.HoaDonNhaps, maPhieuNhap);

            dtpNgayLap.Value = DateTime.Now;

            txtMaNV.Text = UserInfo.maNV;
            txtTenNV.Text = db.NhanViens.Find(UserInfo.maNV).HoTen.ToString();
        }

        private string Autocode(DbSet table, string startValue)
        {
            string code;
            int id = 0;
            do
            {
                code = startValue + id.ToString();
                if (table.Find(code) == null)
                {
                    return code;
                }
                ++id;
            } while (true);
        }
        #endregion

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {

        }
    }
}
