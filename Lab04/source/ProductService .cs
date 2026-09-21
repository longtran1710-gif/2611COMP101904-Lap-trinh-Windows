using Lab04.Entities;
using Lab04.Exceptions;
using Lab04.Repositories;

namespace Lab04.Services;

public class ProductService
{
    private readonly Repository<Product> _repository;

    public ProductService(Repository<Product> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public event Action<Product>? ProductAdded;
    public event Action<Product>? ProductRemoved;

    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (_repository.FindById(product.MaSP) is not null)
        {
            throw new DuplicateProductException(product.MaSP);
        }

        _repository.Add(product);
        ProductAdded?.Invoke(product);
    }

    public void RemoveProduct(string maSP)
    {
        Product? product = _repository.FindById(maSP);
        if (product is null)
        {
            throw new ProductNotFoundException(maSP?.Trim() ?? string.Empty);
        }

        _repository.Remove(product.MaSP);
        ProductRemoved?.Invoke(product);
    }

    public List<Product> GetAll()
    {
        return _repository.GetAll();
    }

    public Product? FindById(string maSP)
    {
        return _repository.FindById(maSP);
    }

    public List<Product> SearchByName(string keyword)
    {
        keyword = keyword?.Trim() ?? string.Empty;

        Func<Product, bool> containsKeyword =
            product => product.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase);

        return Search(containsKeyword);
    }

    public List<Product> Search(Func<Product, bool> condition)
    {
        return _repository.Find(condition);
    }

    public List<Product> FilterByPrice(decimal minPrice, decimal maxPrice)
    {
        if (minPrice > maxPrice)
        {
            throw new ArgumentException("Gia nho nhat khong duoc lon hon gia lon nhat.");
        }

        Func<Product, bool> inPriceRange =
            product => product.Price >= minPrice && product.Price <= maxPrice;

        return Search(inPriceRange);
    }

    public decimal CalculateTotalInventoryValue()
    {
        return _repository.GetAll().Sum(product => product.TotalValue);
    }
}
