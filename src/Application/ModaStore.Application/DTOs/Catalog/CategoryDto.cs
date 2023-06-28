using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class CategoryDto : BaseDto
{
    public string Name { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public string PictureUrl { get; set; }
}