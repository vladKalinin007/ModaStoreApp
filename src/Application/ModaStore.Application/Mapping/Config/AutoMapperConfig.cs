using AutoMapper;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Customer.Wishlist;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Application.Mapping.Config;

public static class AutoMapperConfig
{
    public static IMapper Mapper { get; private set; }

    public static void Initialize()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDto>();
            
            #region Product
            
            cfg.CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.PictureUrl, opt => opt.MapFrom(src => "https://localhost:5001/" + src.PictureUrl));

            cfg.CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductBrand,
                    opt => opt.MapFrom(src => new ProductBrand { Name = src.ProductBrand }))
                .ForMember(dest => dest.ProductType,
                    opt => opt.MapFrom(src => new ProductType { Name = src.ProductType }));
            
            

            #endregion

            cfg.CreateMap<ProductBrand, ProductBrandDto>();
            cfg.CreateMap<ProductType, ProductTypeDto>();
            cfg.CreateMap<Category, CategoryDto>();
            
            
            #region Customer

            cfg.CreateMap<Address, AddressDto>();
            cfg.CreateMap<AddressDto, Address>();
            
            cfg.CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            
            cfg.CreateMap<Order, OrderDto>().ReverseMap();
            
            cfg.CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
                // .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            cfg.CreateMap<Basket, BasketDto>();

            cfg.CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            cfg.CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            
            cfg.CreateMap<BasketDto, Basket>().ReverseMap();
            cfg.CreateMap<BasketItemDto, BasketItem>().ReverseMap();

            #endregion
            
            cfg.CreateMap<Wishlist, WishlistDto>().ReverseMap();
            cfg.CreateMap<WishlistItem, WishlistItemDto>().ReverseMap();
        });

        Mapper = configuration.CreateMapper();
    }
}
