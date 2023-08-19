using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Catalog.ProductType.Queries.Models;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.API.Controllers.OData;

public class ProductTypeController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public ProductTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetGenericQuery<ProductTypeDto, ProductType>());
        
        return Ok(result.ToArray());
    }
    
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductTypeDto, ProductType>(key)));
    }
    
    [HttpGet("Category")]
    public async Task<IActionResult> GetByCategory(string key)
    {
        var result = await _mediator.Send(new GetTypesByCategoryQuery() { Category = key });
        
        return Ok(result);
    }
    
    // public async Task<IActionResult> Post([FromBody] ProductTypeDto model)
    // {
    //     model = await _mediator.Send(new AddProductTypeCommand() { Model = model });
    //     return Ok(model);
    // }
    //
    // public async Task<IActionResult> Put([FromBody] ProductTypeDto model)
    // {
    //     model = await _mediator.Send(new UpdateProductTypeCommand() { Model = model });
    //     return Ok(model);
    // }
    //
    // public async Task<IActionResult> Delete(string key)
    // {
    //     await _mediator.Send(new DeleteProductTypeCommand() { Key = key });
    //     return Ok();
    // }
}