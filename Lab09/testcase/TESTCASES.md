# Test case - Lab 09 Thẻ sinh viên

Điền cột "Kết quả thực tế" và "Đạt/Không đạt" sau khi chạy thử từng test case.

| STT | Chức năng | Bước thực hiện | Kết quả mong đợi | Kết quả thực tế | Đạt/Không đạt |
|---|---|---|---|---|---|
| TC01 | Khởi động | Mở chương trình | Form hiện đủ vùng nhập và vùng thẻ; thẻ có khung, tiêu đề, ô "ẢNH 3x4" trống | | |
| TC02 | Validation mã SV | Để trống mã SV, nhập họ tên, chọn ảnh, bấm Xem trước in | Hiện thông báo thiếu "Mã sinh viên", ô mã có biểu tượng lỗi, không mở preview | | |
| TC03 | Validation họ tên | Nhập mã SV, để trống họ tên, chọn ảnh, bấm In thẻ | Hiện thông báo thiếu "Họ tên", không mở PrintDialog | | |
| TC04 | Validation ảnh | Nhập mã SV và họ tên, chưa chọn ảnh, bấm Xem trước in | Hiện thông báo thiếu "Ảnh đại diện", không mở preview | | |
| TC05 | Chọn ảnh JPG | Bấm Chọn ảnh, chọn file .jpg | Ảnh hiện trong PictureBox đúng tỉ lệ, không méo; thẻ bên phải hiện ảnh | | |
| TC06 | Chọn ảnh PNG/BMP | Chọn file .png rồi file .bmp | Ảnh đổi đúng, không lỗi | | |
| TC07 | Không khóa file ảnh | Chọn một ảnh, sau đó đổi tên hoặc xóa file ảnh đó trong File Explorer | Đổi tên/xóa được, chương trình vẫn chạy bình thường | | |
| TC08 | File không phải ảnh | Đổi đuôi file .txt thành .jpg rồi chọn | Hiện thông báo lỗi ảnh, chương trình không bị đóng, ảnh cũ giữ nguyên | | |
| TC09 | Preview tức thời | Gõ họ tên, đổi lớp, khoa, khóa học, giới tính, ngày sinh | Thẻ bên phải cập nhật ngay sau mỗi thay đổi | | |
| TC10 | Họ tên/khoa dài | Nhập họ tên rất dài (60 ký tự) | Chữ bị cắt bằng dấu "…" trong khung, không tràn ra ngoài thẻ | | |
| TC11 | Print Preview | Nhập đủ dữ liệu, bấm Xem trước in | Mở PrintPreviewDialog, thẻ có khung, tiêu đề, ảnh không méo, thông tin đúng | | |
| TC12 | In | Nhập đủ dữ liệu, bấm In thẻ, chọn Microsoft Print to PDF | PrintDialog hiện ra; file PDF có thẻ đúng nội dung | | |
| TC13 | Làm mới | Nhập dữ liệu, chọn ảnh, bấm Làm mới | Ô nhập trống, ảnh bị xóa, thẻ về trạng thái ban đầu, biểu tượng lỗi biến mất | | |
| TC14 | Resize form | Phóng to, thu nhỏ cửa sổ | Thẻ co giãn đúng tỉ lệ, không méo, không mất nội dung | | |
