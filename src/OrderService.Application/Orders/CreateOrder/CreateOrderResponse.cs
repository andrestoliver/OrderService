namespace OrderService.Application.Orders.CreateOrder;

public record CreateOrderResponse(
    Guid OrderId,
    decimal TotalAmount,
    DateTime CreatedAt);