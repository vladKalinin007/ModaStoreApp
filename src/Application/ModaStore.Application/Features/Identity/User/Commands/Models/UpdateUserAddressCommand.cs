using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Identity.User.Commands.Models;

public class UpdateUserAddressCommand : IRequest<AddressDto>
{
    public CustomerDto Customer { get; set; }
    public AddressDto Address { get; set; }
}