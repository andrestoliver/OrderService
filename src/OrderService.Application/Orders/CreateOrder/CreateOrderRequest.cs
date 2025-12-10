namespace OrderService.Application.Orders.CreateOrder;

public record CreateOrderRequest(List<CreateOrderItemRequest> Items);

public record CreateOrderItemRequest(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);