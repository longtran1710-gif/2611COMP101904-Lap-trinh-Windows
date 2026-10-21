# StudentReportDemo - Báo cáo sinh viên bằng LINQ

Lab 13 COMP1019: module báo cáo danh sách sinh viên theo lớp (C# WinForms, LINQ, DataGridView, SaveFileDialog).

## Cách chạy
1. Mở file `StudentReportDemo.csproj` bằng Visual Studio 2022 trở lên (không mở riêng từng file .cs), nhấn F5.
2. Project dùng `net8.0-windows`; nếu máy dùng .NET khác thì sửa `TargetFramework` trong `.csproj`. Không cần cài thêm package hay database.

## Cách dùng
1. Form mở lên đã hiển thị toàn bộ 16 sinh viên mẫu (4 lớp), sắp xếp giảm dần theo điểm.
2. Chọn **Lớp**, **Kết quả** (Tất cả, Đạt, Không đạt), gõ **Từ khóa** (mã hoặc họ tên, không phân biệt hoa thường) rồi bấm **Xem báo cáo** (hoặc nhấn Enter trong ô từ khóa).
3. Bấm **Thống kê** để xem số sinh viên, số đạt, số không đạt và điểm trung bình của từng lớp.
4. Bấm **Xuất file** để lưu bảng đang hiển thị (báo cáo hoặc thống kê) ra file `.csv` hoặc `.txt`. File CSV lưu UTF-8 có BOM nên mở bằng Excel không lỗi tiếng Việt.
5. Dòng chữ đậm phía dưới lưới hiển thị tổng số sinh viên, số đạt, số không đạt và điểm trung bình. Nếu không có sinh viên phù hợp, chương trình hiện thông báo rõ ràng.

## LINQ được dùng ở đâu
| Chức năng | Toán tử LINQ |
|---|---|
| Danh sách lớp trong ComboBox | `Select`, `Distinct`, `OrderBy` |
| Lọc theo lớp, kết quả, từ khóa | `Where` |
| Sắp xếp giảm dần theo điểm | `OrderByDescending`, `ThenBy` |
| Thống kê theo lớp | `GroupBy`, `Count`, `Average` |
| Tổng hợp Đạt, Không đạt, điểm trung bình | `Count`, `Average` |
| Tạo dữ liệu để xuất file | `Select`, `Concat`, `ToList` |

## Cấu trúc
- `Models/SinhVien.cs`: model sinh viên, `KetQua` là thuộc tính chỉ đọc (Đạt nếu điểm từ 5 trở lên).
- `Models/ThongKeLop.cs`, `Models/LopItem.cs`: dữ liệu thống kê và mục ComboBox lớp.
- `Forms/FrmBaoCaoSinhVien.cs`: các hàm `TaoDuLieuMau`, `LoadComboBox`, `XemBaoCao`, `CapNhatThongKe`, `XuatFile`. Phần xuất file có bắt ngoại lệ ghi file.
- `Program.cs`: điểm khởi động.

## Kết quả dự kiến với dữ liệu mẫu
- Toàn bộ: 16 sinh viên, 11 đạt, 5 không đạt, điểm trung bình 6.17.
- Thống kê: CNTT01 (5 sinh viên, 3 đạt, 2 không đạt, TB 6.50), CNTT02 (5, 4, 1, 6.20), SPTIN01 (4, 3, 1, 5.88), SPTOAN01 (2, 1, 1, 5.90).

## Ảnh chụp và file xuất
- Chụp Form sau khi lọc (ví dụ chọn lớp CNTT01, kết quả Không đạt) và thống kê, bỏ vào thư mục `screenshots`.
- File báo cáo `.csv` hoặc `.txt` đã xuất bằng nút Xuất file đặt vào thư mục `output`.
