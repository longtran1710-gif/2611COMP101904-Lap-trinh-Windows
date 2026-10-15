using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductManager;

public partial class FrmProduct : Form
{
    private static readonly CultureInfo Vi = new CultureInfo("vi-VN");

    private readonly List<Product> allProducts = new List<Product>();
    private readonly BindingSource productSource = new BindingSource();
    private string selectedImagePath = string.Empty;
    private string currentKeyword = string.Empty;
    private bool isLoadingGrid;
    private bool sortGiaAscending = true;
    private bool sortSoLuongAscending = true;
    public FrmProduct()
    {
        InitializeComponent();
    }
    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
        cboLoaiSP.SelectedIndex = 0;
        ConfigureGrid();
        LoadSampleData();
        dgvProducts.DataSource = productSource;
        RefreshGrid();
        ClearInput();
        UpdateStatus("Sẵn sàng");
    }
    private void ConfigureGrid()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        var rightMoney = new DataGridViewCellStyle
        {
            Format = "N0",
            FormatProvider = Vi,
            Alignment = DataGridViewContentAlignment.MiddleRight
        };
        var rightNumber = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };
        var dateStyle = new DataGridViewCellStyle
        {
            Format = "dd/MM/yyyy",
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };
        dgvProducts.Columns.Clear();
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colMaSP", DataPropertyName = "MaSP", HeaderText = "Mã SP", FillWeight = 60
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colTenSP", DataPropertyName = "TenSP", HeaderText = "Tên sản phẩm", FillWeight = 140
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colLoaiSP", DataPropertyName = "LoaiSP", HeaderText = "Loại", FillWeight = 80
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colDonGia", DataPropertyName = "DonGia", HeaderText = "Đơn giá",
            FillWeight = 80, DefaultCellStyle = rightMoney
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colSoLuong", DataPropertyName = "SoLuong", HeaderText = "Số lượng",
            FillWeight = 60, DefaultCellStyle = rightNumber
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colNgayNhap", DataPropertyName = "NgayNhap", HeaderText = "Ngày nhập",
            FillWeight = 80, DefaultCellStyle = dateStyle
        });
        dgvProducts.Columns.Add(new DataGridViewCheckBoxColumn
        {
            Name = "colConKinhDoanh", DataPropertyName = "ConKinhDoanh", HeaderText = "Còn KD", FillWeight = 50
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colThanhTien", DataPropertyName = "ThanhTien", HeaderText = "Thành tiền",
            FillWeight = 90, DefaultCellStyle = rightMoney
        });
    }
    private void LoadSampleData()
    {
        allProducts.Add(new Product
        {
            MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
            DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today.AddDays(-10), ConKinhDoanh = true
        });
        allProducts.Add(new Product
        {
            MaSP = "SP02", TenSP = "Bút bi Thiên Long", LoaiSP = "Văn phòng",
            DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today.AddDays(-5), ConKinhDoanh = true
        });
        allProducts.Add(new Product
        {
            MaSP = "SP03", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng",
            DonGia = 890000, SoLuong = 8, NgayNhap = DateTime.Today.AddDays(-3), ConKinhDoanh = true
        });
        allProducts.Add(new Product
        {
            MaSP = "SP04", TenSP = "Áo thun nam", LoaiSP = "Thời trang",
            DonGia = 120000, SoLuong = 0, NgayNhap = DateTime.Today.AddDays(-30), ConKinhDoanh = false
        });
    }
    private void RefreshGrid()
    {
        isLoadingGrid = true;
        try
        {
            IEnumerable<Product> data = allProducts;
            if (currentKeyword.Length > 0)
            {
                data = allProducts.Where(p =>
                    p.MaSP.Contains(currentKeyword, StringComparison.OrdinalIgnoreCase) ||
                    p.TenSP.Contains(currentKeyword, StringComparison.OrdinalIgnoreCase));
            }
            productSource.DataSource = new BindingList<Product>(data.ToList());
            dgvProducts.ClearSelection();
        }
        finally
        {
            isLoadingGrid = false;
        }
    }
    private void SelectProduct(Product product)
    {
        foreach (DataGridViewRow row in dgvProducts.Rows)
        {
            if (ReferenceEquals(row.DataBoundItem, product))
            {
                dgvProducts.ClearSelection();
                row.Selected = true;
                dgvProducts.CurrentCell = row.Cells[0];
                break;
            }
        }
    }
    private Product? GetSelectedProduct()
    {
        if (dgvProducts.SelectedRows.Count == 0 ||
            dgvProducts.SelectedRows[0].DataBoundItem is not Product product)
        {
            MessageBox.Show("Vui lòng chọn một sản phẩm trong danh sách.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        return product;
    }
    private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        if (isLoadingGrid || dgvProducts.SelectedRows.Count == 0) return;

        if (dgvProducts.SelectedRows[0].DataBoundItem is Product product)
        {
            LoadProductToForm(product);
        }
    }
    private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
        {
            dgvProducts.ClearSelection();
            dgvProducts.Rows[e.RowIndex].Selected = true;
            dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];
        }
    }
    private void dgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) cmsChiTiet_Click(sender, e);
    }
    private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            btnXoa.PerformClick();
            e.Handled = true;
        }
    }
    private void LoadProductToForm(Product p)
    {
        errorProvider1.Clear();
        txtMaSP.Text = p.MaSP;
        txtTenSP.Text = p.TenSP;
        cboLoaiSP.SelectedIndex = Math.Max(0, cboLoaiSP.Items.IndexOf(p.LoaiSP));
        numDonGia.Value = Math.Min(Math.Max(p.DonGia, numDonGia.Minimum), numDonGia.Maximum);
        numSoLuong.Value = Math.Min(Math.Max(p.SoLuong, numSoLuong.Minimum), numSoLuong.Maximum);
        dtpNgayNhap.Value = p.NgayNhap < dtpNgayNhap.MinDate ? dtpNgayNhap.MinDate : p.NgayNhap;
        chkConKinhDoanh.Checked = p.ConKinhDoanh;
        selectedImagePath = p.DuongDanAnh;
        ShowImage(selectedImagePath);
    }
    private void FillProductFromForm(Product p)
    {
        p.MaSP = txtMaSP.Text.Trim();
        p.TenSP = txtTenSP.Text.Trim();
        p.LoaiSP = cboLoaiSP.Text;
        p.DonGia = numDonGia.Value;
        p.SoLuong = (int)numSoLuong.Value;
        p.NgayNhap = dtpNgayNhap.Value.Date;
        p.ConKinhDoanh = chkConKinhDoanh.Checked;
        p.DuongDanAnh = selectedImagePath;
    }
    private void ClearInput()
    {
        errorProvider1.Clear();
        txtMaSP.Clear();
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 1;
        numSoLuong.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
        selectedImagePath = string.Empty;
        DisposePictureImage();
        dgvProducts.ClearSelection();
        txtMaSP.Focus();
    }
    private void UpdateStatus(string message)
    {
        lblStatus.Text = message;
        string count = $"Số sản phẩm: {allProducts.Count}";
        if (currentKeyword.Length > 0)
        {
            count += $" (đang hiển thị {productSource.Count})";
        }
        lblCount.Text = count;

        decimal total = allProducts.Sum(p => p.ThanhTien);
        lblTongTon.Text = string.Format(Vi, "Tổng giá trị tồn kho: {0:N0} đ", total);
    }
    private bool ValidateInput(Product? editing = null)
    {
        errorProvider1.Clear();
        bool isValid = true;
        Control? firstError = null;
        void SetError(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            firstError ??= control;
            isValid = false;
        }
        string ma = txtMaSP.Text.Trim();
        if (ma.Length == 0)
        {
            SetError(txtMaSP, "Mã sản phẩm không được rỗng");
        }
        else if (allProducts.Any(p => !ReferenceEquals(p, editing) &&
                                      p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
        {
            SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
        }
        if (string.IsNullOrWhiteSpace(txtTenSP.Text))
        {
            SetError(txtTenSP, "Tên sản phẩm không được rỗng");
        }
        if (cboLoaiSP.SelectedIndex < 0)
        {
            SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
        }
        if (numDonGia.Value <= 0)
        {
            SetError(numDonGia, "Đơn giá phải lớn hơn 0");
        }
        if (numSoLuong.Value < 0)
        {
            SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
        }
        if (dtpNgayNhap.Value.Date > DateTime.Today)
        {
            SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại");
        }
        if (!isValid)
        {
            MessageBox.Show("Dữ liệu chưa hợp lệ, vui lòng kiểm tra các ô có biểu tượng lỗi.",
                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstError?.Focus();
        }

        return isValid;
    }
    private void DisposePictureImage()
    {
        picSanPham.Image?.Dispose();
        picSanPham.Image = null;
    }
    private void ShowImage(string path)
    {
        DisposePictureImage();
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;

        try
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var image = Image.FromStream(stream);
            picSanPham.Image = new Bitmap(image);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is OutOfMemoryException || ex is IOException)
        {
            MessageBox.Show("Không thể đọc file ảnh: " + path, "Lỗi ảnh",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        var product = new Product();
        FillProductFromForm(product);
        allProducts.Add(product);
        currentKeyword = string.Empty;
        tstTimKiem.Clear();
        RefreshGrid();
        ClearInput();
        UpdateStatus($"Đã thêm sản phẩm {product.MaSP}");
    }
    private void btnSua_Click(object? sender, EventArgs e)
    {
        Product? product = GetSelectedProduct();
        if (product == null) return;
        if (!ValidateInput(product)) return;
        FillProductFromForm(product);
        RefreshGrid();
        SelectProduct(product);
        UpdateStatus($"Đã cập nhật sản phẩm {product.MaSP}");
    }
    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? product = GetSelectedProduct();
        if (product == null) return;
        DialogResult result = MessageBox.Show(
            $"Bạn có chắc muốn xóa sản phẩm \"{product.TenSP}\" ({product.MaSP})?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        allProducts.Remove(product);
        RefreshGrid();
        ClearInput();
        UpdateStatus($"Đã xóa sản phẩm {product.MaSP}");
    }
    private void TimKiem_Click(object? sender, EventArgs e)
    {
        currentKeyword = tstTimKiem.Text.Trim();
        RefreshGrid();
        ClearInput();
        UpdateStatus($"Tìm thấy {productSource.Count} sản phẩm");
    }
    private void tstTimKiem_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            tsbTimKiem.PerformClick();
        }
    }
    private void mnuTimKiem_Click(object? sender, EventArgs e)
    {
        tstTimKiem.Focus();
    }
    private void LamMoi_Click(object? sender, EventArgs e)
    {
        currentKeyword = string.Empty;
        tstTimKiem.Clear();
        RefreshGrid();
        ClearInput();
        UpdateStatus("Đã làm mới dữ liệu");
    }
    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Title = "Chọn ảnh sản phẩm";
        dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = dialog.FileName;
            ShowImage(selectedImagePath);
            UpdateStatus("Đã chọn ảnh sản phẩm (nhấn Sửa hoặc Thêm để lưu)");
        }
    }
    private void cmsSua_Click(object? sender, EventArgs e)
    {
        Product? product = GetSelectedProduct();
        if (product == null) return;
        LoadProductToForm(product);
        txtTenSP.Focus();
        UpdateStatus("Chỉnh sửa thông tin rồi nhấn nút Sửa để lưu");
    }
    private void cmsChiTiet_Click(object? sender, EventArgs e)
    {
        Product? product = GetSelectedProduct();
        if (product == null) return;
        string message =
            $"Mã SP: {product.MaSP}\n" +
            $"Tên: {product.TenSP}\n" +
            $"Loại: {product.LoaiSP}\n" +
            string.Format(Vi, "Đơn giá: {0:N0} đ\n", product.DonGia) +
            $"Số lượng: {product.SoLuong}\n" +
            $"Ngày nhập: {product.NgayNhap:dd/MM/yyyy}\n" +
            $"Trạng thái: {(product.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
            string.Format(Vi, "Thành tiền: {0:N0} đ\n", product.ThanhTien) +
            $"Ảnh: {(string.IsNullOrEmpty(product.DuongDanAnh) ? "(chưa có)" : product.DuongDanAnh)}";

        MessageBox.Show(message, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    private void mnuXuatTxt_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog();
        dialog.Title = "Xuất danh sách sản phẩm";
        dialog.Filter = "Text file|*.txt";
        dialog.FileName = "DanhSachSanPham.txt";
        if (dialog.ShowDialog() != DialogResult.OK) return;
        var lines = new List<string> { "MaSP\tTenSP\tLoaiSP\tDonGia\tSoLuong\tNgayNhap\tConKinhDoanh" };
        lines.AddRange(allProducts.Select(p =>
            $"{p.MaSP}\t{p.TenSP}\t{p.LoaiSP}\t{p.DonGia:0}\t{p.SoLuong}\t{p.NgayNhap:dd/MM/yyyy}\t{p.ConKinhDoanh}"));

        try
        {
            File.WriteAllLines(dialog.FileName, lines, new UTF8Encoding(true));
            UpdateStatus("Đã xuất danh sách ra file: " + Path.GetFileName(dialog.FileName));
        }
        catch (IOException ex)
        {
            MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void mnuThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }
    private void mnuSapXepGia_Click(object? sender, EventArgs e)
    {
        List<Product> sorted = sortGiaAscending
            ? allProducts.OrderBy(p => p.DonGia).ToList()
            : allProducts.OrderByDescending(p => p.DonGia).ToList();
        ApplySort(sorted, "đơn giá", sortGiaAscending);
        sortGiaAscending = !sortGiaAscending;
    }
    private void mnuSapXepSL_Click(object? sender, EventArgs e)
    {
        List<Product> sorted = sortSoLuongAscending
            ? allProducts.OrderBy(p => p.SoLuong).ToList()
            : allProducts.OrderByDescending(p => p.SoLuong).ToList();
        ApplySort(sorted, "số lượng", sortSoLuongAscending);
        sortSoLuongAscending = !sortSoLuongAscending;
    }
    private void ApplySort(List<Product> sorted, string field, bool ascending)
    {
        allProducts.Clear();
        allProducts.AddRange(sorted);
        RefreshGrid();
        ClearInput();
        UpdateStatus($"Đã sắp xếp theo {field} ({(ascending ? "tăng dần" : "giảm dần")})");
    }
    private void mnuGioiThieu_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("ProductManager - Lab COMP1019\nỨng dụng Windows Forms quản lý sản phẩm.",
            "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
