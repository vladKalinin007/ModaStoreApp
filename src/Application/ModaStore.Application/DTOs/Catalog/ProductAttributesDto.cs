using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class ProductAttributesDto : BaseDto
{
    public List<string> Materials { get; set; }
    public List<string> Styles { get; set; }
    public List<string> Seasons { get; set; }
    public List<string> Patterns { get; set; }
}