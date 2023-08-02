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

namespace ModaStore.Application.Extensions.Mapper;

public static class MappingExtensions
{
    #region Category

    public static CategoryDto ToDto(this Category entity)
    {
        return entity.MapTo<Category, CategoryDto>();
    }
    
    public static Category ToEntity(this CategoryDto model)
    {
        return model.MapTo<CategoryDto, Category>();
    }
    
    public static Category ToEntity(this CategoryDto dto, Category destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region Product

    public static ProductDto ToDto(this Product entity)
    {
        return entity.MapTo<Product, ProductDto>();
    }
    
    public static Product ToEntity(this ProductDto dto)
    {
        return dto.MapTo<ProductDto, Product>();
    }
    
    public static Product ToEntity(this ProductDto dto, Product destination)
    {
        return dto.MapTo(destination);
    }
    
    public static IQueryable<D> ToDtoQuery<D>(this Product entity)
    {
        return new List<Product> { entity }.AsQueryable().ToDto<D>();
    }
    
    
    public static ProductToPublishDto ToPDto(this Product entity)
    {
        return entity.MapTo<Product, ProductToPublishDto>();
    }
    
    public static Product ToEntity(this ProductToPublishDto dto)
    {
        return dto.MapTo<ProductToPublishDto, Product>();
    }
    
    #endregion
    
    #region Order
    
    // public static OrderDto ToDto(this Order entity)
    // {
    //     return entity.MapTo<Order, OrderDto>();
    // }
    
    public static Order ToEntity(this OrderDto dto)
    {
        return dto.MapTo<OrderDto, Order>();
    }
    
    public static Order ToEntity(this OrderDto dto, Order destination)
    {
        return dto.MapTo(destination);
    }
    
        
    public static List<OrderToReturnDto> ToDtoList(this IList<Order> entity)
    {
        return entity.MapTo<IList<Order>, List<OrderToReturnDto>>();
    }
    
    public static OrderToReturnDto ToDto(this Order entity)
    {
        return entity.MapTo<Order, OrderToReturnDto>();
    }
    
    #endregion
    
    #region Basket
    
    public static BasketDto ToDto(this Basket entity)
    {
        return entity.MapTo<Basket, BasketDto>();
    }
    
    public static Basket ToEntity(this BasketDto dto)
    {
        return dto.MapTo<BasketDto, Basket>();
    }
    
    public static Basket ToEntity(this BasketDto dto, Basket destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region Address
    
    public static AddressDto ToDto(this Address entity)
    {
        return entity.MapTo<Address, AddressDto>();
    }
    
    public static Address ToEntity(this AddressDto dto)
    {
        return dto.MapTo<AddressDto, Address>();
    }


    public static Address ToEntity(this AddressDto dto, Address destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region AppUser
    
    public static RegisterDto ToRegisterDto(this AppUser entity)
    {
        return entity.MapTo<AppUser, RegisterDto>();
    }
    
    public static AppUser ToEntity(this RegisterDto dto)
    {
        return dto.MapTo<RegisterDto, AppUser>();
    }
    
    public static AppUser ToEntity(this RegisterDto dto, AppUser destination)
    {
        return dto.MapTo(destination);
    }
    
    public static UserDto ToDto(this AppUser entity)
    {
        return entity.MapTo<AppUser, UserDto>();
    }
    
    public static AppUser ToEntity(this UserDto dto)
    {
        return dto.MapTo<UserDto, AppUser>();
    }
    
    public static AppUser ToEntity(this UserDto dto, AppUser destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region Wishlist
    
    public static WishlistDto ToDto(this Wishlist entity)
    {
        return entity.MapTo<Wishlist, WishlistDto>();
    }
    
    public static Wishlist ToEntity(this WishlistDto dto)
    {
        return dto.MapTo<WishlistDto, Wishlist>();
    }
    
    public static Wishlist ToEntity(this WishlistDto dto, Wishlist destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region SeenProducts
    
    public static SeenProductsListDto ToDto(this SeenProductsList entity)
    {
        return entity.MapTo<SeenProductsList, SeenProductsListDto>();
    }
    
    public static SeenProductsList ToEntity(this SeenProductsListDto dto)
    {
        return dto.MapTo<SeenProductsListDto, SeenProductsList>();
    }
    
    public static SeenProductsList ToEntity(this SeenProductsListDto dto, SeenProductsList destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
    
    #region Picture
    
    public static PictureDto ToDto(this Picture entity)
    {
        return entity.MapTo<Picture, PictureDto>();
    }
    
    public static Picture ToEntity(this PictureDto dto)
    {
        return dto.MapTo<PictureDto, Picture>();
    }
    
    public static Picture ToEntity(this PictureDto dto, Picture destination)
    {
        return dto.MapTo(destination);
    }
    
    #endregion
}