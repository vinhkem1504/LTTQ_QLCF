namespace WindowsFormsTestBunifu
{
    partial class frmHoaDonBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonBan));
            this.lblLogo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbHDB_MaBan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHDB_TongTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbHDB_MaNV = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtHDB_Ngaylap = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtHDB_MaHDB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHDB_Soluong = new System.Windows.Forms.TextBox();
            this.cbbHDB_TenSp = new System.Windows.Forms.ComboBox();
            this.btnHDB_XoaSp = new System.Windows.Forms.Button();
            this.btnHDB_ThemSp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHDB_DSSP = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHDB_XacNhan = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnHDB_HuyBo = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB_DSSP)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Green;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(663, 80);
            this.lblLogo.TabIndex = 3;
            this.lblLogo.Text = "HÓA ĐƠN ";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbHDB_MaBan);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtHDB_TongTien);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbbHDB_MaNV);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.dtHDB_Ngaylap);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.txtHDB_MaHDB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 223);
            this.panel2.TabIndex = 4;
            // 
            // cbbHDB_MaBan
            // 
            this.cbbHDB_MaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHDB_MaBan.FormattingEnabled = true;
            this.cbbHDB_MaBan.Location = new System.Drawing.Point(286, 65);
            this.cbbHDB_MaBan.Margin = new System.Windows.Forms.Padding(4);
            this.cbbHDB_MaBan.Name = "cbbHDB_MaBan";
            this.cbbHDB_MaBan.Size = new System.Drawing.Size(255, 25);
            this.cbbHDB_MaBan.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(150, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 25, 9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "Tổng Tiền";
            // 
            // txtHDB_TongTien
            // 
            this.txtHDB_TongTien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHDB_TongTien.Enabled = false;
            this.txtHDB_TongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDB_TongTien.Location = new System.Drawing.Point(286, 184);
            this.txtHDB_TongTien.Margin = new System.Windows.Forms.Padding(3, 25, 3, 2);
            this.txtHDB_TongTien.Name = "txtHDB_TongTien";
            this.txtHDB_TongTien.Size = new System.Drawing.Size(255, 24);
            this.txtHDB_TongTien.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(150, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 25, 9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 67;
            this.label2.Text = "Mã Bàn";
            // 
            // cbbHDB_MaNV
            // 
            this.cbbHDB_MaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHDB_MaNV.FormattingEnabled = true;
            this.cbbHDB_MaNV.Location = new System.Drawing.Point(286, 102);
            this.cbbHDB_MaNV.Margin = new System.Windows.Forms.Padding(4);
            this.cbbHDB_MaNV.Name = "cbbHDB_MaNV";
            this.cbbHDB_MaNV.Size = new System.Drawing.Size(255, 25);
            this.cbbHDB_MaNV.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(150, 106);
            this.label13.Margin = new System.Windows.Forms.Padding(9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 18);
            this.label13.TabIndex = 62;
            this.label13.Text = "Mã Nhân Viên";
            // 
            // dtHDB_Ngaylap
            // 
            this.dtHDB_Ngaylap.Enabled = false;
            this.dtHDB_Ngaylap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHDB_Ngaylap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHDB_Ngaylap.Location = new System.Drawing.Point(286, 143);
            this.dtHDB_Ngaylap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtHDB_Ngaylap.Name = "dtHDB_Ngaylap";
            this.dtHDB_Ngaylap.Size = new System.Drawing.Size(255, 24);
            this.dtHDB_Ngaylap.TabIndex = 61;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(150, 146);
            this.label19.Margin = new System.Windows.Forms.Padding(9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 18);
            this.label19.TabIndex = 60;
            this.label19.Text = "Ngày Lập";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(150, 29);
            this.label33.Margin = new System.Windows.Forms.Padding(9, 25, 9, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(93, 18);
            this.label33.TabIndex = 59;
            this.label33.Text = "Mã Hóa Đơn";
            // 
            // txtHDB_MaHDB
            // 
            this.txtHDB_MaHDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHDB_MaHDB.Enabled = false;
            this.txtHDB_MaHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDB_MaHDB.Location = new System.Drawing.Point(286, 25);
            this.txtHDB_MaHDB.Margin = new System.Windows.Forms.Padding(3, 25, 3, 2);
            this.txtHDB_MaHDB.Name = "txtHDB_MaHDB";
            this.txtHDB_MaHDB.Size = new System.Drawing.Size(255, 24);
            this.txtHDB_MaHDB.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 314);
            this.panel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtHDB_Soluong);
            this.panel4.Controls.Add(this.cbbHDB_TenSp);
            this.panel4.Controls.Add(this.btnHDB_XoaSp);
            this.panel4.Controls.Add(this.btnHDB_ThemSp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 134);
            this.panel4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(150, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 25, 9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 71;
            this.label4.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(150, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(9, 25, 9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 70;
            this.label3.Text = "Số lượng";
            // 
            // txtHDB_Soluong
            // 
            this.txtHDB_Soluong.Location = new System.Drawing.Point(286, 44);
            this.txtHDB_Soluong.Name = "txtHDB_Soluong";
            this.txtHDB_Soluong.Size = new System.Drawing.Size(255, 22);
            this.txtHDB_Soluong.TabIndex = 61;
            // 
            // cbbHDB_TenSp
            // 
            this.cbbHDB_TenSp.FormattingEnabled = true;
            this.cbbHDB_TenSp.Location = new System.Drawing.Point(286, 3);
            this.cbbHDB_TenSp.Name = "cbbHDB_TenSp";
            this.cbbHDB_TenSp.Size = new System.Drawing.Size(255, 24);
            this.cbbHDB_TenSp.TabIndex = 60;
            // 
            // btnHDB_XoaSp
            // 
            this.btnHDB_XoaSp.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XoaSp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDB_XoaSp.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XoaSp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XoaSp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnHDB_XoaSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHDB_XoaSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnHDB_XoaSp.ForeColor = System.Drawing.Color.White;
            this.btnHDB_XoaSp.Location = new System.Drawing.Point(389, 90);
            this.btnHDB_XoaSp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHDB_XoaSp.Name = "btnHDB_XoaSp";
            this.btnHDB_XoaSp.Size = new System.Drawing.Size(93, 30);
            this.btnHDB_XoaSp.TabIndex = 59;
            this.btnHDB_XoaSp.Text = "Xóa";
            this.btnHDB_XoaSp.UseVisualStyleBackColor = false;
            this.btnHDB_XoaSp.Click += new System.EventHandler(this.btnCTB_XoaSP_Click);
            // 
            // btnHDB_ThemSp
            // 
            this.btnHDB_ThemSp.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_ThemSp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDB_ThemSp.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_ThemSp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_ThemSp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnHDB_ThemSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHDB_ThemSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnHDB_ThemSp.ForeColor = System.Drawing.Color.White;
            this.btnHDB_ThemSp.Location = new System.Drawing.Point(194, 90);
            this.btnHDB_ThemSp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHDB_ThemSp.Name = "btnHDB_ThemSp";
            this.btnHDB_ThemSp.Size = new System.Drawing.Size(93, 30);
            this.btnHDB_ThemSp.TabIndex = 58;
            this.btnHDB_ThemSp.Text = "Thêm";
            this.btnHDB_ThemSp.UseVisualStyleBackColor = false;
            this.btnHDB_ThemSp.Click += new System.EventHandler(this.btnCTB_ThemSP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHDB_DSSP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm";
            // 
            // dgvHDB_DSSP
            // 
            this.dgvHDB_DSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDB_DSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHDB_DSSP.Location = new System.Drawing.Point(3, 18);
            this.dgvHDB_DSSP.Name = "dgvHDB_DSSP";
            this.dgvHDB_DSSP.RowHeadersWidth = 51;
            this.dgvHDB_DSSP.RowTemplate.Height = 24;
            this.dgvHDB_DSSP.Size = new System.Drawing.Size(657, 153);
            this.dgvHDB_DSSP.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnHDB_XacNhan);
            this.panel3.Controls.Add(this.btnHDB_HuyBo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 623);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 61);
            this.panel3.TabIndex = 6;
            // 
            // btnHDB_XacNhan
            // 
            this.btnHDB_XacNhan.ActiveBorderThickness = 1;
            this.btnHDB_XacNhan.ActiveCornerRadius = 20;
            this.btnHDB_XacNhan.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XacNhan.ActiveForecolor = System.Drawing.Color.White;
            this.btnHDB_XacNhan.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XacNhan.BackColor = System.Drawing.SystemColors.Control;
            this.btnHDB_XacNhan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHDB_XacNhan.BackgroundImage")));
            this.btnHDB_XacNhan.ButtonText = "Xác Nhận";
            this.btnHDB_XacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDB_XacNhan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDB_XacNhan.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XacNhan.IdleBorderThickness = 1;
            this.btnHDB_XacNhan.IdleCornerRadius = 20;
            this.btnHDB_XacNhan.IdleFillColor = System.Drawing.Color.White;
            this.btnHDB_XacNhan.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XacNhan.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_XacNhan.Location = new System.Drawing.Point(116, 0);
            this.btnHDB_XacNhan.Margin = new System.Windows.Forms.Padding(5);
            this.btnHDB_XacNhan.Name = "btnHDB_XacNhan";
            this.btnHDB_XacNhan.Size = new System.Drawing.Size(190, 58);
            this.btnHDB_XacNhan.TabIndex = 96;
            this.btnHDB_XacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHDB_XacNhan.Click += new System.EventHandler(this.btnHDB_XacNhan_Click);
            // 
            // btnHDB_HuyBo
            // 
            this.btnHDB_HuyBo.ActiveBorderThickness = 1;
            this.btnHDB_HuyBo.ActiveCornerRadius = 20;
            this.btnHDB_HuyBo.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_HuyBo.ActiveForecolor = System.Drawing.Color.White;
            this.btnHDB_HuyBo.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_HuyBo.BackColor = System.Drawing.SystemColors.Control;
            this.btnHDB_HuyBo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHDB_HuyBo.BackgroundImage")));
            this.btnHDB_HuyBo.ButtonText = "Hủy Bỏ";
            this.btnHDB_HuyBo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHDB_HuyBo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDB_HuyBo.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_HuyBo.IdleBorderThickness = 1;
            this.btnHDB_HuyBo.IdleCornerRadius = 20;
            this.btnHDB_HuyBo.IdleFillColor = System.Drawing.Color.White;
            this.btnHDB_HuyBo.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnHDB_HuyBo.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnHDB_HuyBo.Location = new System.Drawing.Point(378, 0);
            this.btnHDB_HuyBo.Margin = new System.Windows.Forms.Padding(5);
            this.btnHDB_HuyBo.Name = "btnHDB_HuyBo";
            this.btnHDB_HuyBo.Size = new System.Drawing.Size(190, 58);
            this.btnHDB_HuyBo.TabIndex = 95;
            this.btnHDB_HuyBo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHDB_HuyBo.Click += new System.EventHandler(this.btnHDB_HuyBo_Click);
            // 
            // frmHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 684);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblLogo);
            this.Name = "frmHoaDonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDonBan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoaDonBan_FormClosing);
            this.Load += new System.EventHandler(this.frmHoaDonBan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB_DSSP)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbHDB_MaNV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtHDB_Ngaylap;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtHDB_MaHDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHDB_TongTien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHDB_XacNhan;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHDB_HuyBo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHDB_XoaSp;
        private System.Windows.Forms.Button btnHDB_ThemSp;
        private System.Windows.Forms.DataGridView dgvHDB_DSSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHDB_Soluong;
        private System.Windows.Forms.ComboBox cbbHDB_TenSp;
        private System.Windows.Forms.ComboBox cbbHDB_MaBan;
    }
}