using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly IProductService _productService;
        
    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductById(request.Model.Id);
        
        product = request.Model.ToEntity(product);
        
        await _productService.UpdateProduct(product);
        
        return product.ToDto();
    }
}