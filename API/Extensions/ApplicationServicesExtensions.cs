using API.Application.Queries.Handlers.Common;
using API.Application.Queries.Models.Common;
using API.Dto.Catalog;
using API.Errors;
using Core.Catalog;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Data.temp;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Category = Core.Models.Catalog.Category;
using NewCategory = Core.Catalog.Category;

namespace API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
        services.AddScoped(typeof(IGenericRepositorys<>),(typeof(GenericRepositorys<>)));
        // services.AddTransient(typeof(IRequestHandler<,>), typeof(GetGenericQueryHandler<,>));
        // services.AddTransient(typeof(IRequestHandler<GetGenericQuery<CategoryDto, Category>, IReadOnlyList<CategoryDto>>), typeof(GetGenericQueryHandler<Category, CategoryDto>));
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<CategoryDto, Category>, IReadOnlyList<CategoryDto>>), 
            typeof(GetGenericQueryHandler<CategoryDto, Category>));
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductDto, Product>, IReadOnlyList<ProductDto>>), 
            typeof(GetGenericQueryHandler<ProductDto, Product>));
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductBrandDto, ProductBrand>, IReadOnlyList<ProductBrandDto>>), 
            typeof(GetGenericQueryHandler<ProductBrandDto, ProductBrand>));
        services.AddScoped(
            typeof(IRequestHandler<GetGenericQuery<ProductTypeDto, ProductType>, IReadOnlyList<ProductTypeDto>>), 
            typeof(GetGenericQueryHandler<ProductTypeDto, ProductType>));
        services.AddScoped(
                typeof(IRequestHandler<GetQueryById<ProductDto, Product>, ProductDto>),
                typeof(GetQueryByIdHandler<ProductDto, Product>));


        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = ActionContext =>
            {
                var errors = ActionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }
    
}