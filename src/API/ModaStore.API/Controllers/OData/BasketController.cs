
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Features.Customer.Commands.Models;
using ModaStore.Application.Features.Customer.Queries.Models;

namespace ModaStore.API.Controllers.OData;

public class BasketController : BaseODataController
{
    private readonly IMediator _mediator;
    
    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var basket = await _mediator.Send(new GetBasketByIdQuery(id));

        if (basket == null)
        {
            var newBasket = await _mediator.Send(new CreateBasketCommand(new BasketDto(), id));
            return Ok(newBasket);
        }

        return Ok(basket);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BasketDto model, string id)
    {
        model = await _mediator.Send(new CreateBasketCommand(model, id));
        return Ok(model);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] BasketDto basketDto, string id)
    {
        basketDto = await _mediator.Send(new UpdateBasketCommand(basketDto, id));
        return Ok(basketDto);
    }
    
    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key)
    {
        await _mediator.Send(new DeleteBasketCommand(key));
        return Ok();
    }


}