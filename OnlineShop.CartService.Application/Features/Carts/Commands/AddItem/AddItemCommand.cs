using MediatR;

namespace OnlineShop.CartService.Application.Features.Carts.Commands.AddItem;

public record AddItemCommand(Guid UserId, Guid ProductId, int Quantity) : IRequest;