using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Order;

public class AddressDto : BaseDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string ZipCode { get; set; }
}