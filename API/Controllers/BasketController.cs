using API.Dto;
using API.Dto.Customers;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BasketController : BaseApiController
{
    #region Fields
    
    private readonly IBasketRepository _basketRepository;
    private readonly IMapper _mapper;

    #endregion

    #region Constructor

    public BasketController(IBasketRepository basketRepository, IMapper mapper) 
    {
        _basketRepository = basketRepository;
        _mapper = mapper;
    }

    #endregion
    

    #region Methods
    
    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
        var basket = await _basketRepository.GetBasketAsync(id);
        return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
    {
        var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
        var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);
        return Ok(updatedBasket);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
        await _basketRepository.DeleteBasketAsync(id);
    }
    
    #endregion
}
