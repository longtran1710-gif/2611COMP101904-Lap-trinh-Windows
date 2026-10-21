-- Lab 10 - COMP1019: Nhập dữ liệu mẫu cho EduManagerDB
-- Phải nhập theo thứ tự KHOA -> LOP -> SINHVIEN, MONHOC -> KETQUA để không vi phạm khóa ngoại

-- Chọn database làm việc
USE EduManagerDB;
GO

-- 2 khoa
INSERT INTO KHOA (MaKhoa, TenKhoa, DienThoai) VALUES
('FIT',  N'Khoa Công nghệ Thông tin', '0281234567'),
('MATH', N'Khoa Toán - Tin học',      '0287654321');
GO

-- 3 lớp, mỗi lớp thuộc một khoa đã có
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01',  N'Công nghệ thông tin 01', 'FIT'),
('CNTT02',  N'Công nghệ thông tin 02', 'FIT'),
('SPTIN01', N'Sư phạm Tin học 01',     'MATH');
GO

-- 6 sinh viên, mỗi sinh viên thuộc một lớp đã có
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, MaLop) VALUES
('SV001', N'Nguyễn Văn An',    '2005-02-10', N'Nam', N'Quận 5, TP.HCM',     'CNTT01'),
('SV002', N'Trần Thị Bình',    '2005-08-21', N'Nữ',  N'Quận 10, TP.HCM',    'CNTT01'),
('SV003', N'Lê Minh Chi',      '2004-12-02', N'Nữ',  N'Thủ Đức, TP.HCM',    'CNTT01'),
('SV004', N'Phạm Quốc Dũng',   '2005-04-16', N'Nam', N'Bình Thạnh, TP.HCM', 'CNTT02'),
('SV005', N'Hoàng Gia Hân',    '2005-10-30', N'Nữ',  N'Quận 7, TP.HCM',     'CNTT02'),
('SV006', N'Võ Thành Khang',   '2004-09-09', N'Nam', N'Gò Vấp, TP.HCM',     'SPTIN01');
GO

-- 4 môn học
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('COMP1019', N'Lập trình trên Windows',        3),
('COMP1017', N'Lập trình cơ bản',              3),
('COMP1020', N'Cơ sở dữ liệu',                 3),
('COMP1044', N'Nhập môn Công nghệ phần mềm',   4);
GO

-- 9 kết quả học tập; SV006 cố ý chưa có điểm để dùng cho truy vấn xóa sinh viên chưa có điểm
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'COMP1019', 8.50),
('SV001', 'COMP1020', 7.50),
('SV001', 'COMP1017', 9.00),
('SV002', 'COMP1019', 9.00),
('SV002', 'COMP1020', 8.00),
('SV003', 'COMP1019', 6.50),
('SV004', 'COMP1019', 7.00),
('SV005', 'COMP1017', 8.00),
('SV005', 'COMP1044', 7.50);
GO

-- 2 tài khoản demo
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin', '123', N'Quản trị viên',      N'Admin'),
('user',  '123', N'Nhân viên giáo vụ',  N'User');
GO

-- Đếm số dòng của từng bảng để kiểm tra dữ liệu đã nhập
SELECT 'KHOA' AS Bang, COUNT(*) AS SoDong FROM KHOA
UNION ALL SELECT 'LOP', COUNT(*) FROM LOP
UNION ALL SELECT 'SINHVIEN', COUNT(*) FROM SINHVIEN
UNION ALL SELECT 'MONHOC', COUNT(*) FROM MONHOC
UNION ALL SELECT 'KETQUA', COUNT(*) FROM KETQUA
UNION ALL SELECT 'TAIKHOAN', COUNT(*) FROM TAIKHOAN;
GO
