namespace OnlineShop.CartService.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}