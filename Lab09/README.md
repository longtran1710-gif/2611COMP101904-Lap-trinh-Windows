# COMP1019_Lab09_StudentCard

Ứng dụng WinForms thiết kế và in thẻ sinh viên (COMP1019 - Buổi 9).

## Cách chạy
1. Mở file `COMP1019_Lab09_StudentCard.csproj` bằng Visual Studio 2022 trở lên (không mở riêng từng file .cs).
2. Nhấn F5. Project dùng `net8.0-windows`; nếu máy dùng .NET khác thì sửa `TargetFramework` trong `.csproj`.

## Cách dùng
1. Nhập mã sinh viên, họ tên, chọn ngày sinh, giới tính, lớp, khoa, khóa học; bấm **Chọn ảnh...** để chọn ảnh JPG/PNG/BMP.
2. Thẻ ở bên phải được vẽ lại ngay khi dữ liệu thay đổi.
3. **Xem trước in** mở PrintPreviewDialog, **In thẻ** mở PrintDialog. Hai nút này chỉ chạy khi đã có mã sinh viên, họ tên và ảnh.
4. **Làm mới** đưa form về trạng thái ban đầu. **Màu nền thẻ** và **Lưu thẻ PNG** là chức năng mở rộng.
5. Muốn thử in mà không có máy in thật, chọn máy in "Microsoft Print to PDF".

## Cấu trúc
- `Models/StudentInfo.cs`: dữ liệu thẻ.
- `CardRenderer.cs`: vẽ thẻ bằng GDI+, dùng chung cho preview, in và lưu PNG.
- `PreviewPanel.cs`: Panel bật DoubleBuffered.
- `FrmStudentCard.cs`, `FrmStudentCard.Designer.cs`: giao diện và xử lý sự kiện.

## Kiểm thử
Xem file `TESTCASES.md`.
