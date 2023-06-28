using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Category : BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public string PictureUrl { get; set; }
    
    public bool ShowOnHomePage { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
         
}