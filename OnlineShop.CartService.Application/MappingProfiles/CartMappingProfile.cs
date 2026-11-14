using AutoMapper;
using OnlineShop.CartService.Application.Dtos;
using OnlineShop.CartService.Domain.Entities;

namespace OnlineShop.CartService.Application.MappingProfiles;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<Cart, CartDto>()
            .ForCtorParam(nameof(CartDto.TotalPrice),
                opt => opt.MapFrom(src => src.Items.Sum(item => item.UnitPrice * item.Quantity)));
    }
}