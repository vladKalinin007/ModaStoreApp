using MediatR;
using ModaStore.Application.DTOs.Shipping;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Models;

public class GetDeliveryMethodsQuery : IRequest<List<DeliveryMethodDto>>
{
    
}