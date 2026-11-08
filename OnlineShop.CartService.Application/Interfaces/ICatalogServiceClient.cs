using OnlineShop.CartService.Application.Dtos;

namespace OnlineShop.CartService.Application.Interface;

public interface ICatalogServiceClient
{
    Task<ProductInfo?> GetProductAsync(Guid productId, CancellationToken cancellation = default);
}