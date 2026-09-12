using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Hệ thống thông tin");
            cboKhoa.Items.Add("Sư phạm Tin học");
            cboKhoa.SelectedIndex = -1;

            
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNamSinh.Text))
            {
                MessageBox.Show("Vui lòng nhập năm sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            if (!int.TryParse(txtNamSinh.Text.Trim(), out int namSinh))
            {
                MessageBox.Show("Năm sinh phải là một số nguyên hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            int currentYear = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > currentYear)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {currentYear}!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa/Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

          
            int tuoi = currentYear - namSinh;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            string ketQua = $" THÔNG TIN SINH VIÊN \r\n" +
                            $"• Họ tên: {txtHoTen.Text.Trim()}\r\n" +
                            $"• Tuổi: {tuoi} (Năm sinh: {namSinh})\r\n" +
                            $"• Email: {txtEmail.Text.Trim()}\r\n" +
                            $"• Giới tính: {gioiTinh}\r\n" +
                            $"• Khoa/Lớp: {cboKhoa.SelectedItem.ToString()}";

            txtKetQua.Text = ketQua;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            txtKetQua.Clear();

            radNam.Checked = false;
            radNu.Checked = false;

            cboKhoa.SelectedIndex = -1;

            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}