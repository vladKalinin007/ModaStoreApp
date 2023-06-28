using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Extensions;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;
using ModaStore.Application.Features.Order.OrderManagement.Commands.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ModaStore.API.Controllers.OData;

public class OrderController : BaseODataController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // Get order by id
    [SwaggerOperation(summary: "Get entity from Order by key", OperationId = "GetOrderById")]
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal();
        
        var order = await _mediator.Send(new GetOrderByIdForUserQuery(key, email));

        return Ok(order);
    }
    
    // Get all orders
    [SwaggerOperation(summary: "Get entities from Order", OperationId = "GetOrders")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal();
        var orders = await _mediator.Send(new GetOrdersForUserQuery(email));
        return Ok(orders);
        
    }
    
    [SwaggerOperation(summary: "Add new entity to Order", OperationId = "InsertOrder")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderDto model)
    {
        var order = await _mediator.Send(new CreateOrderCommand(model));
        return Ok(order);
    }
    
    
    [SwaggerOperation(summary: "Update entity in Order", OperationId = "UpdateOrder")]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] OrderDto model)
    {
        var order = await _mediator.Send(new UpdateOrderCommand(model));
        return Ok(order);
    }
    
    [SwaggerOperation(summary: "Delete entity from Order", OperationId = "DeleteOrder")]
    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key)
    {
        var order = await _mediator.Send(new DeleteOrderCommand());
        return Ok(order);
    }
    
    [HttpGet("deliveryMethods")]
    public async Task<IActionResult> GetDeliveryMethods()
    {
        var deliveryMethods = await _mediator.Send(new GetDeliveryMethodsQuery());
        return Ok(deliveryMethods);
    }
}