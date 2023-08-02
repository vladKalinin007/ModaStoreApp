using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductReview : BaseEntity
{
    public int Rating { get; set; } // Свойство для хранения рейтинга (звездочек) от пользователя
    public string Comment { get; set; } // Опциональный комментарий пользователя к отзыву

    // Navigation properties
    public string UserId { get; set; } // Идентификатор пользователя, который оставил отзыв
    public AppUser User { get; set; } // Если у вас есть класс ApplicationUser для представления пользователей в системе

    public string ProductId { get; set; } // Идентификатор продукта, к которому относится отзыв
    public Product Product { get; set; }
}
