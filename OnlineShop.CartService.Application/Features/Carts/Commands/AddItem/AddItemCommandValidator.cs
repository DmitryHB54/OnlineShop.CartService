using FluentValidation;

namespace OnlineShop.CartService.Application.Features.Carts.Commands.AddItem;

public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
{
    public AddItemCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("ID is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be at least 1");
    }
}