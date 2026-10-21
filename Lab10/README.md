# Lab 10 - Cơ sở dữ liệu EduManagerDB (SQL Server)

## Cách chạy
Mở SQL Server Management Studio (hoặc Azure Data Studio), kết nối vào SQL Server rồi chạy lần lượt:
1. `01_CreateDatabase.sql` - xóa database cũ nếu có, tạo `EduManagerDB`, tạo 6 bảng và ràng buộc.
2. `02_InsertSampleData.sql` - nhập dữ liệu mẫu.
3. `03_Queries.sql` - chạy 12 truy vấn theo đề và 3 test ràng buộc thêm. Thông báo lỗi của các test nằm ở tab **Messages**.

Muốn chạy lại từ đầu thì chạy lại file 01 rồi 02 (file 01 tự đóng kết nối cũ và xóa database trước khi tạo lại).

## Cấu trúc bảng
| Bảng | Khóa chính | Khóa ngoại | Ràng buộc chính |
|---|---|---|---|
| KHOA | MaKhoa | - | TenKhoa duy nhất |
| LOP | MaLop | MaKhoa -> KHOA | Mỗi lớp thuộc một khoa |
| SINHVIEN | MaSV | MaLop -> LOP | GioiTinh chỉ nhận Nam hoặc Nữ |
| MONHOC | MaMH | - | SoTinChi > 0 |
| KETQUA | (MaSV, MaMH) | MaSV -> SINHVIEN, MaMH -> MONHOC | Diem từ 0 đến 10; khóa ghép chặn nhập trùng điểm |
| TAIKHOAN | TenDangNhap | - | VaiTro chỉ nhận Admin hoặc User |

Quan hệ: KHOA 1-n LOP, LOP 1-n SINHVIEN, SINHVIEN n-n MONHOC thông qua KETQUA.

## Dữ liệu mẫu
2 khoa, 3 lớp, 6 sinh viên, 4 môn học, 9 kết quả học tập, 2 tài khoản (`admin`/`123`, `user`/`123`).

## Danh sách truy vấn (03_Queries.sql)
1. Liệt kê sinh viên. 2. Sinh viên kèm lớp và khoa (JOIN). 3. Tìm theo họ tên (LIKE). 4. Sinh viên theo mã lớp.
5. UPDATE họ tên và lớp. 6. DELETE sinh viên chưa có điểm (và thử xóa sinh viên đã có điểm để thấy lỗi khóa ngoại).
7. Điểm từng sinh viên theo môn. 8. Điểm trung bình từng sinh viên (GROUP BY). 9. Số sinh viên theo lớp.
10. Lớp có từ 2 sinh viên (HAVING). 11. Lỗi khi thêm sinh viên vào lớp không tồn tại. 12. Lỗi khi nhập điểm ngoài 0 đến 10.
Thêm: 13 giới tính sai, 14 số tín chỉ bằng 0, 15 nhập trùng điểm.

## Kết quả mong đợi của các test lỗi
- Test 11 và test 6 (xóa SV001): lỗi 547, vi phạm FOREIGN KEY.
- Test 12, 13, 14: lỗi 547, vi phạm CHECK constraint.
- Test 15: lỗi 2627, vi phạm PRIMARY KEY.

