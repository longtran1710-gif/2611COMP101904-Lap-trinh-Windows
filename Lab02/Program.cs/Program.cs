using System.Threading.Channels;
class Program
{

    static int NhapSoNguyen(string mess)
    {
        Console.Write(mess);
        return int.Parse(Console.ReadLine());
    }
    static int NhapSoNguyenDuong(string mess)
    {
        int n;
        do
        {
            n = NhapSoNguyen(mess);
            if (n <= 0)
            {
                Console.WriteLine("Vui long nhap so nguyen duong");
            }
        } while (n <= 0);
        return n;
    }

    static int[] NhapMang()
    {
        int n = NhapSoNguyenDuong("Nhap so luong phan tu: ");
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = NhapSoNguyen("Nhap a[" + i + "]: ");
        }
        return a;
    }
    static void XuatMang(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
    static int TinhTong(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i];
        }
        return sum;
    }
    static int TimMax(int[] a)
    {
        int max = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max) max = a[i];
        }
        return max;
    }
    static int TimMin(int[] a)
    {
        int min = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min) min = a[i];
        }
        return min;
    }
    static int DemChan(int[] a)
    {
        int dem = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 == 0) dem++;
        }
        return dem;
    }
    static int DemLe(int[] a)
    {
        int dem = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 != 0) dem++;
        }
        return dem;
    }
    static void SapXepTangDan(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] > a[j])
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
            }
        }
    }
    static int TimKiem(int[] a, int x)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == x) return i;
        }
        return -1;
    }
    static void Main()
    {
        int[] a = null;
        int choice;
        do
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max va min");
            Console.WriteLine("5. Dem chan le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
            choice = NhapSoNguyen("Nhap lua chon: ");
            switch (choice)
            {
                case 1:
                    a = NhapMang();
                    break;
                case 2:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc ");
                    }
                    else
                    {
                        XuatMang(a);
                    }
                    break;
                case 3:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc ");
                    }
                    else
                    {
                        Console.WriteLine("Tong = " + TinhTong(a));
                    }
                    break;
                case 4:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc");
                    }
                    else
                    {
                        Console.WriteLine("Max = " + TimMax(a));
                        Console.WriteLine("Min = " + TimMin(a));
                    }
                    break;
                case 5:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc");
                    }
                    else
                    {
                        Console.WriteLine("So chan = " + DemChan(a));
                        Console.WriteLine("So le = " + DemLe(a));
                    }
                    break;
                case 6:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc");
                    }
                    else
                    {
                        SapXepTangDan(a);
                        Console.Write("Mang sau khi sap xep: ");
                        XuatMang(a);
                    }
                    break;
                case 7:
                    if (a == null)
                    {
                        Console.WriteLine("Vui long nhap mang truoc");
                    }
                    else
                    {
                        int x = NhapSoNguyen("Nhap x can tim: ");

                        int viTri = TimKiem(a, x);

                        if (viTri == -1)
                        {
                            Console.WriteLine("Khong tim thay");
                        }
                        else
                        {
                            Console.WriteLine("Tim thay tai vi tri: " + viTri);
                        }
                    }
                    break;
                case 0:
                    Console.WriteLine("Thoat chuong trinh");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le");
                    break;
            }
        } while (choice != 0);
    }
}

