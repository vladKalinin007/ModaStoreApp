using AutoMapper;
using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDto>
{
   private readonly IProductService _productService;
   private readonly IMapper _mapper;

   public AddProductCommandHandler(IProductService productService, IMapper mapper)
   {
       _productService = productService;
       _mapper = mapper;
   }

    public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Model.ToEntity();
        
        await _productService.InsertProduct(product);

        return product.ToDto();
        
    }
}
