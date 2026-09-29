using Lab05;

namespace Lab05;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmDangKy());
    }
}