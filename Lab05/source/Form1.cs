using System.Globalization;

namespace Lab05
{
    public partial class frmDangKy : Form
    {
        private readonly (string Ten, decimal HocPhi)[] dsKhoaHoc =
        {
            ("C# WinForms cơ bản", 800000m),
            ("SQL Server cơ bản", 700000m),
            ("Web Frontend cơ bản", 750000m),
            ("Lập trình Python cơ bản", 650000m)
        };

        private readonly CultureInfo viVN = new CultureInfo("vi-VN");

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Clear();
            foreach (var kh in dsKhoaHoc)
            {
                cboKhoaHoc.Items.Add(kh.Ten);
            }
            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;

            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            CapNhatTongTien();
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private decimal TinhTongTien()
        {
            int index = cboKhoaHoc.SelectedIndex;
            if (index < 0)
            {
                return 0;
            }
            return dsKhoaHoc[index].HocPhi * numSoThang.Value;
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0", viVN) + " VNĐ";
        }

        private void CapNhatTongTien()
        {
            lblTongTien.Text = DinhDangTien(TinhTongTien());
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();

            if (hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (soDienThoai == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";

            string phieu =
                "PHIẾU ĐĂNG KÝ KHÓA HỌC\n" +
                "----------------------------------\n" +
                $"Họ tên: {hoTen}\n" +
                $"Số điện thoại: {soDienThoai}\n" +
                $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                $"Khóa học: {cboKhoaHoc.SelectedItem}\n" +
                $"Hình thức học: {hinhThuc}\n" +
                $"Số tháng: {numSoThang.Value}\n" +
                $"Tổng tiền: {DinhDangTien(TinhTongTien())}\n" +
                $"Nhận email thông báo: {nhanEmail}";

            MessageBox.Show(phieu, "Đăng ký thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            chkNhanEmail.Checked = false;
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;
            CapNhatTongTien();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}