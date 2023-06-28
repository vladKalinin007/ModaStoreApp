using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class DeleteProductCommand : IRequest<bool>
{
    public ProductDto Model { get; set; }
}