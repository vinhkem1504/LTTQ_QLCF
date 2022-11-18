using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsTestBunifu
{
    public partial class frmHoaDon : Form
    {
        QLCafeEntities1 db = new QLCafeEntities1();

        bool success = false;
        public frmHoaDon()
        {
            InitializeComponent();
        }


        public frmHoaDon(string maHDB, DataTable dtSP, string tongTien, DateTime ngayLap, string maNV)
        {
            InitializeComponent();
            txtMaHD.Text += maHDB;
            dgvSP.DataSource = dtSP;
            txtTongTien.Text = tongTien;
            dtpNgayBan.Value = ngayLap;
            txtMaNV.Text = maNV;
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

        /*private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Đã in hóa đơn thành công !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                success = true;
                this.Close();
            }
            
        }*/

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string[] l_string = txtMaHD.Text.Split(' ');
            var result = db.HoaDonBans.Find(l_string[4]);

            var hdb = new HoaDonBan();
            hdb = result;
            hdb.TrangThai = true;
            db.SaveChanges();


            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            try
            {
                //in tên
                Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1];
                exRange.Font.Size = 15;
                exRange.Font.Bold = true;
                exRange.Font.Color = Color.Green;
                exRange.Value = lblLogo.Text;

                //in địa chỉ
                Excel.Range dc = (Excel.Range)exSheet.Cells[2, 1];
                dc.Font.Size = 13;
                dc.Font.Color = Color.Green;
                dc.Value = lblDiaChi.Text;

                //in SDT
                Excel.Range sdt = (Excel.Range)exSheet.Cells[3, 1];
                sdt.Font.Size = 13;
                sdt.Font.Color = Color.Green;
                sdt.Value = lblSDT.Text;
                //in chữ hóa đơn bán
                exSheet.Range["D4"].Font.Size = 20;
                exSheet.Range["D4"].Font.Bold = true;
                exSheet.Range["D4"].Font.Color = Color.Red;
                exSheet.Range["D4"].Value = "HOÁ ĐƠN BÁN";

                //in ra các thông tin mã hóa đơn
                exSheet.Range["A5:A8"].Font.Size = 13;
                exSheet.Range["A5"].Value = txtMaHD.Text;
                exSheet.Range["A5"].Font.Color = Color.Green;

                //in các dòng tiêu đề
                exSheet.Range["A7:G7"].Font.Size = 12;
                exSheet.Range["A7:G7"].Font.Bold = true;
                exSheet.Range["C7"].Value = "STT";
                exSheet.Range["C7"].ColumnWidth = 20;
                exSheet.Range["D7"].Value = "Tên sản phẩm";
                exSheet.Range["D7"].ColumnWidth = 20;
                exSheet.Range["E7"].Value = "Đơn giá";
                exSheet.Range["E7"].ColumnWidth = 20;
                exSheet.Range["F7"].Value = "Số lượng";
                exSheet.Range["F7"].ColumnWidth = 20;

                //in ra danh sách các chi tiết sản phẩm trong hóa đơn
                int dong = 8;
                for (int i = 0; i < dgvSP.Rows.Count - 1; i++)
                {
                    exSheet.Range["C" + (dong + i).ToString()].Value = (i + 1).ToString();
                    exSheet.Range["D" + (dong + i).ToString()].Value = dgvSP.Rows[i].Cells[0].Value.ToString();
                    exSheet.Range["F" + (dong + i).ToString()].Value = dgvSP.Rows[i].Cells[1].Value.ToString();
                    exSheet.Range["E" + (dong + i).ToString()].Value = dgvSP.Rows[i].Cells[2].Value.ToString() + " VNĐ";
                }
                dong = dong + dgvSP.Rows.Count;

                //tính tiền hóa đơn
                exSheet.Range["F" + dong.ToString()].Font.Size = 12;
                exSheet.Range["F" + dong.ToString()].Value = "Tổng tiền: " + txtTongTien.Text;
                exSheet.Range["F" + dong.ToString()].ColumnWidth = 20;
                exSheet.Range["F" + (dong + 1).ToString()].Font.Size = 12;
                exSheet.Range["F" + (dong + 1).ToString()].Value = "Khách trả: " + txtKhachTra.Text;
                exSheet.Range["F" + (dong + 1).ToString()].ColumnWidth = 20;
                exSheet.Range["F" + (dong + 2).ToString()].Font.Size = 12;
                exSheet.Range["F" + (dong + 2).ToString()].Value = "Tiền thừa: " + txtTienThua.Text;
                exSheet.Range["F" + (dong + 2).ToString()].ColumnWidth = 20;

                //mã nhân viên và ngày bán
                exSheet.Range["A" + dong.ToString()].Font.Size = 12;
                exSheet.Range["A" + dong.ToString()].Value = "Mã nhân viên: " + txtMaNV.Text;
                exSheet.Range["A" + dong.ToString()].Font.Size = 12;
                exSheet.Range["A" + dong.ToString()].Value = "Ngày bán: " + dtpNgayBan.Value.Date;



                exBook.Activate();
                //lưu file
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(save.FileName.ToLower());
                }
                else
                {
                    return;
                }
                exApp.Quit();

                if (MessageBox.Show("Đã in hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    success = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*if (MessageBox.Show("Đã in hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                success = true;
                this.Close();
            }*/
        }

        private void txtKhachTra_TextChanged(object sender, EventArgs e)
        {
            int tienThua = 0;
            int tongTien = 0;
            int khachTra = 0;

            string[] l_string = txtTongTien.Text.Split('.');

            try
            {
                tongTien = int.Parse(l_string[0]);
                khachTra = int.Parse(txtKhachTra.Text);

                tienThua = khachTra - tongTien;
                if (tienThua < 0)
                {
                    txtTienThua.Text = "error";
                    bunifuThinButton21.Visible = false;
                }
                else
                {
                    txtTienThua.Text = tienThua.ToString();
                    bunifuThinButton21.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
