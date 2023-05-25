using API.Models;
using Core.Models;

namespace API.Dto.Catalog;

public class ProductDto : BaseApiEntityModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public string ProductType { get; set; }
    public string ProductBrand { get; set; }
}