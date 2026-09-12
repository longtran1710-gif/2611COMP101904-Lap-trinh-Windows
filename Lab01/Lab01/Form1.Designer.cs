namespace Lab01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            lblNamSinh = new Label();
            lblEmail = new Label();
            txtHoTen = new TextBox();
            txtNamSinh = new TextBox();
            txtEmail = new TextBox();
            grpGioiTinh = new GroupBox();
            radNu = new RadioButton();
            radNam = new RadioButton();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            txtKetQua = new TextBox();
            grpGioiTinh.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(295, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(338, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN SINH VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHoTen.Location = new Point(28, 53);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(49, 15);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = " Họ tên:";
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamSinh.Location = new Point(28, 85);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(61, 15);
            lblNamSinh.TabIndex = 2;
            lblNamSinh.Text = "Năm Sinh:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(28, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(38, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(129, 53);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(131, 23);
            txtHoTen.TabIndex = 4;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(129, 85);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(131, 23);
            txtNamSinh.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(129, 114);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(131, 23);
            txtEmail.TabIndex = 6;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpGioiTinh.Location = new Point(28, 159);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(180, 55);
            grpGioiTinh.TabIndex = 7;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radNu.Location = new Point(93, 22);
            radNu.Name = "radNu";
            radNu.Size = new Size(41, 19);
            radNu.TabIndex = 1;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radNam.Location = new Point(25, 22);
            radNam.Name = "radNam";
            radNam.Size = new Size(49, 19);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKhoa.Location = new Point(28, 239);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(64, 15);
            lblKhoa.TabIndex = 8;
            lblKhoa.Text = "Khoa/Lớp:";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(106, 236);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(204, 23);
            cboKhoa.TabIndex = 9;
            // 
            // btnHienThi
            // 
            btnHienThi.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHienThi.Location = new Point(38, 278);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(90, 35);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(274, 278);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(90, 35);
            btnThoat.TabIndex = 11;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(158, 278);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 35);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtKetQua
            // 
            txtKetQua.BackColor = SystemColors.ControlLight;
            txtKetQua.Location = new Point(28, 332);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(348, 160);
            txtKetQua.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 523);
            Controls.Add(txtKetQua);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(btnHienThi);
            Controls.Add(cboKhoa);
            Controls.Add(lblKhoa);
            Controls.Add(grpGioiTinh);
            Controls.Add(txtEmail);
            Controls.Add(txtNamSinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblEmail);
            Controls.Add(lblNamSinh);
            Controls.Add(lblHoTen);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHoTen;
        private Label lblEmail;
        protected internal Label lblNamSinh;
        private TextBox txtHoTen;
        private TextBox txtNamSinh;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton radNu;
        private RadioButton radNam;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnThoat;
        private Button btnXoa;
        private TextBox txtKetQua;
    }
}
