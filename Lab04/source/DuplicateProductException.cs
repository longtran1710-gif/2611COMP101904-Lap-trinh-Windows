namespace Lab04.Exceptions;

public class DuplicateProductException : Exception
{
    public DuplicateProductException(string maSP)
        : base($"San pham co ma '{maSP}' da ton tai.")
    {
        MaSP = maSP;
    }

    public string MaSP { get; }
}
