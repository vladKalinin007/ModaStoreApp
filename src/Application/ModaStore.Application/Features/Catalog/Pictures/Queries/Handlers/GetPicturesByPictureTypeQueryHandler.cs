using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions;
using ModaStore.Application.Features.Catalog.Pictures.Queries.Models;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Pictures.Queries.Handlers;

public class GetPicturesByPictureTypeQueryHandler : IRequestHandler<GetPicturesByPictureTypeQuery, IQueryable<PictureDto>>
{
    private readonly IPictureService _pictureService;
    
    public GetPicturesByPictureTypeQueryHandler(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    
    public Task<IQueryable<PictureDto>> Handle(GetPicturesByPictureTypeQuery request, CancellationToken cancellationToken)
    {
        var pictures = _pictureService.GetPicturesByPictureTypeAsync(request.PictureType);
        
        return Task.FromResult(pictures.ToDto<PictureDto>());
    }
}