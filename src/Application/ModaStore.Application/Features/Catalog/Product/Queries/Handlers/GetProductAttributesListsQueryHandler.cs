using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Queries.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Queries.Handlers;

public class GetProductAttributesListsQueryHandler : IRequestHandler<GetProductAttributesListsQuery, ProductAttributesDto>
{
    private readonly IProductService _productService;
    
    public GetProductAttributesListsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<ProductAttributesDto> Handle(GetProductAttributesListsQuery request, CancellationToken cancellationToken)
    {
        var attributes = await _productService.GetAttributes();
        
        return attributes.ToDto();
    }
}