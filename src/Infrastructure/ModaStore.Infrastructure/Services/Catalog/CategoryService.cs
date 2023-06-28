using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Catalog;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;
    
    public CategoryService(IRepository<Category> _categoryRepository)
    {
        this._categoryRepository = _categoryRepository;
    }
    
    
    public async Task<IList<Category>> GetAllCategories()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public Task<Category> GetCategoryById(string categoryId)
    {
        var category = _categoryRepository.GetById(categoryId);
        return Task.FromResult(category);
    }

    public Task InsertCategory(Category category)
    {
        return _categoryRepository.InsertAsync(category);
    }

    public Task UpdateCategory(Category category)
    {
        return _categoryRepository.UpdateAsync(category);
    }

    public Task DeleteCategory(Category category)
    {
        return _categoryRepository.DeleteAsync(category);
    }
}