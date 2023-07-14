using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Queries.Models;

public class GetAllSeenProductsQuery : IRequest<SeenProductsListDto>
{
    public GetAllSeenProductsQuery(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}