using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Order;

public class AddressDto : BaseDto
{
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Street { get; set; }
    
    public string City { get; set; }
   
    public string State { get; set; }
   
    public string ZipCode { get; set; }
}