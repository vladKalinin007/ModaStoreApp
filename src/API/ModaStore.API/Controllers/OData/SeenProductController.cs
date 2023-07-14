using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Application.Features.Catalog.Product.Queries.Models;

namespace ModaStore.API.Controllers.OData;

public class SeenProductController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public SeenProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _mediator.Send(new GetAllSeenProductsQuery(id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SeenProductsListDto seenProductsListDto)
    {
        var result = await _mediator.Send(new CreateSeenProductsCommand(seenProductsListDto));
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] SeenProductsListDto seenProductsListDto, string id)
    {
        var result = await _mediator.Send(new UpdateSeenProductsCommand(seenProductsListDto, id));
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteSeenProductsCommand(id));
        return Ok(result);
    }
    
}