using ModaStore.Domain.Interfaces;
using ModaStore.Domain.Models.Catalog;
using ModaStore.Infrastructure.Data;

namespace ModaStore.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly StoreContext _context;
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(StoreContext context, IGenericRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
    {
        _context = context;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IReadOnlyList<Category>> GetAllCategories()
    {
        var query = await _unitOfWork.Repository<Category>().ListAllAsync();
        return query;
    }

    public async Task InsertCategory(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        
        await _categoryRepository.AddAsync(category);
    }
}