namespace OnlineShop.CartService.Application.Dtos;

public record CartItemDto(
    Guid ProductId,
    string ProductName,
    decimal UnitPrice,
    int Quantity,
    decimal TotalPrice);