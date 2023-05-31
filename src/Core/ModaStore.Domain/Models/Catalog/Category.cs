using System.ComponentModel.DataAnnotations;

namespace ModaStore.Domain.Models.Catalog;

public class Category : BaseEntity
{

    [Required]
    public string Name { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public string PictureUrl { get; set; }
         
}