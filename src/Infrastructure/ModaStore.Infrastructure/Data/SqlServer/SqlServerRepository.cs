using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Specifications;

namespace ModaStore.Infrastructure.Data.SqlServer;

public class SqlServerRepository<T>: IRepository<T> where T: BaseEntity
{
    private readonly StoreContext _context;

    public SqlServerRepository(StoreContext context)
    {
        _context = context;
    }
    
    public T GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public IQueryable<T> GetAllQueryAsync()
    {
        return _context.Set<T>().AsQueryable();
    }

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().AsQueryable().ToListAsync();
    }

    public async Task<List<T>> GetAllWithSpecAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
    
    public IQueryable<T> GetAllWithSpec(ISpecification<T> spec)
    {
        return ApplySpecification(spec);
    }

    public T Insert(T entity)
    {
        var result = _context.Set<T>().Add(entity);
        _context.SaveChanges(); 
        return result.Entity;
    }

    public async Task<T> InsertAsync(T entity)
    {
        if (entity is Product product)
        {
            
            // var results = await _context.Set<T>().AddAsync(product as T);
            _context.Set<Product>().Add(product);
            await AddForeignKeysAsync(product);
            await AddRelatedProperties(product);
            await _context.SaveChangesAsync();
            return product as T;
            // return results.Entity;
        }
        
        
        var result = await _context.Set<T>().AddAsync(entity);
        _context.SaveChanges(); 
        return result.Entity;
    }
    
    private async Task AddForeignKeysAsync(Product product)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == product.Category.Name);
        if (category != null)
        {
            product.CategoryId = category.Id;
            _context.Entry(product.Category).State = EntityState.Unchanged; // не вставлять категорию в базу данных
        }

        var productBrand = await _context.ProductBrands.FirstOrDefaultAsync(b => b.Name == product.ProductBrand.Name);
        if (productBrand != null)
        {
            product.ProductBrandId = productBrand.Id;
            _context.Entry(product.ProductBrand).State = EntityState.Unchanged; // не вставлять бренд в базу данных
        }

        var productType = await _context.ProductTypes.FirstOrDefaultAsync(t => t.Name == product.ProductType.Name);
        if (productType != null)
        {
            product.ProductTypeId = productType.Id;
            _context.Entry(product.ProductType).State = EntityState.Unchanged; // не вставлять тип в базу данных
        }
    }

    private async Task AddRelatedProperties(Product product)
    {
        foreach (var color in product.Colors)
        {
            var existingColor = await _context.Colors.FirstOrDefaultAsync(c => c.Name == color.Name);
            if (existingColor != null)
            {
                color.Id = existingColor.Id;
                _context.Entry(existingColor).State = EntityState.Detached; // Отсоединяем сущность
                _context.Entry(color).State = EntityState.Modified; // Помечаем существующую сущность как измененную
            }
        }
    
        foreach (var size in product.Sizes)
        {
            var existingSize = await _context.Sizes.FirstOrDefaultAsync(s => s.Name == size.Name);
            if (existingSize != null)
            {
                size.Id = existingSize.Id;
                _context.Entry(existingSize).State = EntityState.Detached; // Отсоединяем сущность
                _context.Entry(size).State = EntityState.Modified; // Помечаем существующую сущность как измененную
            }
        }
    }



    public T Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}