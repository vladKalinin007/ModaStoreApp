using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class CreateSeenProductsCommandHandler : IRequestHandler<CreateSeenProductsCommand, SeenProductsListDto>
{
    
    private readonly ISeenProductService _seenProductsService;
    
    public CreateSeenProductsCommandHandler(ISeenProductService seenProductsService)
    {
        _seenProductsService = seenProductsService;
    }
    
    public async Task<SeenProductsListDto> Handle(CreateSeenProductsCommand request, CancellationToken cancellationToken)
    {
        var seenProducts = request.SeenProductsDto.ToEntity();
        
        var createdSeenProducts = await _seenProductsService.CreateSeenProductsAsync(seenProducts);
        
        return createdSeenProducts.ToDto();
    }
}