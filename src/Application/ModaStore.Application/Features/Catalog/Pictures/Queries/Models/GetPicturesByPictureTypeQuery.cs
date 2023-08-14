using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Pictures.Queries.Models;

public class GetPicturesByPictureTypeQuery : IRequest<IQueryable<PictureDto>>
{
    public GetPicturesByPictureTypeQuery(string pictureType)
    {
        PictureType = pictureType;
    }
    
    public string PictureType { get; set; }
}