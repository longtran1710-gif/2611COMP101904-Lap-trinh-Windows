# ProductManager - Quản lý sản phẩm

Ứng dụng Windows Forms quản lý danh sách sản phẩm, dữ liệu lưu trong bộ nhớ (không dùng SQL Server).

## Cấu trúc
- `Product.cs` - class lưu dữ liệu sản phẩm (có thuộc tính tính toán `ThanhTien`).
- `FrmProduct.cs` - xử lý sự kiện và logic (ValidateInput, ClearInput, LoadProductToForm, UpdateStatus...).
- `FrmProduct.Designer.cs` - khai báo giao diện.
- `Program.cs` - điểm khởi động.

## Chức năng
- Load form: nạp ComboBox loại sản phẩm, 4 sản phẩm mẫu, hiển thị trên `dgvProducts`.
- Thêm / Sửa / Xóa (có MessageBox xác nhận) / Tìm kiếm theo mã hoặc tên (không phân biệt hoa thường) / Làm mới.
- Validation bằng `ErrorProvider` + `MessageBox`: mã rỗng, mã trùng, tên rỗng, đơn giá <= 0, số lượng < 0, ngày nhập lớn hơn hôm nay.
- Bấm Sửa/Xóa khi chưa chọn dòng chỉ hiện thông báo, không gây lỗi.
- Chọn ảnh bằng `OpenFileDialog`, hiển thị trong `picSanPham`.
- `StatusStrip`: trạng thái thao tác, số lượng sản phẩm, tổng giá trị tồn kho.
- `ContextMenuStrip` trên DataGridView: Sửa, Xóa, Xem chi tiết (chuột phải tự chọn dòng đang trỏ).
- Phím tắt: Ctrl+N (Thêm), Ctrl+E (Sửa), Ctrl+D (Xóa), Ctrl+F (Tìm kiếm), F5 (Làm mới), Ctrl+S (Xuất .txt), Ctrl+Q (Thoát); phím Delete trên lưới để xóa; Enter trong ô tìm kiếm; double-click dòng để xem chi tiết.
- Mở rộng: sắp xếp theo đơn giá / số lượng (menu Quản lý), xuất danh sách ra `.txt` (menu File), tổng giá trị tồn kho trên StatusStrip.

## Tên control chính
`txtMaSP`, `txtTenSP`, `cboLoaiSP`, `numDonGia`, `numSoLuong`, `dtpNgayNhap`, `chkConKinhDoanh`, `dgvProducts`, `lblStatus`, `picSanPham`, `errorProvider1`.
