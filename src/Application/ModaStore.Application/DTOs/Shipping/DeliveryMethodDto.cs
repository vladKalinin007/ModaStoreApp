using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Shipping;

public class DeliveryMethodDto : BaseDto
{
    public string ShortName { get; set; }
    public string DeliveryTime { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}