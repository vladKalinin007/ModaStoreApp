using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Specifications;

namespace ModaStore.Domain.Interfaces.Data;

public interface IRepository<T> where T : BaseEntity
{
    T GetById(string id);
    Task<T> GetByIdAsync(string id);
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    IQueryable<T> GetAllWithSpec(ISpecification<T> spec);
    T Insert(T entity);
    Task<T> InsertAsync(T entity);
    T Update(T entity);
    Task<T> UpdateAsync(T entity);
    void Delete(T entity);
    Task<T> DeleteAsync(T entity);
}