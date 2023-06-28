using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Catalog.Category.Commands.Models;

public class UpdateCategoryCommand : IRequest<CategoryDto>
{
    public CategoryDto Model { get; set; }
}