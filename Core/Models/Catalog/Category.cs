using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Localization;

namespace Core.Models.Catalog;

public class Category : BaseEntity
{

    [Required]
    public string Name { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public string PictureUrl { get; set; }
         
}