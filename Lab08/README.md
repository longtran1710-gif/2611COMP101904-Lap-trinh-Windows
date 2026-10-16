# COMP1019_Lab08_SimplePaint

## Cách dùng
- Chọn chế độ vẽ (Pen, Line, Rectangle, Ellipse), độ dày 1-20 và màu (nút Chọn màu).
- Giữ chuột trái và kéo trên vùng trắng để vẽ; tọa độ chuột hiện ở thanh trạng thái phía dưới.
- Undo (hoặc Ctrl+Z) xóa nét vẽ cuối; Clear xóa toàn bộ.
- Nâng cao: tô màu hình (tick "Tô màu"), đổi màu nền, mở ảnh nền để vẽ đè, lưu ra file PNG.

## Cấu trúc
- `DrawMode.cs`, `DrawItem.cs`: dữ liệu mỗi nét vẽ, lưu trong `List<DrawItem>`.
- `DrawSurface.cs`: Panel bật DoubleBuffered làm canvas.
- `FrmPaint.cs`, `FrmPaint.Designer.cs`: giao diện và xử lý sự kiện chuột, vẽ lại trong sự kiện Paint.

