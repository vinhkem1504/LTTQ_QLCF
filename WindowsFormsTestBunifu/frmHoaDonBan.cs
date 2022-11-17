using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsTestBunifu
{
    public partial class frmHoaDonBan : Form
    {
        bool check = false;
        int tongTien = 0;


        QLCafeEntities1 dt = new QLCafeEntities1();
        DataTable table_DSSP = new DataTable();
        #region events
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void btnCTB_ThemSP_Click(object sender, EventArgs e)
        {
            addSanPham();
        }

        private void btnCTB_XoaSP_Click(object sender, EventArgs e)
        {
            deleteSanPham();
        }
        #endregion
        #region methods
        // Tính tiền hóa đơn
        private void tinhTongTien()
        {

        }
        // Lưu hóa đơn vào database
        private void insertHDB()
        {
            check = true;

            var hdb = new HoaDonBan();
            hdb.MaHDB = txtHDB_MaHDB.Text;
            hdb.MaBan = cbbHDB_MaBan.Text;
            hdb.MaNV = cbbHDB_MaNV.Text;
            hdb.NgayLap = dtHDB_Ngaylap.Value;
            hdb.TrangThai = false;
            dt.HoaDonBans.Add(hdb);

            foreach (DataRow items in table_DSSP.Rows)
            {
                var chiTietBan = new ChiTietHDB();
                chiTietBan.MaDU = items.ItemArray[0].ToString();
                chiTietBan.SoLuongBan = int.Parse(items.ItemArray[2].ToString());
                chiTietBan.MaHDB = txtHDB_MaHDB.Text;
                dt.ChiTietHDBs.Add(chiTietBan);
            }
            dt.SaveChanges();

            MessageBox.Show("Tạo hóa đơn thành công !");
            this.Close();
        }

        // Xóa sản phẩm
        private void deleteSanPham()
        {
            string maSP = "";
            string sl = "";
            int tienTru = 0;
            int donGia = 0;
            try
            {

                foreach (DataRow row in table_DSSP.Rows)
                {
                    maSP = dgvHDB_DSSP.CurrentRow.Cells[0].Value.ToString();
                    sl = dgvHDB_DSSP.CurrentRow.Cells[2].Value.ToString();
                    if (row.ItemArray[0].ToString() == maSP && row.ItemArray[2].ToString() == sl)
                    {
                        table_DSSP.Rows.Remove(row);
                        break;
                    }
                }

                if (tongTien > 0)
                {
                    var result = dt.DoUongs.Find(maSP);
                    donGia = (int)(result.DonGia);
                }

                tienTru = donGia * int.Parse(sl);
                if (tongTien > 0)
                    tongTien -= tienTru;
                txtHDB_TongTien.Text = tongTien.ToString();
                dgvHDB_DSSP.DataSource = table_DSSP;
            }
            catch
            {
                MessageBox.Show("Xin chọn sản phẩm cần xóa !");
            }
        }

        //Thêm sản phẩm vào table
        private void addSanPham()
        {
            DataRow r;
            int donGia = 0;
            r = table_DSSP.NewRow();
            var result = from sp in dt.DoUongs
                         where sp.TenDU == cbbHDB_TenSp.Text
                         select new { sp.MaDU, sp.DonGia };

            r["MaSP"] = result.First().MaDU;
            r["TenSP"] = cbbHDB_TenSp.Text;
            r["SL"] = int.Parse(txtHDB_Soluong.Text);

            if (table_DSSP.Rows.Count > 0)
            {
                int d = 0;
                for (int j = 0; j < table_DSSP.Rows.Count; j++)
                {
                    if (string.Compare(r["MaSP"].ToString(), table_DSSP.Rows[j]["MaSP"].ToString()) == 0)
                    {
                        DataRow dr = table_DSSP.NewRow();
                        dr["MaSP"] = table_DSSP.Rows[j]["MaSP"];
                        dr["TenSP"] = table_DSSP.Rows[j]["TenSP"];
                        int slb = int.Parse(txtHDB_Soluong.Text);
                        slb = int.Parse(table_DSSP.Rows[j]["SL"].ToString()) + slb;
                        dr["SL"] = slb;
                        table_DSSP.Rows[j]["SL"] = dr["SL"];
                        d++;
                    }
                }
                if (d == 0)
                {
                    table_DSSP.Rows.Add(r);
                }
            }
            else
                table_DSSP.Rows.Add(r);

            //donGia = result.First().DonGia;
            //MessageBox.Show(donGia.ToString());
            donGia = (int)(result.First().DonGia);

            tongTien += Convert.ToInt32((r.ItemArray[2].ToString())) * donGia;

            dgvHDB_DSSP.DataSource = table_DSSP;
            txtHDB_TongTien.Text = tongTien.ToString();
            //dgvHDB_DSSP.DataSource = result.ToList();
        }

        // sinh mã hóa đơn
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

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            txtHDB_MaHDB.Text = Autocode(dt.HoaDonBans, "HDB");
            table_DSSP.Columns.Add("MaSP", typeof(string));
            table_DSSP.Columns.Add("TenSP", typeof(string));
            table_DSSP.Columns.Add("SL", typeof(int));
            dgvHDB_DSSP.DataSource = table_DSSP;

            foreach (var b in dt.Bans)
            {
                if (b.TrangThai)
                {
                    cbbHDB_MaBan.Items.Add(b.MaBan);
                }
            }

            foreach (var nv in dt.NhanViens)
            {
                cbbHDB_MaNV.Items.Add(nv.MaNV);
            }

            foreach (var sp in dt.DoUongs)
            {
                cbbHDB_TenSp.Items.Add(sp.TenDU);
            }
            cbbHDB_TenSp.SelectedIndex = 0;
            txtHDB_Soluong.Text = "1";
        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!check)
            {
                if (MessageBox.Show("Chưa hoàn thành hóa đơn. Thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnHDB_HuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHDB_XacNhan_Click(object sender, EventArgs e)
        {
            insertHDB();
        }
    }
}
