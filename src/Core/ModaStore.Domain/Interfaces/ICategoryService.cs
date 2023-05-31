using ModaStore.Domain.Models.Catalog;

namespace ModaStore.Domain.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetAllCategories();
    // Task<Category> GetCategoryById(string categoryId);
    Task InsertCategory(Category category);
    // Task UpdateCategory(Category category);
    // Task DeleteCategory(Category category);
}