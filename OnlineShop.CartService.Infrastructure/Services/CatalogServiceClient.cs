using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using OnlineShop.CartService.Application.Dtos;
using OnlineShop.CartService.Application.Interfaces.HttpCllients;

namespace OnlineShop.CartService.Infrastructure.Services;

public class CatalogServiceClient : ICatalogServiceClient
{
	private readonly HttpClient _httpClient;
	private readonly ILogger<CatalogServiceClient> _logger;

	public CatalogServiceClient(
        HttpClient httpClient,
		ILogger<CatalogServiceClient> logger)
	{
		_httpClient = httpClient;
		_logger = logger;
	}

    public async Task<ProductInfo?> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
		try
		{
			var response = await _httpClient.GetAsync($"api/products/{productId}", cancellationToken);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			response.EnsureSuccessStatusCode();

			var productInfo = await response.Content.ReadFromJsonAsync<ProductInfo>();

			return productInfo;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Failed to call CatalogService for product {ProductId}", productId);
			throw;
		}
    }
}