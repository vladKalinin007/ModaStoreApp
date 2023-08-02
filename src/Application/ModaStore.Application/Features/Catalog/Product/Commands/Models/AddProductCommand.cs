using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Product.Commands.Models;

public class AddProductCommand : IRequest<ProductToPublishDto>
{
    public ProductToPublishDto Model { get; set; }
}