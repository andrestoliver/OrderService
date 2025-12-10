namespace OrderService.Domain.Entities;

public class Order
{
    private readonly List<OrderItem> _items = new();
    
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalAmount => Items.Sum(item => item.Total);

    public Order(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(Guid id, int quantity, decimal unitPrice)
    {
        _items.Add(new OrderItem(id, quantity, unitPrice));
    }
}