using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Domain.Entities.Catalog;
using Swashbuckle.AspNetCore.Annotations;

// using NewCategory = ModaStore.Domain.Catalog.Category;

namespace ModaStore.API.Controllers.OData;

public class CategoryController : BaseODataController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var category = await _mediator.Send(new GetGenericQuery<CategoryDto, Category>(key));
        if (!category.Any()) return NotFound();

        return Ok(category.FirstOrDefault());
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<CategoryDto, Category>()));
    }
    
    [SwaggerOperation(summary: "Add new entity to Category", OperationId = "InsertCategory")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CategoryDto model)
    {
        model = await _mediator.Send(new CreateCategoryCommand() { Model = model });
        return Ok(model);
    }
    
    [SwaggerOperation(summary: "Update entity in Category", OperationId = "UpdateCategory")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Put([FromBody] CategoryDto model)
    {
        var category = await _mediator.Send(new GetGenericQuery<CategoryDto, Category>(model.Id));
        if (!category.Any()) return NotFound();
        
        model = await _mediator.Send(new UpdateCategoryCommand() { Model = model });
        return Ok(model);
    }
    
    // [SwaggerOperation(summary: "Update entity in Category (delta)", OperationId = "UpdateCategoryPatch")]
    // [HttpPatch]
    // [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // [ProducesResponseType((int)HttpStatusCode.NotFound)]
    // public async Task<IActionResult> Patch([FromBody] Delta<CategoryDto> model)
    // {
    //     var category = await _mediator.Send(new GetGenericQuery<CategoryDto, Category>(model.GetPropertyValue("Id").ToString()));
    //     if (!category.Any()) return NotFound();
    //     
    //     model = await _mediator.Send(new UpdateCategoryCommand() { Model = model });
    //     return Ok(model);
    // }
    
    [SwaggerOperation(summary: "Delete entity from Category", OperationId = "DeleteCategory")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete([FromBody] CategoryDto model)
    {
        var category = await _mediator.Send(new GetGenericQuery<CategoryDto, Category>(model.Id));
        if (!category.Any()) return NotFound();
        
        await _mediator.Send(new DeleteCategoryCommand() { Model = model });
        return Ok();
    }
}