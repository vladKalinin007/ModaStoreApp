using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Application.Features.Customer.Queries.Models;

namespace ModaStore.API.Controllers.OData;

public class WishlistController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public WishlistController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var wishlist = await _mediator.Send(new GetWishlistByIdQuery(id));
        
        if (wishlist == null)
        {
            var newWishlist = await _mediator.Send(new CreateWishlistCommand(new WishlistDto(), id));
            return Ok(newWishlist);
        }
        
        return Ok(wishlist);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WishlistDto wishlistDto)
    {
        var newWishlist = await _mediator.Send(new CreateWishlistCommand(wishlistDto));
        return Ok(newWishlist);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] WishlistDto wishlistDto)
    {
        var updatedWishlist = await _mediator.Send(new UpdateWishlistCommand(wishlistDto, id));
        return Ok(updatedWishlist);
    }
    
    // [HttpPatch("{key}")]
    // public async Task<IActionResult> Patch(string key, [FromBody] WishlistDto wishlist)
    // {
    //     var updatedWishlist = await _mediator.Send(new UpdateWishlistCommand(key, wishlist));
    //     return Ok(updatedWishlist);
    // }
    
    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key)
    {
        var deletedWishlist = await _mediator.Send(new DeleteWishlistCommand(key));
        return Ok(deletedWishlist);
    }
    
}