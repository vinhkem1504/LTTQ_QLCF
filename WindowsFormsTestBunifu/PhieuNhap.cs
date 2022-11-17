using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        bool isInsertMode = false;
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
            cbbMaNCC.SelectedIndex = -1;
            if (btnCapNhatNCC.Text == "Cập nhật NCC")
            {
                txtTenNCC.ReadOnly = txtDiaChiNCC.ReadOnly = txtDienThoaiNCC.ReadOnly = false;
                btnXoaNCC.Enabled = false;
                btnCapNhatNCC.Text = "Lưu thay đổi";
            }
            else if(btnCapNhatNCC.Text == "Lưu thay đổi")
            {
                string id = cbbMaNCC.Text != "" ? cbbMaNCC.Text : Autocode(db.NhaCungCaps, "NCC" + 
                                                                           DateTime.Now.Day.ToString() + 
                                                                           DateTime.Now.Month.ToString() + 
                                                                           DateTime.Now.Year.ToString());
                if(id == cbbMaNCC.Text)
                {
                    var ncc = db.NhaCungCaps.Find(id);
                    ncc.TenNCC = txtTenNCC.Text;
                    ncc.DiaChi = txtDiaChiNCC.Text;
                    ncc.SDT = txtDienThoaiNCC.Text;
                } 
                else
                {
                    db.NhaCungCaps.Add(new NhaCungCap()
                    {
                        MaNCC = id,
                        TenNCC = txtTenNCC.Text,
                        DiaChi = txtDiaChiNCC.Text,
                        SDT = txtDienThoaiNCC.Text
                    });
                }
                db.SaveChanges();
                LoadCbbMaNhaCungCap();
                txtTenNCC.ReadOnly = txtDiaChiNCC.ReadOnly = txtDienThoaiNCC.ReadOnly = true;
                btnXoaNCC.Enabled = true;
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

            }
            catch (Exception)
            {
                MessageBox.Show("Chưa chọn nhà cung cấp muốn xóa", "Thông báo");
            }


        }
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (cbbMaNL.SelectedIndex != -1)
            {
                if (txtSoLuongNhap.Text == String.Empty)
                {
                    MessageBox.Show("Bạn chưa đặt số lượng muốn nhập!", "Thông báo");
                    return;
                }
                addNguyenLieu();
            }
        }
        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            string maNL = String.Empty;
            decimal tienTru = 0;
            try
            {
                maNL = dgvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                tienTru = decimal.Parse(dgvChiTietPhieuNhap.CurrentRow.Cells[3].Value.ToString());
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
            catch
            {
                MessageBox.Show("Xin chọn nguyên liệu cần xóa !", "Thông báo");
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
