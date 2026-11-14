using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Application.Interfaces.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetCartByUserIdReadOnly(Guid userId, CancellationToken cancellationToken = default);
    Task<Cart?> GetCartByUserId(Guid userId, CancellationToken cancellationToken = default);
}