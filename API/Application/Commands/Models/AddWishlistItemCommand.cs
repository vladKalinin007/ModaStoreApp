using API.Dto.Catalog;
using MediatR;

namespace API.Application.Commands.Models;


public class AddWishlistItemCommand : IRequest<WishlistItemDto>
{
    public WishlistItemDto Model { get; set; }
}
