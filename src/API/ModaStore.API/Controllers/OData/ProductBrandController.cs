using MediatR;
using Microsoft.AspNetCore.Mvc;

using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Domain.Entities.Catalog;


namespace ModaStore.API.Controllers.OData;

public class ProductBrandController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public ProductBrandController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductBrandDto, ProductBrand>()));
    }
    
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductBrandDto, ProductBrand>(key)));
    }
}