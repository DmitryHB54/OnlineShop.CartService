using MediatR;

namespace OnlineShop.CartService.Application.Features.Carts.Commands.RemoveItem;

public record RemoveItemCommand(Guid UserId, Guid ProductId) : IRequest;  