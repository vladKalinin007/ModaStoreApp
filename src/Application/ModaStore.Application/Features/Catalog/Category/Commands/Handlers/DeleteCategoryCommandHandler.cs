using MediatR;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Category.Commands.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryService _categoryService;
    
    public DeleteCategoryCommandHandler(ICategoryService _categoryService)
    {
        this._categoryService = _categoryService;
    }
    
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetCategoryById(request.Model.Id);

        if (category != null)
        {
            await _categoryService.DeleteCategory(category);
        }
        
        return true;
    }
}