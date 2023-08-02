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

            cfg.CreateMap<Picture, PictureDto>();
            cfg.CreateMap<Size, SizeDto>();
            cfg.CreateMap<Tag, TagDto>();
            cfg.CreateMap<Color, ColorDto>();
            cfg.CreateMap<ProductReview, ReviewDto>();
            cfg.CreateMap<Product, RelatedProductDto>();
            
            cfg.CreateMap<ProductPicture, PictureDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Picture.Url))
                .ForMember(dest => dest.PictureType, opt => opt.MapFrom(src => src.Picture.PictureType))
                .ForMember(dest => dest.PictureTypeId, opt => opt.MapFrom(src => src.Picture.PictureTypeId));
            
            cfg.CreateMap<ProductColor, ColorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.ColorCode, opt => opt.MapFrom(src => src.Color.ColorCode));
            
            //"Missing map from ModaStore.Domain.Entities.Catalog.RelatedProducts to ModaStore.Application.DTOs.Catalog.RelatedProductDto.
            //Create using CreateMap<RelatedProducts, RelatedProductDto>."

            cfg.CreateMap<RelatedProducts, RelatedProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RelatedProduct.Name));
            
            cfg.CreateMap<ProductSize, SizeDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Size.Name));
            
            cfg.CreateMap<ProductTag, TagDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Tag.Name));

            cfg.CreateMap<ProductReview, ReviewDto>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            cfg.CreateMap<Product, RelatedProductDto>()
                .ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Pictures,
                    opt => opt.MapFrom(src => src.ProductPictures.Select(pp => pp.Picture)))
                .ForMember(dest => dest.PictureUrl,
                    opt => opt.MapFrom(src => src.ProductPictures.FirstOrDefault().Picture.Url))
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.ProductColors.Select(pc => pc.Color)))
                .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => ps.Size)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => pt.Tag)))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.ProductReviews));
                
            
            
            #region Product

            
            cfg.CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.ProductPictures.Select(pp => pp.Picture)))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.ProductPictures.FirstOrDefault().Picture.Url))
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.ProductColors.Select(pc => pc.Color)))
                .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => ps.Size)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => pt.Tag)))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.ProductReviews))
                .ForMember(dest => dest.RelatedProducts, opt => opt.MapFrom(src => src.RelatedProducts));

            cfg.CreateMap<Product, ProductToPublishDto>()
                .ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(src => src.Category.Name));
                


            cfg.CreateMap<ProductToPublishDto, Product>()
                .ForMember(dest => dest.ProductBrand,
                    opt => opt.MapFrom(src => new ProductBrand { Name = src.ProductBrand }))
                .ForMember(dest => dest.ProductType,
                    opt => opt.MapFrom(src => new ProductType { Name = src.ProductType }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Name = src.Category }));
                // .ForMember(dest => dest.ProductPictures, opt => opt.MapFrom(src => src.Pictures.Select(p => new ProductPicture { Picture = new Picture
                // {
                //     Url = p.Url,
                //     PictureType = p.PictureType,
                // } })))
                // .ForMember(dest => dest.ProductColors, opt => opt.MapFrom(src => src.Colors.Select(c => new ProductColor { Color = new Color
                // {
                //     Name = c.Name, 
                //     ColorCode = c.ColorCode
                // } })))
                // .ForMember(dest => dest.ProductSizes, opt => opt.MapFrom(src => src.Sizes.Select(s => new ProductSize { Size = new Size
                // {
                //     Name = s.Name
                // } })))
                // .ForMember(dest => dest.ProductTags, opt => opt.MapFrom(src => src.Tags.Select(t => new ProductTag { Tag = new Tag
                // {
                //     Name = t.Name
                // } })))
                // .ForMember(dest => dest.ProductReviews, opt => opt.MapFrom(src => src.Reviews))
                // .ForMember(dest => dest.RelatedProducts, opt => opt.MapFrom(src => src.RelatedProducts));
            
            
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
            
            cfg.CreateMap<SeenProductsList, SeenProductsListDto>().ReverseMap();
            cfg.CreateMap<SeenProduct, SeenProductDto>().ReverseMap();
            
            
        });

        Mapper = configuration.CreateMapper();
    }
}
