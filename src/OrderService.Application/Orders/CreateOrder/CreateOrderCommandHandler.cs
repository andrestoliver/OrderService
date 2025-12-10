using MediatR;

namespace OrderService.Application.Orders.CreateOrder;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Items == null || !request.Items.Any())
            throw new ArgumentException("O pedido deve ter pelo menos um item.");
        
        var total = request.Items.Sum(i => i.Quantity * i.UnitPrice);

        var response = new CreateOrderResponse(
            Guid.NewGuid(),
            total,
            DateTime.UtcNow);
        
        return Task.FromResult(response);
    }
}