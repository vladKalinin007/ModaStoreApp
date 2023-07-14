using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class UpdateSeenProductsCommandHandler : IRequestHandler<UpdateSeenProductsCommand, SeenProductsListDto>
{
    private readonly ISeenProductService _seenProductsService;
    
    public UpdateSeenProductsCommandHandler(ISeenProductService seenProductsService)
    {
        _seenProductsService = seenProductsService;
    }
    
    public async Task<SeenProductsListDto> Handle(UpdateSeenProductsCommand request, CancellationToken cancellationToken)
    {
        var seenProducts = request.SeenProductsListDto.ToEntity();
        seenProducts.Id = request.Id;
        
        await _seenProductsService.UpdateSeenProductsAsync(seenProducts.Id, seenProducts);
        
        return seenProducts.ToDto();
    }
}