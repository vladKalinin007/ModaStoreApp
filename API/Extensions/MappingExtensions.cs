using API.Dto.Catalog;
using Core.Models.Catalog;
using Infrastructure.Mapper;

namespace API.Extensions;

public static class MappingExtensions
{
    #region Category

    public static CategoryDto ToModel(this Category entity)
    {
        return entity.MapTo<Category, CategoryDto>();
    }
    
    public static Category ToEntity(this CategoryDto model)
    {
        return model.MapTo<CategoryDto, Category>();
    }
    
    public static Category ToEntity(this CategoryDto model, Category destination)
    {
        return model.MapTo(destination);
    }
    
    #endregion
}