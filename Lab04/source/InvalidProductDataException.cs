namespace Lab04.Exceptions;

public class InvalidProductDataException : Exception
{
    public InvalidProductDataException(string message)
        : base(message)
    {
    }
}
