using MediatR;

namespace ModaStore.Application.Features.Customer.Commands.Models;

public class DeleteWishlistCommand : IRequest<bool>
{
    public DeleteWishlistCommand(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}