using Core.Models;

namespace API.Dto.Catalog;

public class CategoryDto : BaseEntity
{
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public string PictureUrl { get; set; }
    
}