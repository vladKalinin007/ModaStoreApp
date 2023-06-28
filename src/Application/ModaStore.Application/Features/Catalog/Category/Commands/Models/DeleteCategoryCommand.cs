using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Category.Commands.Models;

public class DeleteCategoryCommand : IRequest<bool>
{
    public CategoryDto Model { get; set; }
}