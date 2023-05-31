using AutoMapper;
using ModaStore.API.Dto;
using ModaStore.API.Dto.Catalog;
using ModaStore.API.Dto.Customers;
using ModaStore.Domain.Models;
using ModaStore.Domain.Models.Catalog;
using ModaStore.Domain.Models.OrderAggregate;
using Address = ModaStore.Domain.Models.Identity.Address;

namespace ModaStore.API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();
        CreateMap<AddressDto, ModaStore.Domain.Models.OrderAggregate.Address>();
        
        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductBrand, ProductBrandDto>();
        CreateMap<ProductType, ProductTypeDto>();
    }
}