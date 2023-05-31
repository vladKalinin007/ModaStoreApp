using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Application.Queries.Handlers.Common;
using ModaStore.API.Application.Queries.Models.Common;
using ModaStore.API.Dto.Catalog;
using ModaStore.API.Errors;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models;
using ModaStore.Infrastructure.Data;
using ModaStore.Infrastructure.Data.temp;
using ModaStore.Infrastructure.Services;
using Category = ModaStore.Domain.Models.Catalog.Category;

namespace ModaStore.API.Extensions;

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