using API.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.MControllers;

public class WishlistController : BaseApiController
{
    private readonly IMediator _mediator;

    public WishlistController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddWishlistItem(AddWishlistItemCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
}