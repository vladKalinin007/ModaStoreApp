using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Application.Features.Identity.User.Queries.Models;


namespace ModaStore.API.Controllers.OData;

public class UserController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetUserQuery()));
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserDto model)
    {
        return Ok(await _mediator.Send(new UpdateUserCommand() { Model = model}));
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(string key)
    {
        await _mediator.Send(new DeleteUserCommand() { Email = key });
        return Ok();
    }
    
    [HttpGet("Address")]
    public async Task<IActionResult> GetAddress()
    {
        return Ok(await _mediator.Send(new GetUserAddressQuery()));
    }
    
    [HttpPut("Address")]
    public async Task<IActionResult> UpdateAddress([FromBody] AddressDto address)
    {
        return Ok(await _mediator.Send(new UpdateUserAddressCommand() { Address = address }));
    }
    
    [HttpGet("Reviews")]
    public async Task<IActionResult> GetReviews()
    {
        return Ok(await _mediator.Send(new GetUserReviewsQuery()));
    }
    
    [HttpPost("Reviews")]
    public async Task<IActionResult> AddReview([FromBody] ReviewDto review)
    {
        return Ok(await _mediator.Send(new AddReviewCommand(review)));
    }
    
    [HttpGet("Emailexists")]
    public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
    {
        return Ok(await _mediator.Send(new CheckEmailExistsQuery(email)));
    }
}