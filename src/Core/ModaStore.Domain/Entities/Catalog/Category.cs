using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Category : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public string PictureUrl { get; set; }
    
    public bool ShowOnHomePage { get; set; }

    public ICollection<Product> Products { get; set; }
    
    public ICollection<CategoryProductType> CategoryProductTypes { get; set; }

}