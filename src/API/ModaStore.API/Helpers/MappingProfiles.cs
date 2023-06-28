using AutoMapper;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Customer.Basket;

using Address = ModaStore.Domain.Entities.Order.OrderManagement.Address;


namespace ModaStore.API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<CustomerBasketDto, Basket>();
        CreateMap<BasketItemDto, BasketItem>();
        CreateMap<AddressDto, Address>();
        
        // CreateMap<Order, OrderDto>()
        //     .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
        //     .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        // CreateMap<OrderItem, OrderItemDto>()
        //     .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
        //     .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
        //     .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
        //     .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        CreateMap<Category, CategoryDto>();
        
        CreateMap<ProductBrand, ProductBrandDto>();
        CreateMap<ProductType, ProductTypeDto>();
        
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }
}