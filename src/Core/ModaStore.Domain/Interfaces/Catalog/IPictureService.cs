using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface IPictureService
{
    public IQueryable<Picture> GetPicturesByPictureTypeAsync(string pictureType);
}