using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Order;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Customer.Basket;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Application.Extensions.Mapper;

public static class AutoMapperConfigExtensions
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<Category, CategoryDto>();
                // cfg.CreateMap<Product, ProductDto>();
                // cfg.CreateMap<ProductDto, Product>();
                // cfg.CreateMap<Basket, BasketDto>();
                // cfg.CreateMap<Order, OrderDto>();
                // cfg.CreateMap<Picture, PictureDto>();
                
            });

            services.AddSingleton(configuration.CreateMapper());
        }
    }
}