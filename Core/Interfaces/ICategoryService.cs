using System.Collections;
using Core.Models;
using Core.Models.Catalog;

namespace Core.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetAllCategories();
    // Task<Category> GetCategoryById(string categoryId);
    Task InsertCategory(Category category);
    // Task UpdateCategory(Category category);
    // Task DeleteCategory(Category category);
}