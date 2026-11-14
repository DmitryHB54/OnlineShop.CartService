using MediatR;
using OnlineShop.CartService.Application.Dtos;

namespace OnlineShop.CartService.Application.Features.Carts.Queries.GetCart;

public record GetCartQuery(Guid UserId) : IRequest<CartDto>;