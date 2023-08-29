using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Order.OrderManagement;
using ModaStore.Domain.Interfaces.Customer.Management;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Customer.CustomerManagement;

public class AddressService : IAddressService
{
    private readonly IRepository<Address> _addressRepository;
    
    public AddressService(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }


    public IQueryable<Address> GetAllAsync()
    {
        return _addressRepository.GetAllQueryAsync();
    }
    

    public Task<Address> GetByIdAsync(string id)
    {
        return GetAllAsync().FirstOrDefaultAsync(x => x.AppUserId == id);
    }

    public Task<Address> CreateAsync(Address address)
    {
        return _addressRepository.InsertAsync(address);
    }

    public Task UpdateAsync(Address address)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Address address)
    {
        throw new NotImplementedException();
    }
}