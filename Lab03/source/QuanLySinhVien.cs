using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    public class QuanLySinhVien
    {
        private List<SinhVien> ds = new List<SinhVien>();

        public void Them(SinhVien sv)
        {
            if (ds.Any(x => x.MaSinhVien == sv.MaSinhVien))
                throw new Exception("Mã sinh viên đã tồn tại");
            ds.Add(sv);
        }

        public bool SuaDiem(string ma, double diemMoi)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string ma)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            ds.Remove(sv);
            return true;
        }

        public SinhVien TimTheoMa(string ma)
        {
            return ds.FirstOrDefault(x => x.MaSinhVien == ma);
        }

        public List<SinhVien> TimTheoTen(string ten)
        {
            string tuKhoa = (ten ?? "").Trim();
            return ds.Where(x => x.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<SinhVien> SapXepTheoDiem()
        {
            return ds.OrderByDescending(x => x.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return ds.Where(x => x.DiemTrungBinh >= 5).ToList();
        }

        public List<SinhVien> LayDanhSach()
        {
            return ds;
        }
    }
}
