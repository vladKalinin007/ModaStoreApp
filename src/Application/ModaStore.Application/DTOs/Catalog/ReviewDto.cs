using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class ReviewDto : BaseDto
{
    public int Rating { get; set; }
    public string Comment { get; set; } 
    public string ProductId { get; set; }
}