using OrderService.Domain.Entities;

namespace OrderService.Application.Orders.CreateOrder;

public class CreateOrderService
{
    public CreateOrderResponse Execute(CreateOrderRequest request)
    {
        if(request.Items == null || !request.Items.Any())
            throw new ArgumentNullException("O pedido deve ter pelo menos um item.");

        var order = new Order(Guid.NewGuid());

        foreach (var item in request.Items)
        {
            order.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
        }

        return new CreateOrderResponse(
            order.Id,
            order.TotalAmount,
            order.CreatedAt);
    }
}