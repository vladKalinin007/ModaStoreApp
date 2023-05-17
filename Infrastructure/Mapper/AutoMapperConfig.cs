using AutoMapper;

namespace Infrastructure.Mapper;

public class AutoMapperConfig
{
    public static IMapper Mapper { get; private set; }
    
    public static void Init(MapperConfiguration config)
    {
        Mapper = config.CreateMapper();
    }
}