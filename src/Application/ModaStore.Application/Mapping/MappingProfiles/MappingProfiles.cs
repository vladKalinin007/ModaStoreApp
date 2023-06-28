using AutoMapper;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Application.Mapping.MappingProfiles;

public class ApplicationMappingProfiles : Profile
{
    public ApplicationMappingProfiles()
    {
        CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
        CreateMap<ProductType, ProductTypeDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
        // .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }
    
}