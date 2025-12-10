using MediatR;

namespace OrderService.Application.Orders.CreateOrder;

public record CreateOrderCommand(
    List<CreateOrderItemRequest> Items
    ) : IRequest<CreateOrderResponse>;