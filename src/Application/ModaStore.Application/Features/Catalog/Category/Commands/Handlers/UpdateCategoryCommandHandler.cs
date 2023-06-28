using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Category.Commands.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly ICategoryService _categoryService;
    
    public UpdateCategoryCommandHandler(ICategoryService _categoryService)
    {
        this._categoryService = _categoryService;
    }
    
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetCategoryById(request.Model.Id);
        
        if (category != null)
        {
            category = request.Model.ToEntity();
            
            await _categoryService.UpdateCategory(category);
        }
        
        return category.ToDto();
        
    }
}