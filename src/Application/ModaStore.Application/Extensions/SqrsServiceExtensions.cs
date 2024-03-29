using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.DTOs.Shipping;
using ModaStore.Application.Features.Catalog.Category.Commands.Handlers;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Application.Features.Catalog.Pictures.Queries.Handlers;
using ModaStore.Application.Features.Catalog.Pictures.Queries.Models;
using ModaStore.Application.Features.Catalog.Product.Commands.Handlers;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Application.Features.Catalog.Product.Queries.Handlers;
using ModaStore.Application.Features.Catalog.Product.Queries.Models;
using ModaStore.Application.Features.Catalog.ProductType.Queries.Commands;
using ModaStore.Application.Features.Catalog.ProductType.Queries.Models;
using ModaStore.Application.Features.Common.Queries.Handlers;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Application.Features.Customer.Commands.Handlers;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Application.Features.Identity.Authentication.Commands.Handlers;
using ModaStore.Application.Features.Identity.Authentication.Commands.Models;
using ModaStore.Application.Features.Order.OrderManagement.Commands.Handlers;
using ModaStore.Application.Features.Order.OrderManagement.Commands.Models;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Infrastructure.Data.SqlServer;
using ModaStore.Application.Features.Customer.Queries.Models;
using ModaStore.Application.Features.Customer.Queries.Handlers;
using ModaStore.Application.Features.Identity.User.Commands.Handlers;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Application.Features.Identity.User.Queries.Handlers;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Handlers;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;
using ModaStore.Application.Features.Order.Payment.Commands.Handlers;
using ModaStore.Application.Features.Order.Payment.Commands.Models;
using ModaStore.Domain.Entities.Order.Review;


namespace ModaStore.Application.Extensions;

public static class SqrsServiceExtensions
{
    public static IServiceCollection AddSqrsServices(this IServiceCollection services)
    {
        
        services.AddScoped(
            typeof(IRequestHandler<CreateOrUpdatePaymentIntentCommand, Basket>),
            typeof(CreateOrUpdatePaymentIntentCommandHandler)
        );
        
        #region Products

        services.AddScoped(
            typeof(IRepository<Product>),
            typeof(SqlServerRepository<Product>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductDto, Product>, IQueryable<ProductDto>>), 
            typeof(GetGenericQueryHandler<ProductDto, Product>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductDto, Product>, IQueryable<ProductDto>>), 
            typeof(GetGenericQueryHandler<ProductDto, Product>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<AddProductCommand, ProductToPublishDto>), 
            typeof(AddProductCommandHandler)
        );
        
        #endregion
        
        #region Reviews
        
        services.AddScoped(
            typeof(IRequestHandler<GetUserReviewsQuery, List<ReviewDto>>), 
            typeof(GetUserReviewsQueryHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ReviewDto, Review>, IQueryable<ReviewDto>>), 
            typeof(GetGenericQueryHandler<ReviewDto, Review>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<AddReviewCommand, ReviewDto>), 
            typeof(AddReviewCommandHandler)
        );
        
        #endregion
        
        
        #region ProductBrand
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductBrandDto, ProductBrand>, IQueryable<ProductBrandDto>>), 
            typeof(GetGenericQueryHandler<ProductBrandDto, ProductBrand>)
        );
        
        // services.AddScoped(
        //     typeof(IRequestHandler<CreateProductBrandCommand, ProductBrandDto>), 
        //     typeof(CreateProductBrandCommandHandler)
        // );
        //
        // services.AddScoped(
        //     typeof(IRequestHandler<UpdateProductBrandCommand, ProductBrandDto>), 
        //     typeof(UpdateProductBrandCommandHandler)
        // );
        //
        // services.AddScoped(
        //     typeof(IRequestHandler<DeleteProductBrandCommand, bool>), 
        //     typeof(DeleteProductBrandCommandHandler)
        // );
        
        #endregion

        #region ProductType

        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductTypeDto, ProductType>, IQueryable<ProductTypeDto>>), 
            typeof(GetGenericQueryHandler<ProductTypeDto, ProductType>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<GetTypesByCategoryQuery, IQueryable<ProductTypeDto>>), 
            typeof(GetTypesByCategoryQueryHandler)
        );
        
        // services.AddScoped(
        //     typeof(IRequestHandler<CreateProductTypeCommand, ProductTypeDto>), 
        //     typeof(CreateProductTypeCommandHandler)
        // );
        //
        // services.AddScoped(
        //     typeof(IRequestHandler<UpdateProductTypeCommand, ProductTypeDto>), 
        //     typeof(UpdateProductTypeCommandHandler)
        // );
        //
        // services.AddScoped(
        //     typeof(IRequestHandler<DeleteProductTypeCommand, bool>), 
        //     typeof(DeleteProductTypeCommandHandler)
        // );

        #endregion
        
        #region Category
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<CategoryDto, Category>, IQueryable<CategoryDto>>), 
            typeof(GetGenericQueryHandler<CategoryDto, Category>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<CreateCategoryCommand, CategoryDto>), 
            typeof(CreateCategoryCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<UpdateCategoryCommand, CategoryDto>), 
            typeof(UpdateCategoryCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<DeleteCategoryCommand, bool>), 
            typeof(DeleteCategoryCommandHandler)
        );
        
        #endregion
        
        #region Basket
        
        services.AddScoped(
            typeof(IRequestHandler<GetBasketByIdQuery, BasketDto>),
            typeof(GetBasketByIdQueryHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<CreateBasketCommand, BasketDto>), 
            typeof(CreateBasketCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<UpdateBasketCommand, BasketDto>), 
            typeof(UpdateBasketCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<DeleteBasketCommand, bool>), 
            typeof(DeleteBasketCommandHandler)
        );
        
        #endregion
        
        #region Wishlist
        
        services.AddScoped(
            typeof(IRequestHandler<GetWishlistByIdQuery, WishlistDto>),
            typeof(GetWishlistByIdQueryHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<CreateWishlistCommand, WishlistDto>), 
            typeof(CreateWishlistCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<UpdateWishlistCommand, WishlistDto>), 
            typeof(UpdateWishlistCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<DeleteWishlistCommand, bool>), 
            typeof(DeleteWishlistCommandHandler)
        );
        
        #endregion
        
        #region Order
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<OrderToReturnDto, Order>, IQueryable<OrderToReturnDto>>), 
            typeof(GetGenericQueryHandler<OrderToReturnDto, Order>)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<CreateOrderCommand, OrderToReturnDto>), 
            typeof(CreateOrderCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<DeliveryMethodDto, DeliveryMethod>, IQueryable<DeliveryMethodDto>>), 
            typeof(GetGenericQueryHandler<DeliveryMethodDto, DeliveryMethod>)
        );
        //GetOrdersForUserQueryHandler
        
        services.AddScoped(
            typeof(IRequestHandler<GetOrdersForUserQuery, List<OrderToReturnDto>>), 
            typeof(GetOrdersForUserQueryHandler)
        );
        
        #endregion
        
        #region Identity
        
        services.AddScoped(
            typeof(IRequestHandler<RegisterCommand, UserDto>), 
            typeof(RegisterCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<LoginCommand, UserDto>), 
            typeof(LoginCommandHandler)
        );
        
        #endregion
        
        #region Address
        
        services.AddScoped(
            typeof(IRequestHandler<GetUserAddressQuery, AddressDto>), 
            typeof(GetUserAddressQueryHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<UpdateUserAddressCommand, AddressDto>), 
            typeof(UpdateUserAddressCommandHandler)
        );

        services.AddScoped(
            typeof(IRequestHandler<CheckEmailExistsQuery, bool>), 
            typeof(CheckEmailExistsQueryHandler)
        );
        
        
        
        #endregion
        
        #region SeenProducts
        
        services.AddScoped(
            typeof(IRequestHandler<GetAllSeenProductsQuery, SeenProductsListDto>), 
            typeof(GetAllSeenProductsQueryHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<CreateSeenProductsCommand, SeenProductsListDto>), 
            typeof(CreateSeenProductsCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<UpdateSeenProductsCommand, SeenProductsListDto>), 
            typeof(UpdateSeenProductsCommandHandler)
        );
        
        services.AddScoped(
            typeof(IRequestHandler<DeleteSeenProductsCommand, bool>), 
            typeof(DeleteSeenProductsCommandHandler)
        );
        
        #endregion
        
        #region User

        services.AddScoped(
            typeof(IRequestHandler<GetUserQuery, UserDto>), 
            typeof(GetUserQueryHandler)
        );
        
        #endregion 
        
        #region Pictures 
        
        services.AddScoped(
            typeof(IRequestHandler<GetPicturesByPictureTypeQuery, IQueryable<PictureDto>>), 
            typeof(GetPicturesByPictureTypeQueryHandler)
        );
        
        #endregion
        
        #region Attributes
        
        services.AddScoped(
            typeof(IRequestHandler<GetProductAttributesListsQuery, ProductAttributesDto>), 
            typeof(GetProductAttributesListsQueryHandler)
            
        );
        
        #endregion
        
        #region Colors
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ColorDto, Color>, IQueryable<ColorDto>>), 
            typeof(GetGenericQueryHandler<ColorDto, Color>)
        );
        
        #endregion
        
        #region Sizes
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<SizeDto, Size>, IQueryable<SizeDto>>), 
            typeof(GetGenericQueryHandler<SizeDto, Size>)
        );
        
        #endregion
        
        #region Reviews
        
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ReviewDto, Review>, IQueryable<ReviewDto>>), 
            typeof(GetGenericQueryHandler<ReviewDto, Review>)
        );
        
        #endregion
        
        
        return services;
    }
}