using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace ModaStore.API.Controllers.OData;

public class ProductController : BaseODataController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // works with OData
    [HttpGet]
    public async Task<ActionResult<Pagination<ProductDto>>> Get([FromQuery] ProductSpecParams? productParams)
    {
        var data = await _mediator.Send(new GetGenericQuery<ProductDto, Product>(productParams: productParams));
        return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, data.Count(), data));
    }

    // works with OData
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _mediator.Send(new GetGenericQuery<ProductDto, Product>(Id: key)));
    }
    
    // works with OData
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductToPublishDto model)
    {
        model = await _mediator.Send(new AddProductCommand() { Model = model });
        return Ok(model);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProductDto model)
    {
        model = await _mediator.Send(new UpdateProductCommand() { Model = model });
        return Ok(model);
    }
    
    [SwaggerOperation(summary: "Deleting an entity from Product", OperationId = "DeleteProduct")]
    [HttpDelete]
    public async Task<IActionResult> Delete(string key)
    {
        var product = await _mediator.Send(new GetGenericQuery<ProductDto, Product>(key));
        
        if (!product.Any()) return NotFound();
        
        await _mediator.Send(new DeleteProductCommand() { Model = product.FirstOrDefault() });
        
        return Ok();
        
    }
}