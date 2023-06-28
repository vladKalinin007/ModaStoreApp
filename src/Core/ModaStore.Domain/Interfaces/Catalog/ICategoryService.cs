using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Catalog;

public interface ICategoryService
{
    Task<IList<Category>> GetAllCategories();
    Task<Category> GetCategoryById(string categoryId);
    Task InsertCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(Category category);
}