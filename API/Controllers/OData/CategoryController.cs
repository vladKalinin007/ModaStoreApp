using API.Application.Queries.Models.Common;
using API.Dto.Catalog;
using Core.Models.Catalog;
// using NewCategory = Core.Catalog.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OData;

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