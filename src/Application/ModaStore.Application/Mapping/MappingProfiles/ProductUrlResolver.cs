using AutoMapper;
using Microsoft.Extensions.Configuration;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Application.Mapping.MappingProfiles;

public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
{
    private readonly IConfiguration _config;
    
    public ProductUrlResolver(IConfiguration config)
    {
        _config = config;
    }
    
    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return "https://localhost:5001/" + source.PictureUrl;
        }
        
        return null;
    }
}