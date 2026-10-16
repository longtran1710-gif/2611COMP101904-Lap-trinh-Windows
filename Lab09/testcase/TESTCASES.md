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
