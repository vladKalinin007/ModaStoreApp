using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Customers;

public class CustomerDto : BaseDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string StreetAddress { get; set; }
    public string StreetAddress2 { get; set; }
    public string ZipPostalCode { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
}