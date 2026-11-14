using MediatR;
using OnlineShop.CartService.Application.Interfaces.Repositories;

namespace OnlineShop.CartService.Application.Features.Carts.Commands.RemoveItem;

public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveItemCommandHandler(
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveItemCommand command, CancellationToken cancellationToken)
    {
        var cart =
            await _cartRepository.GetCartByUserId(command.UserId, cancellationToken);

        if (cart is null)
            return;

        var item = cart.Items.FirstOrDefault(i => i.ProductId == command.ProductId);

        if (item is null)
            return;

        cart.RemoveItem(command.ProductId);
        _cartItemRepository.Remove(item);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}