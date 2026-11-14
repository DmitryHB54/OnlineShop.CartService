using AutoMapper;
using MediatR;
using OnlineShop.CartService.Application.Dtos;
using OnlineShop.CartService.Application.Interfaces.Repositories;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Application.Features.Carts.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetCartQueryHandler(
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartByUserId(request.UserId, cancellationToken);

        Console.WriteLine($"CART products: {cart.Items.Count}");
        
        if(cart is null)
        {
            return new CartDto(Guid.Empty, request.UserId, new List<CartItemDto>(), 0, null);
        }

        return _mapper.Map<CartDto>(cart);
    }
}