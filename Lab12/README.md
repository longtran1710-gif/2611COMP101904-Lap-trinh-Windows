# QLSinhVienLab12 - Nhập điểm theo lớp

Lab 12 COMP1019: Data Binding, Stored Procedure và Transaction (C# WinForms, SQL Server, Microsoft.Data.SqlClient).

## Chuẩn bị database
1. Mở SSMS, kết nối vào SQL Server.
2. Mở file `Database/QLSinhVienLab12.sql` và bấm F5. Script tạo database `QLSinhVienLab12`, 4 bảng, dữ liệu mẫu và 4 stored procedure. Chạy lại script bất cứ lúc nào để đưa dữ liệu về ban đầu.

## Cách chạy
1. Mở file `QLSinhVienLab12.csproj` bằng Visual Studio 2022 trở lên (không mở riêng từng file .cs), nhấn F5.
2. Visual Studio tự tải package `Microsoft.Data.SqlClient` khi build (cần Internet lần đầu). Project dùng `net8.0-windows`; nếu máy dùng .NET khác thì sửa `TargetFramework` trong `.csproj`.

## Connection string trên máy cá nhân
Nằm trong `DAL/Database.cs`:

```
Server=localhost\SQLEXPRESS;Database=QLSinhVienLab12;Trusted_Connection=True;TrustServerCertificate=True;
```

## Cách dùng
1. Form tự tải danh sách lớp và môn học vào hai ComboBox (qua `sp_Lop_GetAll`, `sp_MonHoc_GetAll`).
2. Chọn lớp và môn học, bấm **Tải danh sách** (qua `sp_KetQua_GetByLopMon`). Sinh viên đã có điểm thì hiện điểm sẵn.
3. Nhập hoặc sửa cột **Điểm** và **Ghi chú** trực tiếp trên lưới. Điểm là số từ 0 đến 10, dùng dấu chấm (ví dụ 8.5), nhập sai sẽ báo lỗi ngay trên dòng.
4. Bấm **Lưu tất cả**. Điểm của mọi sinh viên không được để trống. Các dòng được lưu trong một transaction qua `sp_KetQua_Save` (đã có điểm thì cập nhật, chưa có thì thêm mới). Thành công thì commit và báo số dòng đã lưu; có lỗi thì rollback toàn bộ.
5. Mở rộng: ô **Lọc** lọc nhanh theo mã hoặc họ tên; nhãn bên cạnh hiện sĩ số, số sinh viên đã nhập điểm và điểm trung bình.

## Kiểm thử rollback
1. Trong SSMS chạy: `ALTER TABLE KETQUA ADD CONSTRAINT CK_Demo CHECK (GhiChu IS NULL OR GhiChu <> N'LOI');`
2. Trong app, tải lớp CNTT01 môn MH01, nhập điểm cho cả 4 sinh viên, gõ ghi chú `LOI` cho sinh viên cuối cùng (SV004) rồi bấm Lưu tất cả.
3. App báo lỗi và rollback. Tải lại danh sách sẽ thấy SV003 và các thay đổi trước đó không được lưu.
4. Xóa constraint thử nghiệm: `ALTER TABLE KETQUA DROP CONSTRAINT CK_Demo;`

## Cấu trúc
- `Forms/FrmNhapDiemTheoLop.cs`: giao diện và xử lý sự kiện.
- `DAL/Database.cs`: connection string. `DAL/KetQuaDAL.cs`: gọi stored procedure, transaction.
- `Models/KetQuaItem.cs`: một dòng điểm cần lưu.
- `Database/QLSinhVienLab12.sql`: script database, dữ liệu mẫu, stored procedure.

## Ảnh chụp màn hình
Chụp Form trước khi lưu (đã tải lớp CNTT01, môn MH01, đã nhập điểm) và sau khi lưu (thông báo thành công, danh sách tải lại), bỏ vào thư mục `screenshots`.
