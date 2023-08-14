using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog;

public class PictureService : IPictureService
{
    private readonly IRepository<Picture> _pictureRepository;
    
    public PictureService(IRepository<Picture> pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }
    
    public IQueryable<Picture> GetPicturesByPictureTypeAsync(string pictureType)
    {
        return _pictureRepository.GetAllQueryAsync()
            .Where(x => x.PictureType == pictureType);
    }

}