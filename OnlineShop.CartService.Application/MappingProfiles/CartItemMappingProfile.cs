using AutoMapper;
using OnlineShop.CartService.Application.Dtos;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Application.MappingProfiles;

public class CartItemMappingProfile : Profile
{
    public CartItemMappingProfile()
    {
        CreateMap<CartItem, CartItemDto>()
            .ForCtorParam(nameof(CartItemDto.TotalPrice),
                opt => opt.MapFrom(src => src.UnitPrice * src.Quantity));
    }
}