namespace OnlineShop.CartService.Application.Dtos;

public record CartDto(
    Guid Id,
    Guid UserId,
    List<CartItemDto> Items,
    decimal TotalPrice,
    DateTime? UpdatedAt);