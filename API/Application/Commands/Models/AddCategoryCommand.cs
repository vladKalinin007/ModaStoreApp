using API.Dto.Catalog;
using MediatR;

namespace API.Application.Commands.Models;

public class AddCategoryCommand : IRequest<CategoryDto>
{
    public CategoryDto Model { get; set; }
}