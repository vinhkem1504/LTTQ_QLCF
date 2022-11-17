namespace WindowsFormsTestBunifu
{
    partial class frmPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuNhap));
            this.lblLogo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnXoaNCC = new System.Windows.Forms.Button();
            this.btnCapNhatNCC = new System.Windows.Forms.Button();
            this.cbbMaNCC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienThoaiNCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChiNCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbMaNL = new System.Windows.Forms.ComboBox();
            this.txtDonGiaNL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.txtTenNL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDonViNL = new System.Windows.Forms.TextBox();
            this.btnXoaNL = new System.Windows.Forms.Button();
            this.btnThemNL = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTongTienPhieuNhap = new System.Windows.Forms.TextBox();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.btnXacNhanLap = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnHuyPhieuNhap = new Bunifu.Framework.UI.BunifuThinButton2();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Green;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(748, 49);
            this.lblLogo.TabIndex = 2;
            this.lblLogo.Text = "PHIẾU NHẬP HÀNG";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.btnXoaNCC);
            this.groupBox1.Controls.Add(this.btnCapNhatNCC);
            this.groupBox1.Controls.Add(this.cbbMaNCC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDienThoaiNCC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDiaChiNCC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTenNCC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtMaPhieuNhap);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 188);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(109, 93);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(192, 21);
            this.txtMaNV.TabIndex = 69;
            // 
            // btnXoaNCC
            // 
            this.btnXoaNCC.AutoSize = true;
            this.btnXoaNCC.BackColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNCC.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNCC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNCC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnXoaNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnXoaNCC.ForeColor = System.Drawing.Color.White;
            this.btnXoaNCC.Location = new System.Drawing.Point(611, 154);
            this.btnXoaNCC.Name = "btnXoaNCC";
            this.btnXoaNCC.Size = new System.Drawing.Size(102, 28);
            this.btnXoaNCC.TabIndex = 68;
            this.btnXoaNCC.Text = "Xóa NCC";
            this.btnXoaNCC.UseVisualStyleBackColor = false;
            this.btnXoaNCC.Click += new System.EventHandler(this.btnXoaNCC_Click);
            // 
            // btnCapNhatNCC
            // 
            this.btnCapNhatNCC.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCapNhatNCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatNCC.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCapNhatNCC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnCapNhatNCC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnCapNhatNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCapNhatNCC.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatNCC.Location = new System.Drawing.Point(503, 154);
            this.btnCapNhatNCC.Name = "btnCapNhatNCC";
            this.btnCapNhatNCC.Size = new System.Drawing.Size(102, 28);
            this.btnCapNhatNCC.TabIndex = 66;
            this.btnCapNhatNCC.Text = "Cập nhật NCC";
            this.btnCapNhatNCC.UseVisualStyleBackColor = false;
            this.btnCapNhatNCC.Click += new System.EventHandler(this.btnCapNhatNCC_Click);
            // 
            // cbbMaNCC
            // 
            this.cbbMaNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMaNCC.FormattingEnabled = true;
            this.cbbMaNCC.Location = new System.Drawing.Point(521, 37);
            this.cbbMaNCC.Name = "cbbMaNCC";
            this.cbbMaNCC.Size = new System.Drawing.Size(192, 21);
            this.cbbMaNCC.TabIndex = 3;
            this.cbbMaNCC.SelectedIndexChanged += new System.EventHandler(this.cbbMaNCC_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(404, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 65;
            this.label5.Text = "Điện Thoại";
            // 
            // txtDienThoaiNCC
            // 
            this.txtDienThoaiNCC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDienThoaiNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoaiNCC.Location = new System.Drawing.Point(521, 122);
            this.txtDienThoaiNCC.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtDienThoaiNCC.Name = "txtDienThoaiNCC";
            this.txtDienThoaiNCC.ReadOnly = true;
            this.txtDienThoaiNCC.Size = new System.Drawing.Size(192, 21);
            this.txtDienThoaiNCC.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(404, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 61;
            this.label3.Text = "Tên Nhà Cung Cấp";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(404, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 63;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtDiaChiNCC
            // 
            this.txtDiaChiNCC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiaChiNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiNCC.Location = new System.Drawing.Point(521, 93);
            this.txtDiaChiNCC.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtDiaChiNCC.Name = "txtDiaChiNCC";
            this.txtDiaChiNCC.ReadOnly = true;
            this.txtDiaChiNCC.Size = new System.Drawing.Size(192, 21);
            this.txtDiaChiNCC.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(404, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "Mã Nhà Cung Cấp";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.Location = new System.Drawing.Point(521, 64);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.ReadOnly = true;
            this.txtTenNCC.Size = new System.Drawing.Size(192, 21);
            this.txtTenNCC.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 57;
            this.label1.Text = "Tên Nhân Viên";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(109, 122);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(192, 21);
            this.txtTenNV.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 96);
            this.label13.Margin = new System.Windows.Forms.Padding(7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 53;
            this.label13.Text = "Mã Nhân Viên";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(109, 64);
            this.dtpNgayLap.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(192, 21);
            this.dtpNgayLap.TabIndex = 52;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 67);
            this.label19.Margin = new System.Windows.Forms.Padding(7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 15);
            this.label19.TabIndex = 51;
            this.label19.Text = "Ngày Lập";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(7, 38);
            this.label33.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(93, 15);
            this.label33.TabIndex = 50;
            this.label33.Text = "Mã Phiếu Nhập";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(109, 35);
            this.txtMaPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(192, 21);
            this.txtMaPhieuNhap.TabIndex = 49;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbMaNL);
            this.groupBox2.Controls.Add(this.txtDonGiaNL);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSoLuongNhap);
            this.groupBox2.Controls.Add(this.txtTenNL);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDonViNL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(12, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 95);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nguyên liệu nhập";
            // 
            // cbbMaNL
            // 
            this.cbbMaNL.DisplayMember = "1";
            this.cbbMaNL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbbMaNL.FormattingEnabled = true;
            this.cbbMaNL.Location = new System.Drawing.Point(113, 37);
            this.cbbMaNL.Name = "cbbMaNL";
            this.cbbMaNL.Size = new System.Drawing.Size(124, 21);
            this.cbbMaNL.TabIndex = 77;
            this.cbbMaNL.SelectedIndexChanged += new System.EventHandler(this.cbbMaNL_SelectedIndexChanged);
            // 
            // txtDonGiaNL
            // 
            this.txtDonGiaNL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDonGiaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGiaNL.Location = new System.Drawing.Point(365, 64);
            this.txtDonGiaNL.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtDonGiaNL.Name = "txtDonGiaNL";
            this.txtDonGiaNL.ReadOnly = true;
            this.txtDonGiaNL.Size = new System.Drawing.Size(124, 21);
            this.txtDonGiaNL.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 75;
            this.label6.Text = "Mã nguyên liệu";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(511, 67);
            this.label11.Margin = new System.Windows.Forms.Padding(7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 74;
            this.label11.Text = "Thành Tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(589, 64);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(124, 21);
            this.txtThanhTien.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(256, 67);
            this.label10.Margin = new System.Windows.Forms.Padding(7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 72;
            this.label10.Text = "Đơn Giá";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 67);
            this.label9.Margin = new System.Windows.Forms.Padding(7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 70;
            this.label9.Text = "Số Lượng";
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSoLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongNhap.Location = new System.Drawing.Point(113, 64);
            this.txtSoLuongNhap.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.ReadOnly = true;
            this.txtSoLuongNhap.Size = new System.Drawing.Size(124, 21);
            this.txtSoLuongNhap.TabIndex = 69;
            this.txtSoLuongNhap.TextChanged += new System.EventHandler(this.txtSoLuongNL_TextChanged);
            this.txtSoLuongNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuongNL_KeyPress);
            // 
            // txtTenNL
            // 
            this.txtTenNL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNL.Location = new System.Drawing.Point(365, 35);
            this.txtTenNL.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.txtTenNL.Name = "txtTenNL";
            this.txtTenNL.ReadOnly = true;
            this.txtTenNL.Size = new System.Drawing.Size(124, 21);
            this.txtTenNL.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(511, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 56;
            this.label8.Text = "Đơn Vị";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(256, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 54;
            this.label7.Text = "Tên Nguyên Liệu";
            // 
            // txtDonViNL
            // 
            this.txtDonViNL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDonViNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonViNL.Location = new System.Drawing.Point(589, 35);
            this.txtDonViNL.Margin = new System.Windows.Forms.Padding(2, 20, 7, 2);
            this.txtDonViNL.Name = "txtDonViNL";
            this.txtDonViNL.ReadOnly = true;
            this.txtDonViNL.Size = new System.Drawing.Size(124, 21);
            this.txtDonViNL.TabIndex = 55;
            // 
            // btnXoaNL
            // 
            this.btnXoaNL.BackColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNL.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnXoaNL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnXoaNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnXoaNL.ForeColor = System.Drawing.Color.White;
            this.btnXoaNL.Location = new System.Drawing.Point(137, 347);
            this.btnXoaNL.Name = "btnXoaNL";
            this.btnXoaNL.Size = new System.Drawing.Size(112, 24);
            this.btnXoaNL.TabIndex = 91;
            this.btnXoaNL.Text = "Xóa";
            this.btnXoaNL.UseVisualStyleBackColor = false;
            this.btnXoaNL.Click += new System.EventHandler(this.btnXoaNL_Click);
            // 
            // btnThemNL
            // 
            this.btnThemNL.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThemNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNL.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnThemNL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnThemNL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnThemNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnThemNL.ForeColor = System.Drawing.Color.White;
            this.btnThemNL.Location = new System.Drawing.Point(12, 347);
            this.btnThemNL.Name = "btnThemNL";
            this.btnThemNL.Size = new System.Drawing.Size(112, 24);
            this.btnThemNL.TabIndex = 89;
            this.btnThemNL.Text = "Thêm";
            this.btnThemNL.UseVisualStyleBackColor = false;
            this.btnThemNL.Click += new System.EventHandler(this.btnThemNL_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(523, 349);
            this.label12.Margin = new System.Windows.Forms.Padding(7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 15);
            this.label12.TabIndex = 88;
            this.label12.Text = "Tổng Tiền";
            // 
            // txtTongTienPhieuNhap
            // 
            this.txtTongTienPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTongTienPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienPhieuNhap.Location = new System.Drawing.Point(601, 346);
            this.txtTongTienPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.txtTongTienPhieuNhap.Name = "txtTongTienPhieuNhap";
            this.txtTongTienPhieuNhap.ReadOnly = true;
            this.txtTongTienPhieuNhap.Size = new System.Drawing.Size(135, 21);
            this.txtTongTienPhieuNhap.TabIndex = 87;
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(12, 377);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(724, 227);
            this.dgvChiTietPhieuNhap.TabIndex = 92;
            // 
            // btnXacNhanLap
            // 
            this.btnXacNhanLap.ActiveBorderThickness = 1;
            this.btnXacNhanLap.ActiveCornerRadius = 20;
            this.btnXacNhanLap.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhanLap.ActiveForecolor = System.Drawing.Color.White;
            this.btnXacNhanLap.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhanLap.BackColor = System.Drawing.SystemColors.Control;
            this.btnXacNhanLap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXacNhanLap.BackgroundImage")));
            this.btnXacNhanLap.ButtonText = "Xác Nhận";
            this.btnXacNhanLap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanLap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanLap.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhanLap.IdleBorderThickness = 1;
            this.btnXacNhanLap.IdleCornerRadius = 20;
            this.btnXacNhanLap.IdleFillColor = System.Drawing.Color.White;
            this.btnXacNhanLap.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnXacNhanLap.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhanLap.Location = new System.Drawing.Point(152, 611);
            this.btnXacNhanLap.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhanLap.Name = "btnXacNhanLap";
            this.btnXacNhanLap.Size = new System.Drawing.Size(161, 47);
            this.btnXacNhanLap.TabIndex = 94;
            this.btnXacNhanLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXacNhanLap.Click += new System.EventHandler(this.btnXacNhanLap_Click);
            // 
            // btnHuyPhieuNhap
            // 
            this.btnHuyPhieuNhap.ActiveBorderThickness = 1;
            this.btnHuyPhieuNhap.ActiveCornerRadius = 20;
            this.btnHuyPhieuNhap.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnHuyPhieuNhap.ActiveForecolor = System.Drawing.Color.White;
            this.btnHuyPhieuNhap.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnHuyPhieuNhap.BackColor = System.Drawing.SystemColors.Control;
            this.btnHuyPhieuNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuyPhieuNhap.BackgroundImage")));
            this.btnHuyPhieuNhap.ButtonText = "Hủy Bỏ";
            this.btnHuyPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyPhieuNhap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPhieuNhap.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnHuyPhieuNhap.IdleBorderThickness = 1;
            this.btnHuyPhieuNhap.IdleCornerRadius = 20;
            this.btnHuyPhieuNhap.IdleFillColor = System.Drawing.Color.White;
            this.btnHuyPhieuNhap.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnHuyPhieuNhap.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnHuyPhieuNhap.Location = new System.Drawing.Point(419, 612);
            this.btnHuyPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyPhieuNhap.Name = "btnHuyPhieuNhap";
            this.btnHuyPhieuNhap.Size = new System.Drawing.Size(161, 47);
            this.btnHuyPhieuNhap.TabIndex = 93;
            this.btnHuyPhieuNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHuyPhieuNhap.Click += new System.EventHandler(this.btnHuyPhieuNhap_Click);
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(748, 660);
            this.Controls.Add(this.btnXoaNL);
            this.Controls.Add(this.btnThemNL);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTongTienPhieuNhap);
            this.Controls.Add(this.btnXacNhanLap);
            this.Controls.Add(this.btnHuyPhieuNhap);
            this.Controls.Add(this.dgvChiTietPhieuNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Phiếu Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhieuNhap_FormClosing);
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.Button btnCapNhatNCC;
        private System.Windows.Forms.ComboBox cbbMaNCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDienThoaiNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChiNCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDonViNL;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTongTienPhieuNhap;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private Bunifu.Framework.UI.BunifuThinButton2 btnXacNhanLap;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHuyPhieuNhap;
        private System.Windows.Forms.TextBox txtDonGiaNL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.ComboBox cbbMaNL;
    }
}