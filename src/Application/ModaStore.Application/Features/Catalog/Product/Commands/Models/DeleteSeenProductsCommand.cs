using MediatR;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class DeleteSeenProductsCommand : IRequest<bool>
{
    public DeleteSeenProductsCommand(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}