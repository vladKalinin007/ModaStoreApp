using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Picture : BaseEntity
{
    public string Url { get; set; }

    // Тип сущности, к которой относится картинка (Product, User, Category и т.д.)
    public string PictureType { get; set; }

    // Идентификатор сущности, к которой относится картинка
    public string PictureTypeId { get; set; }
    
    public ICollection<Product> Products { get; set; }
    public ICollection<ProductPicture> ProductPictures { get; set; }
}