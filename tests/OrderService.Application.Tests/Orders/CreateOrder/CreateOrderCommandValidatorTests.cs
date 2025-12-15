using FluentAssertions;
using OrderService.Application.Orders.CreateOrder;
using OrderService.Domain.Entities;

namespace OrderService.Application.Tests.Orders.CreateOrder;

//Testes de validação
public class CreateOrderCommandValidatorTests
{
    [Fact]
    public void ShouldFailWhenOrderHasNoItems()
    {
        //Arrange
        var validator = new CreateOrderCommandValidator();
        var command = new CreateOrderCommand(new List<CreateOrderItemRequest>());
        
        //Act
        var result = validator.Validate(command);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(e => e.ErrorMessage == "O pedido deve ter pelo menos um item.");
    }

    [Fact]
    public void ShouldPassWhenOrderHasItems()
    {
        //Arrange
        var validator = new CreateOrderCommandValidator();
        var command = new CreateOrderCommand(
            new List<CreateOrderItemRequest>
            {
                new(Guid.NewGuid(), 1, 10)
            });
        
        //Act
        var result = validator.Validate(command);
        
        //Assert
        result.IsValid.Should().BeTrue();
    }
}