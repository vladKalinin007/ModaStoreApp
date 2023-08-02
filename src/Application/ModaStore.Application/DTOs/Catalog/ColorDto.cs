using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class ColorDto : BaseDto
{
    public string Name { get; set; }
    public string ColorCode { get; set; }
}