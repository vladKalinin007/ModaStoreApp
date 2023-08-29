using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Domain.Interfaces.Customer.Management;

public interface IAddressService
{
    // get all addresses
    IQueryable<Address> GetAllAsync();
    
    // get address by id
    Task<Address> GetByIdAsync(string id);
    
    // create address
    Task<Address> CreateAsync(Address address);
    
    // update address
    Task UpdateAsync(Address address);
    
    // delete address
    Task DeleteAsync(Address address);
}