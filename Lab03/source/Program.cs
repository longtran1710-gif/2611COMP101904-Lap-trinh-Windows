using System;
using System.Globalization;

namespace Lab03
{
    class Program
    {
        static QuanLySinhVien ql = new QuanLySinhVien();

        static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim theo ma");
                Console.WriteLine("4. Tim theo ten");
                Console.WriteLine("5. Sua diem");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string chon = Console.ReadLine();
                Console.WriteLine();

                switch (chon)
                {
                    case "1": Them(); break;
                    case "2": Xuat(); break;
                    case "3": TimMa(); break;
                    case "4": TimTen(); break;
                    case "5": Sua(); break;
                    case "6": Xoa(); break;
                    case "7": SapXep(); break;
                    case "8": LocDat(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon sai!"); break;
                }
            }
        }
        static double NhapDiem(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

                if (!double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                {
                    Console.WriteLine("Diem khong hop le: hay nhap mot so (vi du 8.5). Nhap lai!");
                    continue;
                }

                if (diem < 0 || diem > 10)
                {
                    Console.WriteLine("Diem khong hop le: diem phai tu 0 den 10. Nhap lai!");
                    continue;
                }

                return diem;
            }
        }

        static DateTime NhapNgaySinh(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = (Console.ReadLine() ?? "").Trim();

                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                           DateTimeStyles.None, out DateTime ngaySinh))
                    return ngaySinh;

                Console.WriteLine("Ngay sinh khong hop le: nhap theo dinh dang dd/MM/yyyy. Nhap lai!");
            }
        }

        static void Them()
        {
            try
            {
                Console.Write("Ma SV: ");
                string ma = Console.ReadLine();

                Console.Write("Ho ten: ");
                string ten = Console.ReadLine();

                DateTime ns = NhapNgaySinh("Ngay sinh (dd/MM/yyyy): ");

                Console.Write("Ma lop: ");
                string lop = Console.ReadLine();

                double diem = NhapDiem("Diem TB (0-10): ");

                SinhVien sv = new SinhVien(ma, ten, ns, lop, diem);
                ql.Them(sv);
                Console.WriteLine("Them thanh cong!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi: " + e.Message);
            }
        }

        static void Xuat()
        {
            var ds = ql.LayDanhSach();
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            foreach (var sv in ds)
                Console.WriteLine(sv.LayThongTin());
        }

        static void TimMa()
        {
            Console.Write("Nhap ma: ");
            var sv = ql.TimTheoMa(Console.ReadLine());
            if (sv == null) Console.WriteLine("Khong tim thay");
            else Console.WriteLine(sv.LayThongTin());
        }

        static void TimTen()
        {
            Console.Write("Nhap tu khoa: ");
            var kq = ql.TimTheoTen(Console.ReadLine());
            if (kq.Count == 0) Console.WriteLine("Khong tim thay");
            else foreach (var sv in kq) Console.WriteLine(sv.LayThongTin());
        }

        static void Sua()
        {
            try
            {
                Console.Write("Nhap ma: ");
                string ma = Console.ReadLine();

                if (ql.TimTheoMa(ma) == null)
                {
                    Console.WriteLine("Khong tim thay");
                    return;
                }

                double diem = NhapDiem("Diem moi (0-10): ");
                ql.SuaDiem(ma, diem);
                Console.WriteLine("Sua thanh cong");
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi: " + e.Message);
            }
        }

        static void Xoa()
        {
            Console.Write("Nhap ma: ");
            if (ql.Xoa(Console.ReadLine()))
                Console.WriteLine("Xoa thanh cong");
            else
                Console.WriteLine("Khong tim thay");
        }

        static void SapXep()
        {
            var ds = ql.SapXepTheoDiem();
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            foreach (var sv in ds)
                Console.WriteLine(sv.LayThongTin());
        }

        static void LocDat()
        {
            var ds = ql.LocSinhVienDat();
            if (ds.Count == 0) Console.WriteLine("Khong co sinh vien dat");
            else foreach (var sv in ds) Console.WriteLine(sv.LayThongTin());
        }
    }
}
