using FluentAssertions;
using OrderService.Application.Orders;
using OrderService.Application.Orders.CreateOrder;

namespace OrderService.Application.Tests.Orders.CreateOrder;

public class CreateOrderServiceTests
{
    private readonly CreateOrderService _service = new();

    [Fact]
    public void ShouldCreateOrderWithValidItems()
    {
        //Arrange
        var request = new CreateOrderRequest(
            new List<CreateOrderItemRequest>
            {
                new(Guid.NewGuid(), 2, 50),
                new(Guid.NewGuid(), 1, 100)
            }
        );
        
        //Act
        var result = _service.Execute(request);
        
        //Assert
        result.OrderId.Should().NotBeEmpty();
        result.TotalAmount.Should().Be(200);
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void ShouldNotCreateOrderWithoutItems()
    {
        //Arrange
        var request = new CreateOrderRequest(new List<CreateOrderItemRequest>());
        
        //Act
        Action act = () => _service.Execute(request);
        
        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("O pedido deve ter pelo menos um item.");
    }
}