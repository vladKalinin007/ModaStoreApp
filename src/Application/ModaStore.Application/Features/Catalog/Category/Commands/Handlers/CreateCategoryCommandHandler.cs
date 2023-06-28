using MediatR;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Catalog.Category.Commands.Models;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Interfaces.Catalog;

namespace ModaStore.Application.Features.Catalog.Category.Commands.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryService _categoryService;
    
    public CreateCategoryCommandHandler(ICategoryService _categoryService)
    {
        this._categoryService = _categoryService;
    }
    
    public Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Model.ToEntity();
        
        _categoryService.InsertCategory(category);

        return Task.FromResult(category.ToDto());
    }
}