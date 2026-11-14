using OnlineShop.CartService.Application.Interfaces.Repositories;

namespace OnlineShop.CartService.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CartDbContext _cartDbContext;

    public UnitOfWork(CartDbContext cartDbContext)
    {
        _cartDbContext = cartDbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _cartDbContext.SaveChangesAsync(cancellationToken);
    }
}