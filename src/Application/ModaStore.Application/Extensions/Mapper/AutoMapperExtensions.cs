using ModaStore.Application.Mapping.Config;

namespace ModaStore.Application.Extensions.Mapper;

public static class AutoMapperExtensions
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source)
    {
        return AutoMapperConfig.Mapper.Map<TSource, TDestination>(source);
    }
    
    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    {
        return AutoMapperConfig.Mapper.Map(source, destination);
    }
}