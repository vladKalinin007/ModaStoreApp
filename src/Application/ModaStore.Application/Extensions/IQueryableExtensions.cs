using AutoMapper;
using AutoMapper.QueryableExtensions;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Mapping.Config;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Application.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TDestination> ToDto<TDestination>(this IQueryable source)
    {
        return source.ProjectTo<TDestination>(AutoMapperConfig.Mapper.ConfigurationProvider);
    }
    
    
}

