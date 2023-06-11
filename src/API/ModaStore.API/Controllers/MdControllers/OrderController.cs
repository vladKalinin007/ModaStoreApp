using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModaStore.API.Dto;
using ModaStore.API.Dto.Customers;
using ModaStore.API.Errors;
using ModaStore.API.Extensions;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models.OrderAggregate;
using ModaStore.Infrastructure.Data;

namespace ModaStore.API.Controllers.MdControllers;

// [Authorize]
public class OrderController : BaseApiController
{

    #region Fields

    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    private readonly StoreContext _context;

    #endregion

    #region Constructor

    public OrderController(IOrderService orderService, IMapper mapper, StoreContext context)
    {
        _orderService = orderService;
        _mapper = mapper;
        _context = context;
    }

    #endregion

    #region Methods

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal(); 
        
        var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);
        
        var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);
        
        if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
        
        return Ok(order);
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser()
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal();
        
        var orders = await _orderService.GetOrdersForUserAsync(email);
        
        return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        
        // var email = HttpContext.User.RetrieveEmailFromPrincipal();
        //
        //
        // return await _context.Orders.Where(o => o.BuyerEmail == email)
        //     .Include(u => u.DeliveryMethod)
        //     .Include(u => u.OrderItems).ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
    {
        var email = HttpContext.User.RetrieveEmailFromPrincipal();
        
        var order = await _orderService.GetOrderByIdAsync(id, email);
        
        if (order == null) return NotFound(new ApiResponse(404));
        
        return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
    }
    
    [HttpGet("deliveryMethods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        return Ok(await _orderService.GetDeliveryMethodsAsync());
    }

    #endregion
}