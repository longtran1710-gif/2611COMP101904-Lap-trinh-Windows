-- Lab 10 - COMP1019: Các truy vấn trên EduManagerDB
-- Chạy sau khi đã chạy 01_CreateDatabase.sql và 02_InsertSampleData.sql
-- Thông báo lỗi của các test (truy vấn 6, 11 đến 15) nằm ở tab Messages

-- Chọn database làm việc
USE EduManagerDB;
GO

-- 1. Lấy toàn bộ sinh viên
PRINT N'=== 1. Liệt kê toàn bộ sinh viên ===';
SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop
FROM SINHVIEN
ORDER BY MaSV;
GO

-- 2. JOIN 3 bảng SINHVIEN, LOP, KHOA để lấy thêm tên lớp và tên khoa
PRINT N'=== 2. Sinh viên kèm tên lớp và tên khoa ===';
SELECT sv.MaSV, sv.HoTen, sv.GioiTinh, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
ORDER BY sv.MaSV;
GO

-- 3. Tìm gần đúng theo họ tên: LIKE với ký tự % ở hai đầu, từ khóa đặt trong biến @TuKhoa
PRINT N'=== 3. Tìm sinh viên theo một phần họ tên (LIKE) ===';
DECLARE @TuKhoa NVARCHAR(50) = N'Văn';
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%' + @TuKhoa + N'%'
ORDER BY HoTen;
GO

-- 4. Lọc sinh viên theo mã lớp, đổi giá trị @MaLop để xem lớp khác
PRINT N'=== 4. Liệt kê sinh viên theo mã lớp ===';
DECLARE @MaLop VARCHAR(20) = 'CNTT01';
SELECT MaSV, HoTen, GioiTinh, NgaySinh
FROM SINHVIEN
WHERE MaLop = @MaLop
ORDER BY MaSV;
GO

-- 5. UPDATE đổi họ tên SV002 và chuyển SV003 sang lớp CNTT02, sau đó SELECT kiểm tra
PRINT N'=== 5. Cập nhật họ tên và lớp của sinh viên ===';
UPDATE SINHVIEN
SET HoTen = N'Trần Thị Thanh Bình'
WHERE MaSV = 'SV002';

UPDATE SINHVIEN
SET MaLop = 'CNTT02'
WHERE MaSV = 'SV003';

SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE MaSV IN ('SV002', 'SV003');
GO

-- 6. Thử xóa SV001 (đã có điểm) sẽ bị chặn bởi khóa ngoại, lỗi được bắt bằng TRY...CATCH
-- Sau đó chỉ xóa SV006 vì NOT EXISTS xác nhận sinh viên này chưa có dữ liệu điểm
PRINT N'=== 6. Xóa sinh viên chưa có dữ liệu điểm ===';
BEGIN TRY
    DELETE FROM SINHVIEN WHERE MaSV = 'SV001';
END TRY
BEGIN CATCH
    PRINT N'Không thể xóa SV001 vì đã có điểm. Lỗi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;

DELETE FROM SINHVIEN
WHERE MaSV = 'SV006'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE KETQUA.MaSV = 'SV006');

SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
ORDER BY MaSV;
GO

-- 7. JOIN KETQUA với SINHVIEN và MONHOC để xem điểm từng sinh viên theo từng môn
PRINT N'=== 7. Điểm của từng sinh viên theo từng môn ===';
SELECT sv.MaSV, sv.HoTen, mh.MaMH, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.MaMH;
GO

-- 8. Điểm trung bình từng sinh viên bằng AVG + GROUP BY
-- LEFT JOIN để sinh viên chưa có điểm vẫn hiện (điểm NULL); DiemTBTheoTinChi là trung bình có trọng số theo số tín chỉ
PRINT N'=== 8. Điểm trung bình của từng sinh viên ===';
SELECT sv.MaSV, sv.HoTen,
       COUNT(kq.MaMH) AS SoMonDaCoDiem,
       CAST(AVG(kq.Diem) AS DECIMAL(4,2)) AS DiemTrungBinh,
       CAST(SUM(kq.Diem * mh.SoTinChi) / NULLIF(SUM(mh.SoTinChi), 0) AS DECIMAL(4,2)) AS DiemTBTheoTinChi
FROM SINHVIEN sv
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
LEFT JOIN MONHOC mh ON kq.MaMH = mh.MaMH
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO

-- 9. Đếm số sinh viên mỗi lớp; LEFT JOIN để lớp chưa có sinh viên vẫn hiện với số 0
PRINT N'=== 9. Thống kê số sinh viên theo từng lớp ===';
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO

-- 10. HAVING lọc sau khi gom nhóm: chỉ giữ lớp có từ 2 sinh viên trở lên
PRINT N'=== 10. Các lớp có từ 2 sinh viên trở lên ===';
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
INNER JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY l.MaLop;
GO

-- 11. Thêm sinh viên vào lớp không tồn tại: vi phạm khóa ngoại (lỗi 547), được bắt bằng TRY...CATCH
PRINT N'=== 11. Test lỗi: thêm sinh viên vào lớp không tồn tại ===';
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV099', N'Sinh Viên Thử Lỗi', '2005-01-01', N'Nam', 'LOPKHONGTONTAI');
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;
GO

-- 12. Nhập điểm 11 và -1: vi phạm CHECK điểm từ 0 đến 10 (lỗi 547)
PRINT N'=== 12. Test lỗi: nhập điểm ngoài khoảng 0 đến 10 ===';
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV001', 'COMP1044', 11);
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;

BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV001', 'COMP1044', -1);
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;
GO

-- 13. (Test thêm) Giới tính 'Khác' vi phạm CHECK chỉ nhận Nam hoặc Nữ
PRINT N'=== 13. Test thêm: giới tính không hợp lệ ===';
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV098', N'Sinh Viên Thử Lỗi', '2005-01-01', N'Khác', 'CNTT01');
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;
GO

-- 14. (Test thêm) Số tín chỉ bằng 0 vi phạm CHECK SoTinChi > 0
PRINT N'=== 14. Test thêm: số tín chỉ không lớn hơn 0 ===';
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES ('COMP9999', N'Môn thử lỗi', 0);
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;
GO

-- 15. (Test thêm) Nhập trùng điểm cùng sinh viên và môn học: vi phạm khóa chính ghép (lỗi 2627)
PRINT N'=== 15. Test thêm: nhập trùng điểm của cùng sinh viên và môn học ===';
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV001', 'COMP1019', 5);
    PRINT N'Thêm thành công (không mong đợi).';
END TRY
BEGIN CATCH
    PRINT N'Lỗi như mong đợi ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N': ' + ERROR_MESSAGE();
END CATCH;
GO
