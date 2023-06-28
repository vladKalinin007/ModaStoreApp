using AutoMapper;
using AutoMapper.QueryableExtensions;
using ModaStore.Application.Mapping.Config;

namespace ModaStore.Application.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TDestination> ToDto<TDestination>(this IQueryable source)
    {
        return source.ProjectTo<TDestination>(AutoMapperConfig.Mapper.ConfigurationProvider);
    }
}

