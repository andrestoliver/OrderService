using FluentAssertions;
using OrderService.Application.Orders.CreateOrder;

namespace OrderService.Application.Tests.Orders.CreateOrder;

//Testes de negócio
public class CreateOrderCommandHandlerTests
{
    public async Task ShouldCreateOrderWithValidData()
    {
        //Arrange
        var handler = new CreateOrderCommandHandler();
        var command = new CreateOrderCommand(
            new List<CreateOrderItemRequest>
            {
                new(Guid.NewGuid(), 2, 10),
                new(Guid.NewGuid(), 1, 20)
            });
        
        //Act
        var response = await handler.Handle(command, CancellationToken.None);
        
        //Assert
        response.OrderId.Should().NotBeEmpty();
        response.TotalAmount.Should().Be(40);
    }
}