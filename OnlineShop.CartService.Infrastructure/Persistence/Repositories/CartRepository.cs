using Microsoft.EntityFrameworkCore;
using OnlineShop.CartService.Application.Interfaces.Repositories;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Infrastructure.Persistence.Repositories;

public class CartRepository : ICartRepository
{
    private readonly CartDbContext _cartDbContext;

    public CartRepository(CartDbContext cartDbContext)
    {
        _cartDbContext = cartDbContext;
    }

    public Task<Cart?> GetCartByUserIdReadOnly(Guid userId, CancellationToken cancellationToken = default)
    {
        return _cartDbContext.Carts
            .AsNoTracking()
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
    }

    public Task<Cart?> GetCartByUserId(Guid userId, CancellationToken cancellationToken = default)
    {
        return _cartDbContext.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
    }

    public void Add(Cart cart)
    {
        _cartDbContext.Carts.Add(cart);
    }

    public void Remove(Cart cart)
    {
        _cartDbContext.Carts.Remove(cart);
    }
}