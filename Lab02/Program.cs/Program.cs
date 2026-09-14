using System.Threading.Channels;

static int NhapSoNguyen(string mess)
{
    Console.Write(mess);
    return int.Parse(Console.ReadLine());
}
int n = NhapSoNguyen("Nhap n :");
Console.WriteLine("Ban vua nhap :" + n);