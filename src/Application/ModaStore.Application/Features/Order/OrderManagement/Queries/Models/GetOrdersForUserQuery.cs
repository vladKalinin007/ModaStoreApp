using MediatR;
using ModaStore.Application.DTOs.Order;
using ModaStore.Application.DTOs.Order.OrderManagement;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Models;

public class GetOrdersForUserQuery : IRequest<List<OrderToReturnDto>>
{
    
}