using System.Globalization;
using System.Text;
using Lab04.Entities;
using Lab04.Exceptions;
using Lab04.Repositories;
using Lab04.Services;

namespace Lab04;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var service = new ProductService(new Repository<Product>());

        service.ProductAdded += product =>
            PrintSuccess($"[EVENT] Da them san pham: {product.MaSP} - {product.TenSP}");
        service.ProductRemoved += product =>
            PrintSuccess($"[EVENT] Da xoa san pham: {product.MaSP} - {product.TenSP}");

        RunMenu(service);
    }

    private static void RunMenu(ProductService service)
    {
        while (true)
        {
            ShowMenu();

            try
            {
                string choice = ReadLine("Chon: ");
                if (choice == "0")
                {
                    Console.WriteLine("Tam biet!");
                    return;
                }

                HandleChoice(choice, service);
            }
            catch (DuplicateProductException ex)
            {
                PrintError($"Trung ma san pham: {ex.Message}");
            }
            catch (ProductNotFoundException ex)
            {
                PrintError($"San pham khong ton tai: {ex.Message}");
            }
            catch (InvalidProductDataException ex)
            {
                PrintError($"Du lieu san pham khong hop le: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                PrintError($"Du lieu khong hop le: {ex.Message}");
            }
            catch (EndOfStreamException)
            {
                return;
            }
            catch (Exception ex)
            {
                PrintError($"Loi khong mong doi: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("===== PRODUCT MANAGER =====");
        Console.WriteLine("1. Them san pham");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim theo ma");
        Console.WriteLine("4. Tim theo ten");
        Console.WriteLine("5. Loc theo khoang gia");
        Console.WriteLine("6. Xoa san pham");
        Console.WriteLine("7. Tinh tong gia tri kho");
        Console.WriteLine("0. Thoat");
    }

    private static void HandleChoice(string choice, ProductService service)
    {
        switch (choice)
        {
            case "1":
                AddProduct(service);
                break;
            case "2":
                PrintProducts(service.GetAll(), "Danh sach san pham dang rong.");
                break;
            case "3":
                FindProductById(service);
                break;
            case "4":
                SearchProductsByName(service);
                break;
            case "5":
                FilterProductsByPrice(service);
                break;
            case "6":
                RemoveProduct(service);
                break;
            case "7":
                Console.WriteLine($"Tong gia tri kho: {service.CalculateTotalInventoryValue():N0}");
                break;
            default:
                PrintError("Lua chon khong hop le. Vui long chon tu 0 den 7.");
                break;
        }
    }

    private static void AddProduct(ProductService service)
    {
        string maSP = ReadLine("Nhap ma san pham: ");
        string tenSP = ReadLine("Nhap ten san pham: ");
        decimal price = ReadDecimal("Nhap don gia: ");
        int quantity = ReadInt("Nhap so luong: ");
        var product = new Product(maSP, tenSP, price, quantity);
        service.AddProduct(product);
    }

    private static void FindProductById(ProductService service)
    {
        string maSP = ReadLine("Nhap ma san pham can tim: ");
        Product? product = service.FindById(maSP);

        if (product is null)
        {
            Console.WriteLine("Khong tim thay san pham.");
            return;
        }

        Console.WriteLine(product);
    }

    private static void SearchProductsByName(ProductService service)
    {
        string keyword = ReadLine("Nhap tu khoa ten san pham: ");
        PrintProducts(service.SearchByName(keyword), "Khong co san pham nao co ten chua tu khoa.");
    }

    private static void FilterProductsByPrice(ProductService service)
    {
        decimal minPrice = ReadDecimal("Nhap gia nho nhat: ");
        decimal maxPrice = ReadDecimal("Nhap gia lon nhat: ");

        PrintProducts(service.FilterByPrice(minPrice, maxPrice), "Khong co san pham nao trong khoang gia.");
    }

    private static void RemoveProduct(ProductService service)
    {
        string maSP = ReadLine("Nhap ma san pham can xoa: ");
        service.RemoveProduct(maSP);
    }

    private static void PrintProducts(List<Product> products, string emptyMessage)
    {
        if (products.Count == 0)
        {
            Console.WriteLine(emptyMessage);
            return;
        }

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine($"Tong so: {products.Count} san pham.");
    }

    private static string ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new EndOfStreamException();
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            string input = ReadLine(prompt);
            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
            {
                return value;
            }

            PrintError("Vui long nhap so nguyen hop le.");
        }
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            string input = ReadLine(prompt);
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }

            PrintError("Vui long nhap so hop le.");
        }
    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
