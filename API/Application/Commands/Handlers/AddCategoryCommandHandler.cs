using API.Application.Commands.Models;
using API.Dto.Catalog;
using Core.Interfaces;
using Core.Models.Catalog;
using MediatR;

namespace API.Application.Commands.Handlers;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
{
    private readonly ICategoryService _categoryService;

    public AddCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        // var category = request.Model.ToEntity(); // Проблема тут.
        var category = new Category
        {
            Name = request.Model.Name,
            DisplayOrder = request.Model.DisplayOrder,
            PictureUrl = request.Model.PictureUrl,
        };
        
        
        await _categoryService.InsertCategory(category);
        // return category.ToModel();
        return new CategoryDto
        {
            Name = category.Name,
            DisplayOrder = category.DisplayOrder,
            PictureUrl = category.PictureUrl,
        };
    }
}