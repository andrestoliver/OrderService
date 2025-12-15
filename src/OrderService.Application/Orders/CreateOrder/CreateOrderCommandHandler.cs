using MediatR;

namespace OrderService.Application.Orders.CreateOrder;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var total = request.Items.Sum(i => i.Quantity * i.UnitPrice);

        var response = new CreateOrderResponse(
            Guid.NewGuid(),
            total,
            DateTime.UtcNow);
        
        return Task.FromResult(response);
    }
}