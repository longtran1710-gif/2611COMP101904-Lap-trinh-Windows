using Lab04.Entities;

namespace Lab04.Repositories;

public class Repository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    public bool Remove(string id)
    {
        T? item = FindById(id);
        if (item is null)
        {
            return false;
        }

        return _items.Remove(item);
    }

    public T? FindById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return default;
        }

        string normalizedId = id.Trim();
        return _items.FirstOrDefault(item =>
            string.Equals(item.Id, normalizedId, StringComparison.OrdinalIgnoreCase));
    }

    public List<T> Find(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return _items.Where(predicate).ToList();
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }
}
