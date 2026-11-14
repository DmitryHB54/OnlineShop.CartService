using OnlineShop.CartService.Application.Interfaces.Repositories;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Infrastructure.Persistence.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly CartDbContext _cartDbContext;

    public CartItemRepository(CartDbContext cartDbContext)
    {
        _cartDbContext = cartDbContext;
    }

    public void Add(CartItem cartItem)
    {
        _cartDbContext.CartItems.Add(cartItem);
    }

    public void Remove(CartItem cartItem)
    {
        _cartDbContext.CartItems.Remove(cartItem);
    }
}