using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class UpdateProductCommand : IRequest<ProductDto>
{
    public ProductDto Model { get; set; }
}