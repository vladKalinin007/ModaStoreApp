using MediatR;
using ModaStore.Application.DTOs.Shipping;
using ModaStore.Application.Features.Order.OrderManagement.Queries.Models;

namespace ModaStore.Application.Features.Order.OrderManagement.Queries.Handlers;

public class GetDeliveryMethodsQueryHandler : IRequestHandler<GetDeliveryMethodsQuery, List<DeliveryMethodDto>>
{
    public Task<List<DeliveryMethodDto>> Handle(GetDeliveryMethodsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}