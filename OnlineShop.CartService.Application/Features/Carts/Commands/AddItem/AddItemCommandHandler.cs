using MediatR;
using OnlineShop.CartService.Application.Common.Exceptions;
using OnlineShop.CartService.Application.Interfaces.HttpCllients;
using OnlineShop.CartService.Application.Interfaces.Repositories;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Application.Features.Carts.Commands.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICatalogServiceClient _catalogServiceClient;
    private readonly IUnitOfWork _unitOfWork;

    public AddItemCommandHandler(
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        ICatalogServiceClient catalogServiceClient,
        IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _catalogServiceClient = catalogServiceClient;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddItemCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartByUserId(command.UserId, cancellationToken);
        if(cart is null)
        {
            cart = new Cart(command.UserId);
            _cartRepository.Add(cart);
        }

        var productInfo = await _catalogServiceClient.GetProductAsync(command.ProductId, cancellationToken);
        if(productInfo is null)
        {
            throw new NotFoundException($"Product with ID {command.ProductId} was not found in catalog");
        }

        var (item, isNew) = cart.AddItem(productInfo.Id, productInfo.Name, productInfo.Price, command.Quantity);
        if (isNew)
        {
            _cartItemRepository.Add(item);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}