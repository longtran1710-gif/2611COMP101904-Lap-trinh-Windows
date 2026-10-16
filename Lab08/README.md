# COMP1019_Lab08_SimplePaint

Ứng dụng Paint đơn giản bằng WinForms và GDI+ (COMP1019 - Buổi 8).

## Cách chạy
1. Giải nén hoặc clone repo, mở `COMP1019_Lab08_SimplePaint.csproj` bằng Visual Studio 2022 trở lên.
2. Nhấn F5 để chạy. Project dùng `net8.0-windows`; nếu máy dùng .NET khác thì sửa `TargetFramework` trong file `.csproj`.

## Cách dùng
- Chọn chế độ vẽ (Pen, Line, Rectangle, Ellipse), độ dày 1-20 và màu (nút Chọn màu).
- Giữ chuột trái và kéo trên vùng trắng để vẽ; tọa độ chuột hiện ở thanh trạng thái phía dưới.
- Undo (hoặc Ctrl+Z) xóa nét vẽ cuối; Clear xóa toàn bộ.
- Nâng cao: tô màu hình (tick "Tô màu"), đổi màu nền, mở ảnh nền để vẽ đè, lưu ra file PNG.

## Cấu trúc
- `DrawMode.cs`, `DrawItem.cs`: dữ liệu mỗi nét vẽ, lưu trong `List<DrawItem>`.
- `DrawSurface.cs`: Panel bật DoubleBuffered làm canvas.
- `FrmPaint.cs`, `FrmPaint.Designer.cs`: giao diện và xử lý sự kiện chuột, vẽ lại trong sự kiện Paint.

## Ảnh chụp màn hình
Đặt ảnh chụp ứng dụng sau khi vẽ thử (Pen, Line, Rectangle, Ellipse) vào thư mục `screenshots` rồi chèn vào đây.
