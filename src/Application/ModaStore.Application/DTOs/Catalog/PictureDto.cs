using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Catalog;

public class PictureDto : BaseDto
{
    public string? Url { get; set; }
    public string? PictureType { get; set; }
    public string? PictureTypeId { get; set; }
}