using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Entities.Identity;

namespace ModaStore.Domain.Entities.Order.OrderManagement;

public class Address : BaseEntity
{
    public Address()
    {
        
    }
    
    public Address(string firstName, string lastName, string street, string city, string state, string zipcode)
    {
        FirstName = firstName;
        LastName = lastName;
        Street = street;
        City = city;
        State = state;
        Zipcode = zipcode;
    }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string Zipcode { get; set; } = "";
    public AppUser AppUser { get; set; }
    public string AppUserId { get; set; }
}