using Lab03;
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

        static void Them()
        {
            try
            {
                Console.Write("Ma SV: ");
                string ma = Console.ReadLine();

                Console.Write("Ho ten: ");
                string ten = Console.ReadLine();

                Console.Write("Ngay sinh (dd/MM/yyyy): ");
                DateTime ns = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.Write("Ma lop: ");
                string lop = Console.ReadLine();

                Console.Write("Diem TB: ");
                double diem = double.Parse(Console.ReadLine());

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
                Console.Write("Diem moi: ");
                double diem = double.Parse(Console.ReadLine());

                if (ql.SuaDiem(ma, diem))
                    Console.WriteLine("Sua thanh cong");
                else
                    Console.WriteLine("Khong tim thay");
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
