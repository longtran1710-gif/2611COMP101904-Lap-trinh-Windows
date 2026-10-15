# ShopManagerMini - Quản lý cửa hàng mini 

Ứng dụng WinForms nhiều Form: đăng nhập, Form chính MDI, quản lý sản phẩm, quản lý khách hàng, giới thiệu.
Dữ liệu lưu trong bộ nhớ (`DataStore`).

## Tài khoản mẫu
| Username | Password | Họ tên | Vai trò |
|---|---|---|---|
| admin | 123 | Quản trị viên | Admin |
| user | 123 | Nhân viên bán hàng | User |

## Cấu trúc
- `Models/` - `User`, `Product`, `Customer`
- `Data/DataStore.cs` - dữ liệu dùng chung trong bộ nhớ (giữ lại khi đóng/mở lại Form con)
- `Forms/` - `FrmLogin`, `FrmMain`, `FrmProduct`, `FrmCustomer`, `FrmAbout`
- `Program.cs` - hiện FrmLogin bằng `ShowDialog()`, thành công thì chạy FrmMain; hỗ trợ Đăng xuất rồi đăng nhập lại

## Chức năng chính
- **Đăng nhập:** cảnh báo khi bỏ trống, báo lỗi khi sai, đúng thì trả `DialogResult.OK`.
- **FrmMain (MDI Parent):** `IsMdiContainer = true`; menu Hệ thống (Đăng xuất, Thoát), Danh mục (sản phẩm, khách hàng), Trợ giúp (Giới thiệu); StatusStrip hiển thị người dùng, vai trò, đồng hồ; hỏi xác nhận khi thoát/đăng xuất.
- **Không mở trùng Form con:** hàm `OpenChild<T>()` duyệt `MdiChildren`, nếu đã có thì `Activate()`.
- **FrmProduct:** thêm, sửa, xóa (có xác nhận), tìm kiếm theo mã/tên, làm mới; không trùng mã; không cho đơn giá/số lượng âm; dùng `ErrorProvider` + `MessageBox`.
- **FrmCustomer:** thêm, sửa, xóa, tìm kiếm, làm mới; kiểm tra mã trùng và số điện thoại 9-11 chữ số.
- Cách sửa: chọn dòng trên lưới -> dữ liệu lên form -> chỉnh -> bấm **Sửa**.

## Trả lời câu hỏi nộp kèm

**1. SDI và MDI khác nhau như thế nào?**
SDI (Single Document Interface): mỗi Form là một cửa sổ độc lập, mỗi tài liệu/chức năng nằm trong cửa sổ riêng (ví dụ Notepad). MDI (Multiple Document Interface): có một Form cha (`IsMdiContainer = true`) chứa nhiều Form con bên trong vùng làm việc của nó; Form con không ra ngoài Form cha, thu nhỏ/đóng cùng Form cha, dùng chung menu và status bar của Form cha, và có thể sắp xếp bằng `LayoutMdi` (Cascade, Tile).

**2. Vì sao Form đăng nhập nên dùng ShowDialog()?**
`ShowDialog()` mở Form dạng modal: chặn chương trình chạy tiếp cho đến khi Form đóng, người dùng không thao tác được với Form khác, và trả về `DialogResult`. Nhờ vậy `Program` biết đăng nhập thành công (OK) hay hủy (Cancel) rồi mới mở FrmMain. `Show()` không chặn nên không biết kết quả và có thể mở FrmMain khi chưa đăng nhập.

**3. Dữ liệu user được truyền từ FrmLogin sang FrmMain bằng cách nào?**
Khi đăng nhập đúng, FrmLogin gán đối tượng `User` vào property `CurrentUser` rồi đặt `DialogResult.OK`. `Program` đọc `login.CurrentUser`, sau đó truyền vào constructor `new FrmMain(user)`. FrmMain lưu lại và hiển thị tên, vai trò lên StatusStrip.

**4. Nếu bấm menu sản phẩm nhiều lần, chương trình xử lý thế nào để không mở trùng Form?**
Hàm `OpenChild<T>()` duyệt `MdiChildren` tìm Form có kiểu `T`. Nếu có thì khôi phục (nếu đang thu nhỏ) và gọi `Activate()`; nếu chưa có mới tạo Form, gán `MdiParent = this` rồi `Show()`.

**5. Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?**
Dùng constructor cho dữ liệu bắt buộc, Form không hoạt động được nếu thiếu (FrmMain cần `User`). Dùng property cho dữ liệu tùy chọn, dữ liệu gán sau khi tạo Form, hoặc để lấy kết quả ngược lại sau khi Form đóng (FrmLogin trả `CurrentUser` cho Program). Lưu ý: Form có constructor có tham số thì Visual Studio Designer khó mở hơn, nên các Form con (sản phẩm, khách hàng) giữ constructor mặc định.

