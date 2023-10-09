using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModaStore.Domain.Interfaces.Authentication.Security;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Customer;
using ModaStore.Domain.Interfaces.Customer.Basket;
using ModaStore.Domain.Interfaces.Customer.Management;
using ModaStore.Domain.Interfaces.Customer.Wishlist;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Interfaces.Identity.Authentication;
using ModaStore.Domain.Interfaces.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Order.Payment;
using ModaStore.Infrastructure.Data;
using ModaStore.Infrastructure.Data.SqlServer;
using ModaStore.Infrastructure.Identity;
using ModaStore.Infrastructure.Services.Catalog;
using ModaStore.Infrastructure.Services.Catalog.Product;
using ModaStore.Infrastructure.Services.Customer;
using ModaStore.Infrastructure.Services.Customer.Basket;
using ModaStore.Infrastructure.Services.Customer.CustomerManagement;
using ModaStore.Infrastructure.Services.Customer.Wishlist;
using ModaStore.Infrastructure.Services.Identity.Authentication;
using ModaStore.Infrastructure.Services.Order.OrderManagement;
using ModaStore.Infrastructure.Services.Order.Payment;
using StackExchange.Redis;
// using Stripe;
using TokenService = ModaStore.Infrastructure.Services.Authentication.Security.TokenService;

namespace ModaStore.Infrastructure.Extensions;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        #region Business logic
        
        services.AddScoped(typeof(IRepository<>), typeof(SqlServerRepository<>));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductBrandService, ProductBrandService>();
        services.AddScoped<IProductTypeService, ProductTypeService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ISeenProductService, SeenProductService>();
        services.AddScoped<IPictureService, PictureService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddSingleton<IBasketService, BasketService>();
        services.AddSingleton<IWishlistService, WishlistService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();

        #endregion

        #region Data logic

        // REDIS
        services.AddSingleton<IConnectionMultiplexer>(c =>
        {
            var redisConnectionString = configuration.GetConnectionString("Redis");
            var configurationOptions = ConfigurationOptions.Parse(redisConnectionString, true);
            return ConnectionMultiplexer.Connect(configurationOptions);
        });

        // SQL SERVER
        services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        #endregion
        
        return services;
        
    }
}