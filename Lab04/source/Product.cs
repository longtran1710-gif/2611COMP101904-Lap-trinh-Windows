using Lab04.Exceptions;

namespace Lab04.Entities;

public class Product : IEntity
{
    private string _tenSP = string.Empty;
    private decimal _price;
    private int _quantity;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
        {
            throw new InvalidProductDataException("Ma san pham khong duoc de trong.");
        }

        MaSP = maSP.Trim();
        TenSP = tenSP;
        Price = price;
        Quantity = quantity;
    }

    public string MaSP { get; }

    // Id của IEntity chính là mã sản phẩm.
    public string Id => MaSP;

    public string TenSP
    {
        get => _tenSP;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidProductDataException("Ten san pham khong duoc de trong.");
            }

            _tenSP = value.Trim();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new InvalidProductDataException("Don gia khong duoc am.");
            }

            _price = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
            {
                throw new InvalidProductDataException("So luong khong duoc am.");
            }

            _quantity = value;
        }
    }

    /// <summary>Giá trị tồn kho của riêng sản phẩm này = đơn giá * số lượng.</summary>
    public decimal TotalValue => Price * Quantity;

    public override string ToString()
    {
        return $"Ma: {MaSP,-8} | Ten: {TenSP,-25} | Gia: {Price,15:N0} | SL: {Quantity,6}";
    }
}
