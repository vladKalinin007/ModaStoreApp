using API.Models;
using Core.Models;

namespace API.Dto.Catalog;

public class CategoryDto : BaseApiEntityModel
{
    public string Name { get; set; }
    // public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public string PictureUrl { get; set; }
    
}