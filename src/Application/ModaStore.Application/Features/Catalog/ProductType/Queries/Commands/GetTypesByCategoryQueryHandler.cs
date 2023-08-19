using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions;
using ModaStore.Application.Features.Catalog.ProductType.Queries.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.ProductType.Queries.Commands;

public class GetTypesByCategoryQueryHandler : IRequestHandler<GetTypesByCategoryQuery, IQueryable<ProductTypeDto>>
{
    private readonly IProductTypeService _productTypeService;
    
    public GetTypesByCategoryQueryHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }
    
    public async Task<IQueryable<ProductTypeDto>> Handle(GetTypesByCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = _productTypeService.GetProductTypesByCategory(request.Category);

        return result.ToDto<ProductTypeDto>();
    }
}