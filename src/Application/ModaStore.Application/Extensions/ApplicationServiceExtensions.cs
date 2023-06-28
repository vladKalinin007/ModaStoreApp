using Microsoft.Extensions.DependencyInjection;
using ModaStore.Application.Extensions.Mapper;

namespace ModaStore.Application.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapperConfiguration();
        services.AddSqrsServices();

        return services;
    }
}