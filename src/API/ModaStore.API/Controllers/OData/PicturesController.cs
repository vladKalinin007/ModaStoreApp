using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Catalog.Pictures.Queries.Models;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.API.Controllers.OData;

public class PicturesController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public PicturesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<PictureDto, Picture>()));
    }
    
    [HttpGet("{picType}")]
    public async Task<IActionResult> Get(string picType)
    {
        var picture = await _mediator.Send(new GetPicturesByPictureTypeQuery(picType)); 
        return Ok(picture);
    }
}