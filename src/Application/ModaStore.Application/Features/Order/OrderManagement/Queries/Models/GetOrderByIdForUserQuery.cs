using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Models;

public class GetOrderByIdForUserQuery : IRequest<OrderToReturnDto>
{
    public string Id { get; set; }
    public string Email { get; set; }

    public GetOrderByIdForUserQuery(string id, string email)
    {
        Id = id;
        Email = email;
    }
}