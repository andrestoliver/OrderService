using FluentValidation;

namespace OrderService.Application.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("O pedido deve ter pelo menos um item.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(x => x.ProductId)
                .NotEmpty();

            items.RuleFor(x => x.Quantity)
                .GreaterThan(0);
            
            items.RuleFor(x => x.UnitPrice)
                .GreaterThan(0);
        });
    }
}