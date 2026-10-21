-- Lab 10 - COMP1019: Tạo database EduManagerDB, các bảng và ràng buộc
-- Thứ tự chạy: 01_CreateDatabase.sql -> 02_InsertSampleData.sql -> 03_Queries.sql

-- Chuyển sang master để có thể xóa và tạo lại database
USE master;
GO

-- Nếu database đã tồn tại: ngắt các kết nối cũ rồi xóa, để chạy lại từ đầu không bị lỗi
IF DB_ID(N'EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

-- Tạo database mới
CREATE DATABASE EduManagerDB;
GO

-- Chọn database vừa tạo để làm việc
USE EduManagerDB;
GO

-- Bảng KHOA: lưu thông tin khoa, tên khoa không được trùng
CREATE TABLE KHOA
(
    MaKhoa     VARCHAR(20)   NOT NULL,
    TenKhoa    NVARCHAR(100) NOT NULL,
    DienThoai  VARCHAR(15)   NULL,
    CONSTRAINT PK_KHOA PRIMARY KEY (MaKhoa),
    CONSTRAINT UQ_KHOA_TenKhoa UNIQUE (TenKhoa)
);
GO

-- Bảng LOP: mỗi lớp thuộc một khoa (khóa ngoại MaKhoa tham chiếu KHOA)
CREATE TABLE LOP
(
    MaLop   VARCHAR(20)   NOT NULL,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop),
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA (MaKhoa)
);
GO

-- Bảng SINHVIEN: mỗi sinh viên thuộc một lớp (khóa ngoại MaLop); giới tính chỉ nhận Nam hoặc Nữ
CREATE TABLE SINHVIEN
(
    MaSV      VARCHAR(20)   NOT NULL,
    HoTen     NVARCHAR(100) NOT NULL,
    NgaySinh  DATE          NULL,
    GioiTinh  NVARCHAR(10)  NOT NULL,
    DiaChi    NVARCHAR(200) NULL,
    MaLop     VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP (MaLop)
);
GO

-- Bảng MONHOC: lưu môn học, số tín chỉ phải lớn hơn 0
CREATE TABLE MONHOC
(
    MaMH      VARCHAR(20)   NOT NULL,
    TenMH     NVARCHAR(100) NOT NULL,
    SoTinChi  INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMH),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- Bảng KETQUA: điểm của sinh viên theo môn học
-- Khóa chính ghép (MaSV, MaMH) để không nhập trùng điểm; điểm phải từ 0 đến 10
CREATE TABLE KETQUA
(
    MaSV  VARCHAR(20)  NOT NULL,
    MaMH  VARCHAR(20)  NOT NULL,
    Diem  DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN (MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC (MaMH)
);
GO

-- Bảng TAIKHOAN: tài khoản đăng nhập demo, vai trò chỉ nhận Admin hoặc User
CREATE TABLE TAIKHOAN
(
    TenDangNhap  VARCHAR(50)   NOT NULL,
    MatKhau      VARCHAR(100)  NOT NULL,
    HoTen        NVARCHAR(100) NOT NULL,
    VaiTro       NVARCHAR(20)  NOT NULL CONSTRAINT DF_TAIKHOAN_VaiTro DEFAULT N'User',
    TrangThai    BIT           NOT NULL CONSTRAINT DF_TAIKHOAN_TrangThai DEFAULT 1,
    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (TenDangNhap),
    CONSTRAINT CK_TAIKHOAN_VaiTro CHECK (VaiTro IN (N'Admin', N'User'))
);
GO

-- Kiểm tra danh sách bảng đã tạo
SELECT TABLE_NAME AS DanhSachBang
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO
