using MediatR;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductService _productService;
    
    public DeleteProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductById(request.Model.Id);
        
        if (product != null)
        {
            await _productService.DeleteProduct(product);
        }

        return true;
    }
}