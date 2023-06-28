using BasketEntity = ModaStore.Domain.Entities.Customer.Basket.Basket;

namespace ModaStore.Domain.Interfaces.Customer.Basket;

public interface IBasketService
{
    Task<BasketEntity> CreateBasketAsync(BasketEntity basket);
    Task<BasketEntity> GetBasketAsync(string basketId);
    Task<BasketEntity> UpdateBasketAsync(BasketEntity basket);
    Task<bool> DeleteBasketAsync(string basketId); 
}