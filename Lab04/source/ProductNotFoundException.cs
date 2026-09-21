namespace Lab04.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string maSP)
        : base($"Khong tim thay san pham co ma '{maSP}'.")
    {
        MaSP = maSP;
    }

    public string MaSP { get; }
}
