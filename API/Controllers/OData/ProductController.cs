using API.Application.Queries.Models.Common;
using API.Dto;
using API.Dto.Catalog;
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OData;

public class ProductController : BaseODataController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductDto, Product>()));
    }
    
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(int key)
    {
        return Ok(await _mediator.Send(new GetQueryById<ProductDto, Product>(key)));
    }
    
    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductBrandDto, ProductBrand>()));
    }
    
    [HttpGet("types")]
    public async Task<IActionResult> GetTypes()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductTypeDto, ProductType>()));
    }
}