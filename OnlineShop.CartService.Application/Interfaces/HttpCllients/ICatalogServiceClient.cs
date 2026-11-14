using OnlineShop.CartService.Application.Dtos;

namespace OnlineShop.CartService.Application.Interfaces.HttpCllients;

public interface ICatalogServiceClient
{
    Task<ProductInfo?> GetProductAsync(Guid productId, CancellationToken cancellation = default);
}