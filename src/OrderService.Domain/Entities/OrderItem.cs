namespace OrderService.Domain.Entities;

public class OrderItem
{
    public Guid ProductId { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public decimal Total => Quantity * UnitPrice;

    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        if(quantity <= 0)
            throw new ArgumentException("Quantidade de ser igual ou maior a 0.");
        if(unitPrice <= 0)
            throw new ArgumentException("Preco unitário deve ser igual ou maior a 0.");
        
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}