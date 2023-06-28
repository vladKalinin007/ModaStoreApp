using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Review;

public class Rating : BaseEntity
{
    public int Stars { get; set; }
    public string Description { get; set; }

}

// Дополнительные свойства и методы
