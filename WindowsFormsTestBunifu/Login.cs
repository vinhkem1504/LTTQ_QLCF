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

    public partial class frmLogin : Form
    {
        private QLCafeEntities1 db = new QLCafeEntities1();
        private int login = 0;
        private string username = "";
        private string password = "";
        private string email = "";
        private string maNV = "";
        private bool chucvu = true;

        public frmLogin()
        {
            InitializeComponent();
        }
        #region Methods

        private void makeEmpty()
        {
            btxtPassword.Text = "";
            btxtUsername.Text = "";
            //btxtUsername.Focus();
        }

        private bool isCorrectAccount(string username, string password, DataTable dt)
        {
            bool login = false;

            foreach(DataRow check in dt.Rows)
            {
                if(String.Compare(username, check[0].ToString(), false) == 0 && String.Compare(password, check[1].ToString(), false) == 0) 
                { 
                    maNV = check[3].ToString();
                    //MessageBox.Show(chucvu.ToString());
                    chucvu = bool.Parse(check[4].ToString());
                    login = true;
                    break; 
                }
            }

            return login;
        }

        private bool isCorrectEmail(string email, DataTable dt)
        {
            bool corect = false;

            foreach (DataRow check in dt.Rows)
            {
                if (String.Compare(email, check[2].ToString(), false) == 0 )
                { corect = true; break; }
            }

            return corect;
        }

        private DataTable createData() {
            var result = from c in db.TaiKhoans
                         select new { c.TenTK, c.MatKhau, c.Email, c.NhanVien.MaNV, c.LoaiTK };

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("tk", typeof(string)));
            dt.Columns.Add(new DataColumn("mk", typeof(string)));
            dt.Columns.Add(new DataColumn("email", typeof(string)));
            dt.Columns.Add(new DataColumn("manv", typeof(string)));
            dt.Columns.Add(new DataColumn("chucvu", typeof(bool)));

            foreach (var v in result)
            {
                DataRow r;
                r = dt.NewRow();
                r["tk"] = v.TenTK;
                r["mk"] = v.MatKhau;
                r["email"] = v.Email;
                r["manv"] = v.MaNV;
                r["chucvu"] = v.LoaiTK;
                dt.Rows.Add(r);
            }

            return dt;
        }
        #endregion
        #region events
        private void btxtPassword_OnValueChanged(object sender, EventArgs e)
        {
            btxtPassword.UseSystemPasswordChar = true;
        }

        // Load form
        private void Login_Load(object sender, EventArgs e)
        {
            bimgUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\user.png");
            bimgPassword.Image = Image.FromFile(Application.StartupPath + "\\Images\\lock.png");
            btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            picReturnLogin.Image = Image.FromFile(Application.StartupPath + "\\Images\\arrow-small-left.png");
        }

        // reset mật khẩu
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            DataTable dt = createData();

            email = txtForgotP_Email.Text;
            if (isCorrectEmail(email, dt))
            {
                // update mật khẩu cho email X
                //to do
                var resetPassword = (from c in db.TaiKhoans
                                    where c.Email == email
                                    select c).ToList();
                //var resetPassword = db.TaiKhoans.Find(email);
                foreach(var item in resetPassword)
                {
                    if(item.Email == email)
                    {
                        item.MatKhau = "1";
                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Thay đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Email không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Ẩn hiện mật khẩu
        private void bimgEye_Click(object sender, EventArgs e)
        {
            btxtPassword.UseSystemPasswordChar = !btxtPassword.UseSystemPasswordChar;
            if (btxtPassword.UseSystemPasswordChar)
            {
                btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye-crossed.png");
            }
            else
            {
                btxtPassword.RightIcon.Image = Image.FromFile(Application.StartupPath + "\\Images\\eye.png");
            }
            
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 0;
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size + 1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X + 1, lbl.Location.Y - 3);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.Size - 1, lbl.Font.Style);
            lbl.Location = new Point(lbl.Location.X - 1, lbl.Location.Y + 3);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 0;

        }

        // click Quên MK
        private void blblFogotPassword_Click(object sender, EventArgs e)
        {
            pageLogin.SelectedIndex = 1;
        }

        //click Đăng nhập
        private void bbtnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = createData();

            username = btxtUsername.Text;
            password = btxtPassword.Text;
            if (isCorrectAccount(username, password, dt))
                login = 1;

            if (login == 1)
            {
                frmMain frmMain = new frmMain();
                this.Hide();

                UserInfo.userName = username;
                UserInfo.passWord = password;
                UserInfo.email = email;
                UserInfo.maNV = maNV;
                UserInfo.chucVu = chucvu;

                frmMain.ShowDialog();
                makeEmpty();
                this.Show();
                login = 0;
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btxtUsername.Text = "";
            }
            
        }

        //thoát không đăng nhập
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

    }
}
