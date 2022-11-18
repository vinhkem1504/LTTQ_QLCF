using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmPhieuNhap : Form
    {
        QLCafeEntities1 db = new QLCafeEntities1();
        DataTable table_ChiTietHDN = new DataTable();
        bool success = false;
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
            LoadDataGridView();
            cbbMaNCC.SelectedIndex = -1;
            cbbMaNL.SelectedIndex = -1;
        }
        private void frmPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (success == true)
            {
                return;
            }
            if (MessageBox.Show("Bạn chưa hoàn tất thanh toán! Chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btnXacNhanLap_Click(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa lựa chọn nhà cung cấp!", "Thông báo");
                return;
            }

            if (table_ChiTietHDN.Rows.Count == 0)
            {
                MessageBox.Show("Chưa thêm nguyên liệu nhập!", "Thông báo");
                return;
            }
            insertCTHDN();
            success = true;
            MessageBox.Show("Lập hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbbMaNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNL.SelectedIndex == -1)
            {
                txtTenNL.Text = String.Empty;
                txtDonViNL.Text = String.Empty;
                txtDonGiaNL.Text = String.Empty;
                return;
            }
            txtSoLuongNhap.ReadOnly = false;
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(cbbMaNL.Text);
            txtTenNL.Text = nguyenLieu.TenNL;
            txtDonViNL.Text = nguyenLieu.DonVi;
            txtDonGiaNL.Text = nguyenLieu.DonGia.ToString();
        }
        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedIndex == -1)
            {
                txtTenNCC.Text = String.Empty;
                txtDiaChiNCC.Text = String.Empty;
                txtDienThoaiNCC.Text = String.Empty;
                return;
            }
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(cbbMaNCC.Text);
            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDiaChiNCC.Text = nhaCungCap.DiaChi;
            txtDienThoaiNCC.Text = nhaCungCap.SDT;
        }
        private void btnCapNhatNCC_Click(object sender, EventArgs e)
        {
            if (btnCapNhatNCC.Text == "Cập nhật NCC")
            {
                cbbMaNCC.SelectedIndex = -1;
                txtTenNCC.ReadOnly = txtDiaChiNCC.ReadOnly = txtDienThoaiNCC.ReadOnly = false;
                btnXoaNCC.Enabled = false;
                txtTenNCC.Focus();
                btnCapNhatNCC.Text = "Lưu thay đổi";
            }
            else if (btnCapNhatNCC.Text == "Lưu thay đổi")
            {
                string id = cbbMaNCC.Text != "" ? cbbMaNCC.Text : Autocode(db.NhaCungCaps, "NCC" +
                                                                           DateTime.Now.Day.ToString() +
                                                                           DateTime.Now.Month.ToString() +
                                                                           DateTime.Now.Year.ToString());
                if (id == cbbMaNCC.Text)
                {
                    var ncc = db.NhaCungCaps.Find(id);
                    ncc.TenNCC = (txtTenNCC.Text == String.Empty) ? "Chưa nhập tên" : txtTenNCC.Text;
                    ncc.DiaChi = (txtDiaChiNCC.Text == String.Empty) ? "Chưa nhập địa chỉ" : txtDiaChiNCC.Text;
                    ncc.SDT = (txtDienThoaiNCC.Text == String.Empty) ? "Chưa nhập số điện thoại" : txtDienThoaiNCC.Text;
                }
                else
                {
                    db.NhaCungCaps.Add(new NhaCungCap()
                    {
                        MaNCC = id,
                        TenNCC = txtTenNCC.Text == String.Empty ? "Chưa nhập tên" : txtTenNCC.Text,
                        DiaChi = (txtDiaChiNCC.Text == String.Empty) ? "Chưa nhập địa chỉ" : txtDiaChiNCC.Text,
                        SDT = (txtDienThoaiNCC.Text == String.Empty) ? "Chưa nhập số điện thoại" : txtDienThoaiNCC.Text
                    });
                }

                db.SaveChanges();
                MessageBox.Show($"Đã thêm cập nhật nhà cung cấp có mã {id}", "Thông báo");
                LoadCbbMaNhaCungCap();
                txtTenNCC.ReadOnly = txtDiaChiNCC.ReadOnly = txtDienThoaiNCC.ReadOnly = true;
                btnXoaNCC.Enabled = true;
                cbbMaNCC.SelectedIndex = -1;
                btnCapNhatNCC.Text = "Cập nhật NCC";
            }
        }

        private object cbbGetSelectedItem()
        {
            return cbbMaNCC.SelectedItem;
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                var hdn_ncc = (from hdn in db.HoaDonNhaps
                               select hdn.MaNCC).ToList();
                if (hdn_ncc.Contains(cbbMaNCC.Text))
                {
                    MessageBox.Show("Nhà cung cấp đã có hóa đơn nhập.\nMời xóa hóa đơn nhập trước khi xóa nhà cung cấp!", "Thông báo");
                    return;
                }

                var ncc = db.NhaCungCaps.Find(cbbMaNCC.Text);

                db.NhaCungCaps.Remove(ncc);
                db.SaveChanges();
                LoadCbbMaNhaCungCap();
                cbbMaNCC.SelectedIndex = -1;
                MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Chưa chọn nhà cung cấp muốn xóa", "Thông báo");
            }
        }
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (cbbMaNL.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nguyên liệu muốn nhập!", "Thông báo");
                return;
            }
            if (txtSoLuongNhap.Text == String.Empty)
            {
                MessageBox.Show("Bạn chưa đặt số lượng muốn nhập!", "Thông báo");
                return;
            }
            addNguyenLieu();
        }
        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            string maNL = String.Empty;
            decimal tienTru = 0;
            try
            {
                if (dgvChiTietPhieuNhap.Rows.Count == 1)
                {
                    MessageBox.Show("Danh sách nguyên liệu nhập trống!", "Thông báo");
                    return;
                }
                maNL = dgvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                tienTru = decimal.Parse(dgvChiTietPhieuNhap.CurrentRow.Cells[4].Value.ToString());
                foreach (DataRow row in table_ChiTietHDN.Rows)
                {
                    if (row.ItemArray[0].ToString() == maNL)
                    {
                        table_ChiTietHDN.Rows.Remove(row);
                        break;
                    }
                }
                txtTongTienPhieuNhap.Text = (decimal.Parse(txtTongTienPhieuNhap.Text) - tienTru).ToString();
                dgvChiTietPhieuNhap.DataSource = table_ChiTietHDN;
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo");
            }
        }
        private void txtSoLuongNL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (int)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtSoLuongNL_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = (txtSoLuongNhap.Text == String.Empty) ? "0" : (int.Parse(txtSoLuongNhap.Text) * decimal.Parse(txtDonGiaNL.Text)).ToString();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbMaNCC.SelectedIndex = -1;
        }
        #endregion
        #region Method
        private void LoadDataGridView()
        {
            table_ChiTietHDN.Columns.Add("Mã nguyên liệu", typeof(string));
            table_ChiTietHDN.Columns.Add("Tên nguyên liệu", typeof(string));
            table_ChiTietHDN.Columns.Add("Đơn vị", typeof(string));
            table_ChiTietHDN.Columns.Add("Số lượng nhập", typeof(int));
            table_ChiTietHDN.Columns.Add("Thành tiền", typeof(decimal));
            dgvChiTietPhieuNhap.DataSource = table_ChiTietHDN;
        }
        private void LoadCbbMaNhaCungCap()
        {
            cbbMaNCC.DataSource = (from ncc in db.NhaCungCaps select ncc.MaNCC).ToList();
        }
        private void LoadCbbMaNguyenLieu()
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
            return code;
        }
        private void addNguyenLieu()
        {
            DataRow row;
            row = table_ChiTietHDN.NewRow();
            row["Mã nguyên liệu"] = cbbMaNL.SelectedItem.ToString();
            row["Tên nguyên liệu"] = txtTenNL.Text;
            row["Đơn vị"] = txtDonViNL.Text;
            row["Số lượng nhập"] = int.Parse(txtSoLuongNhap.Text);
            row["Thành tiền"] = decimal.Parse(txtThanhTien.Text);

            if (table_ChiTietHDN.Rows.Count > 0)
            {
                bool exist = false;
                for (int i = 0; i < table_ChiTietHDN.Rows.Count; i++)
                {
                    if (string.Compare(row["Mã nguyên liệu"].ToString(), table_ChiTietHDN.Rows[i]["Mã nguyên liệu"].ToString()) == 0)
                    {
                        DataRow temp = table_ChiTietHDN.NewRow();
                        temp["Mã nguyên liệu"] = table_ChiTietHDN.Rows[i]["Mã nguyên liệu"];
                        temp["Tên nguyên liệu"] = table_ChiTietHDN.Rows[i]["Tên nguyên liệu"];
                        int sln = int.Parse(txtSoLuongNhap.Text);
                        decimal thanhTien = decimal.Parse(txtThanhTien.Text);
                        sln = int.Parse(table_ChiTietHDN.Rows[i]["Số lượng nhập"].ToString()) + sln;
                        thanhTien = decimal.Parse(table_ChiTietHDN.Rows[i]["Thành tiền"].ToString()) + thanhTien;
                        temp["Số lượng nhập"] = sln;
                        temp["Thành tiền"] = thanhTien;
                        table_ChiTietHDN.Rows[i]["Số lượng nhập"] = temp["Số lượng nhập"];
                        table_ChiTietHDN.Rows[i]["Thành tiền"] = temp["Thành tiền"];
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    table_ChiTietHDN.Rows.Add(row);
                }
            }
            else
            {
                table_ChiTietHDN.Rows.Add(row);
            }

            decimal tongTien = 0;
            for (int i = 0; i < table_ChiTietHDN.Rows.Count; i++)
            {
                tongTien += decimal.Parse(table_ChiTietHDN.Rows[i]["Thành tiền"].ToString());
            }
            dgvChiTietPhieuNhap.DataSource = table_ChiTietHDN;
            txtTongTienPhieuNhap.Text = tongTien.ToString();
        }
        private void insertCTHDN()
        {
            HoaDonNhap hdn = new HoaDonNhap()
            {
                MaHDN = txtMaPhieuNhap.Text,
                NgayLap = dtpNgayLap.Value,
                MaNV = UserInfo.maNV,
                MaNCC = cbbMaNCC.SelectedItem.ToString()
            };
            db.HoaDonNhaps.Add(hdn);

            foreach (DataRow row in table_ChiTietHDN.Rows)
            {
                ChiTietHDN chiTietHDN = new ChiTietHDN()
                {
                    MaHDN = txtMaPhieuNhap.Text,
                    MaNL = row[0].ToString(),
                    SoLuongNhap = int.Parse(row[2].ToString())
                };
                db.ChiTietHDNs.Add(chiTietHDN);
            }
            db.SaveChanges();
        }
        #endregion
    }
}
