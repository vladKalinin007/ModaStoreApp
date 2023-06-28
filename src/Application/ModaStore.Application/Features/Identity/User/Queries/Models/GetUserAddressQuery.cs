using MediatR;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Order;

namespace ModaStore.Application.Features.Identity.User.Queries.Models;

public class GetUserAddressQuery : IRequest<AddressDto>
{
    public AddressDto Model { get; set; }
}