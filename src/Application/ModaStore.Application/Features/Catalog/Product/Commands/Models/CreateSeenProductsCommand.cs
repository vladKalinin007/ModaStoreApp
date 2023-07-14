using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class CreateSeenProductsCommand : IRequest<SeenProductsListDto>
{
    public CreateSeenProductsCommand(SeenProductsListDto seenProductsDto)
    {
        SeenProductsDto = seenProductsDto;
    }
    
    public SeenProductsListDto SeenProductsDto { get; set; }
}