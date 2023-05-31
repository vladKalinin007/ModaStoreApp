using MediatR;
using ModaStore.API.Dto.Catalog;

namespace ModaStore.API.Application.Commands.Models;


public class AddWishlistItemCommand : IRequest<WishlistItemDto>
{
    public WishlistItemDto Model { get; set; }
}
