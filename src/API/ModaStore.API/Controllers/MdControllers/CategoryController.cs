using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Application.Commands.Models;
using ModaStore.API.Application.Queries.Models.Common;
using ModaStore.API.Dto.Catalog;
using Swashbuckle.AspNetCore.Annotations;

namespace ModaStore.API.Controllers.MdControllers;

public class CategoryController : BaseApiController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [SwaggerOperation(summary: "Get all Categories", OperationId = "GetAllCategories")]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> Get()
    {
        return Ok(await _mediator.Send(new GetCategoryQuery()));
        // return Ok(await _mediator.Send(new GetGenericQuery<CategoryDto, Category>()));
        
    }

    [SwaggerOperation(summary: "Add new entity to Category", OperationId = "InsertCategory")]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDto model)
    {
        model = await _mediator.Send(new AddCategoryCommand() { Model = model });
        return Ok(model);
    }

}