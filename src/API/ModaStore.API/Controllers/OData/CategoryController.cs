using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Application.Queries.Models.Common;
using ModaStore.API.Dto.Catalog;
using ModaStore.Domain.Models.Catalog;

// using NewCategory = ModaStore.Domain.Catalog.Category;

namespace ModaStore.API.Controllers.OData;

public class CategoryController : BaseODataController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetGenericQuery<CategoryDto, Category>()));
    }
}