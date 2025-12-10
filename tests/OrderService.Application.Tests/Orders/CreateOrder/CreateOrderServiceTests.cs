using FluentAssertions;
using OrderService.Application.Orders;
using OrderService.Application.Orders.CreateOrder;

namespace OrderService.Application.Tests.Orders.CreateOrder;

public class CreateOrderServiceTests
{
    [Fact]
    public async Task ShouldCreateOrderWithValidItems()
    {
        //Arrange
        var handler = new CreateOrderCommandHandler();

        var command = new CreateOrderCommand(
            new List<CreateOrderItemRequest>
            {
                new(Guid.NewGuid(), 2, 50),
                new(Guid.NewGuid(), 1, 100)
            }
        );
        
        //Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        //Assert
        result.OrderId.Should().NotBeEmpty();
        result.TotalAmount.Should().Be(200);
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task ShouldNotCreateOrderWithoutItems()
    {
        //Arrange
        var handler = new CreateOrderCommandHandler();
        var command = new CreateOrderCommand(new List<CreateOrderItemRequest>());
        
        //Act
        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
        
        //Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("O pedido deve ter pelo menos um item.");
    }
}