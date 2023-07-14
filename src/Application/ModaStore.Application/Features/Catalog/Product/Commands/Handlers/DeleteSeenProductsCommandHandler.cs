using MediatR;
using ModaStore.Application.Features.Catalog.Product.Commands.Models;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Handlers;

public class DeleteSeenProductsCommandHandler : IRequestHandler<DeleteSeenProductsCommand, bool>
{
    private readonly ISeenProductService _seenProductService;
    
    public DeleteSeenProductsCommandHandler(ISeenProductService seenProductService)
    {
        _seenProductService = seenProductService;
    }
    
    public async Task<bool> Handle(DeleteSeenProductsCommand request, CancellationToken cancellationToken)
    {
        return await _seenProductService.RemoveSeenProductsAsync(request.Id);
    }
}