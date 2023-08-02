using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;
using ModaStore.Application.Features.Catalog.Category.Commands.Handlers;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Application.Features.Catalog.Product.Commands.Handlers;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Application.Features.Catalog.Product.Queries.Handlers;
using ModaStore.Application.Features.Catalog.Product.Queries.Models;
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


namespace ModaStore.Application.Extensions;

public static class SqrsServiceExtensions
{
    public static IServiceCollection AddSqrsServices(this IServiceCollection services)
    {
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
        
        
        return services;
    }
}