using MediatR;
using ModaStore.API.Dto.Catalog;

namespace ModaStore.API.Application.Commands.Models;

public class AddCategoryCommand : IRequest<CategoryDto>
{
    public CategoryDto Model { get; set; }
}