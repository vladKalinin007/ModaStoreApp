using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Queries.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Queries.Handlers;

public class GetAllSeenProductsQueryHandler : IRequestHandler<GetAllSeenProductsQuery, SeenProductsListDto>
{
    
    private readonly ISeenProductService _seenProductsService;
    
    public GetAllSeenProductsQueryHandler(ISeenProductService seenProductsService)
    {
        _seenProductsService = seenProductsService;
    }
    
    public async Task<SeenProductsListDto> Handle(GetAllSeenProductsQuery request, CancellationToken cancellationToken)
    {
        var seenProducts = await _seenProductsService.GetSeenProductsAsync(request.Id);
        return seenProducts.ToDto();
    }
}