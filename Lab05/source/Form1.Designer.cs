using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab05
{
    partial class frmDangKy
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpHocVien = new GroupBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            chkNhanEmail = new CheckBox();
            grpKhoaHoc = new GroupBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblHinhThuc = new Label();
            radOnline = new RadioButton();
            radOffline = new RadioButton();
            lblSoThang = new Label();
            numSoThang = new NumericUpDown();
            lblTongTienTieuDe = new Label();
            lblTongTien = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            
            grpHocVien.Controls.Add(lblHoTen);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(lblSoDienThoai);
            grpHocVien.Controls.Add(txtSoDienThoai);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(chkNhanEmail);
            grpHocVien.Location = new Point(12, 12);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(536, 175);
            grpHocVien.TabIndex = 0;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "Thông tin học viên";
           
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 33);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            
            txtHoTen.Location = new Point(140, 30);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(370, 27);
            txtHoTen.TabIndex = 1;
            
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(20, 68);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.TabIndex = 2;
            lblSoDienThoai.Text = "Số điện thoại:";
            
            txtSoDienThoai.Location = new Point(140, 65);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(370, 27);
            txtSoDienThoai.TabIndex = 3;
            
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 103);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.TabIndex = 4;
            lblNgaySinh.Text = "Ngày sinh:";
            
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(140, 100);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(160, 27);
            dtpNgaySinh.TabIndex = 5;
            
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(140, 137);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.TabIndex = 6;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Controls.Add(cboKhoaHoc);
            grpKhoaHoc.Controls.Add(lblHinhThuc);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(radOffline);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(lblTongTienTieuDe);
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Location = new Point(12, 197);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(536, 200);
            grpKhoaHoc.TabIndex = 1;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "Thông tin khóa học";
            
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 33);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khóa học:";
            
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(140, 30);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(370, 28);
            cboKhoaHoc.TabIndex = 1;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Location = new Point(20, 72);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.TabIndex = 2;
            lblHinhThuc.Text = "Hình thức học:";
            
            radOnline.AutoSize = true;
            radOnline.Checked = true;
            radOnline.Location = new Point(140, 70);
            radOnline.Name = "radOnline";
            radOnline.TabIndex = 3;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            
            radOffline.AutoSize = true;
            radOffline.Location = new Point(260, 70);
            radOffline.Name = "radOffline";
            radOffline.TabIndex = 4;
            radOffline.Text = "Trực tiếp";
            radOffline.UseVisualStyleBackColor = true;
            
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(20, 110);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.TabIndex = 5;
            lblSoThang.Text = "Số tháng:";
            
            numSoThang.Location = new Point(140, 107);
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(80, 27);
            numSoThang.TabIndex = 6;
            numSoThang.ValueChanged += numSoThang_ValueChanged;
            
            lblTongTienTieuDe.AutoSize = true;
            lblTongTienTieuDe.Location = new Point(20, 155);
            lblTongTienTieuDe.Name = "lblTongTienTieuDe";
            lblTongTienTieuDe.TabIndex = 7;
            lblTongTienTieuDe.Text = "Tổng học phí:";
            
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Firebrick;
            lblTongTien.Location = new Point(140, 151);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "0 VNĐ";
            
            btnDangKy.Location = new Point(95, 412);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(110, 38);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            
            btnLamMoi.Location = new Point(225, 412);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 38);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            
            btnThoat.Location = new Point(355, 412);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 38);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
           
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 470);
            Controls.Add(grpHocVien);
            Controls.Add(grpKhoaHoc);
            Controls.Add(btnDangKy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThoat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += frmDangKy_Load;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpHocVien;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNhanEmail;
        private GroupBox grpKhoaHoc;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblHinhThuc;
        private RadioButton radOnline;
        private RadioButton radOffline;
        private Label lblSoThang;
        private NumericUpDown numSoThang;
        private Label lblTongTienTieuDe;
        private Label lblTongTien;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
    }
}