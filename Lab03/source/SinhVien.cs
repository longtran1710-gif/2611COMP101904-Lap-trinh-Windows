using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double diemTrungBinh;
        public double DiemTrungBinh
        {
            get { return diemTrungBinh; }
            set
            {
                if (value < 0 || value > 10)
                    throw new Exception("Điểm phải từ 0 đến 10");
                diemTrungBinh = value;
            }
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string maLop, double diem)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSV;
            MaLop = maLop;
            DiemTrungBinh = diem;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return $"Mã: {MaSinhVien} | Họ tên: {HoTen} | Lớp: {MaLop} | Điểm: {DiemTrungBinh} | Xếp loại: {XepLoai()}";
        }
    }
}

