namespace OrderService.Domain.Entities;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(Guid id, string name, decimal price)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("O nome do produto não pode ser vazio.");
        if(price <= 0)
            throw new ArgumentException("O valor do produto deve ser maior ou igual a zero.");
        
        Id = id;
        Name = name;
        Price = price;
    }
}