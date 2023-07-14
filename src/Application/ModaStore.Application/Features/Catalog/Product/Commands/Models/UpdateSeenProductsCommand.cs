using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class UpdateSeenProductsCommand : IRequest<SeenProductsListDto>
{
    public UpdateSeenProductsCommand(SeenProductsListDto seenProductsListDto, string id)
    {
        SeenProductsListDto = seenProductsListDto;
        Id = id;
    }

    public SeenProductsListDto SeenProductsListDto { get; set; }
    public string Id { get; set; }
}