using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Order.Review;

public class Review : BaseEntity
{
    public string UserId { get; set; }
    public string ProductId { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public int RatingId { get; set; }
    public Rating Rating { get; set; }
    
    // Дополнительные свойства и методы
}