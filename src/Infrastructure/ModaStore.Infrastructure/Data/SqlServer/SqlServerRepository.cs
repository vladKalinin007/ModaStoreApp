using Microsoft.EntityFrameworkCore;
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

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().AsQueryable().ToListAsync();
    }

    public async Task<List<T>> GetAllWithSpecAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public T Insert(T entity)
    {
        var result = _context.Set<T>().Add(entity);
        _context.SaveChanges(); 
        return result.Entity;
    }

    public async Task<T> InsertAsync(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        _context.SaveChanges(); 
        return result.Entity;
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