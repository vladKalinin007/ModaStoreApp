using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.ProductType.Queries.Models;

public class GetTypesByCategoryQuery : IRequest<IQueryable<ProductTypeDto>>
{
    public string Category { get; set; }
}