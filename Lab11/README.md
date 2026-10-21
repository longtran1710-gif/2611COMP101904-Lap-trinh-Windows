# COMP1019_Lab11_LopManager

Ứng dụng WinForms quản lý lớp học bằng ADO.NET (Microsoft.Data.SqlClient) với SQL Server (COMP1019 - Buổi 11).

## Chuẩn bị database
1. Mở SSMS, kết nối vào SQL Server.
2. Chạy lần lượt `Database/01_CreateDatabase.sql` rồi `Database/02_InsertSampleData.sql` (đây là database `EduManagerDB` của Lab 10, có đủ bảng KHOA, LOP, SINHVIEN và dữ liệu mẫu).

## Cách chạy
1. Mở file `COMP1019_Lab11_LopManager.csproj` bằng Visual Studio 2022 trở lên (không mở riêng từng file .cs).
2. Visual Studio tự tải package `Microsoft.Data.SqlClient` khi build (cần có Internet lần đầu). Nếu không tự tải, vào Tools -> NuGet Package Manager -> Package Manager Console và gõ `dotnet restore`.
3. Nhấn F5. Project dùng `net8.0-windows`; nếu máy dùng .NET khác thì sửa `TargetFramework` trong `.csproj`.

## Connection string trên máy cá nhân
Nằm trong file `DbConfig.cs`:

```
Server=localhost\SQLEXPRESS;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;
```

- `localhost\SQLEXPRESS`: SQL Server Express cài trên máy (instance SQLEXPRESS).
- `Trusted_Connection=True`: đăng nhập bằng Windows Authentication, không cần user/password.
- `TrustServerCertificate=True`: bỏ qua kiểm tra chứng chỉ khi mã hóa kết nối trên máy cá nhân.

Nếu máy khác dùng tên server khác thì chỉ cần sửa đúng một chỗ này.

## Chức năng
- Mở Form tự động tải danh sách lớp từ SQL Server lên `dgvLop` (kèm tên khoa và số sinh viên của từng lớp).
- Chọn một dòng thì mã lớp, tên lớp, khoa được đưa lên các ô nhập; ô mã lớp được khóa.
- Thêm: kiểm tra rỗng và trùng mã lớp.
- Sửa: cập nhật tên lớp (và khoa) theo mã lớp đang chọn; báo lỗi nếu chưa chọn lớp.
- Xóa: hỏi xác nhận; không cho xóa lớp đang có sinh viên; còn bắt lỗi khóa ngoại (mã 547) làm lớp bảo vệ thứ hai.
- Tìm kiếm: theo mã hoặc tên lớp bằng `LIKE` với parameter (nhấn Enter trong ô tìm kiếm cũng được).
- Làm mới: xóa ô nhập, mở khóa ô mã lớp, tải lại dữ liệu.
- Mọi câu SQL nhận dữ liệu người dùng đều dùng `SqlParameter`, không nối chuỗi.

## Cấu trúc
- `Models/Lop.cs`, `Models/Khoa.cs`: dữ liệu.
- `DbConfig.cs`: connection string.
- `LopRepository.cs`: toàn bộ câu SQL (thêm, sửa, xóa, tìm kiếm, kiểm tra trùng, đếm sinh viên).
- `FrmLop.cs`, `FrmLop.Designer.cs`: giao diện và xử lý sự kiện.
- `Database/`: script tạo database và dữ liệu mẫu.

## Ghi chú về cột Khoa
Bảng LOP của Lab 10 có cột MaKhoa bắt buộc (khóa ngoại tới KHOA) nên Form có thêm ô chọn Khoa. Nếu chạy trên database chỉ có LOP(MaLop, TenLop) như script tối thiểu trong đề thì ứng dụng tự phát hiện và ẩn ô chọn Khoa.

## Ảnh chụp màn hình
Chụp Form đang hiển thị danh sách lớp lấy từ SQL Server, bỏ vào thư mục `screenshots` và chèn vào đây.
