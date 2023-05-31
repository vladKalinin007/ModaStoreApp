using ModaStore.Domain.Models;
using ModaStore.Domain.Specifications;

namespace ModaStore.Domain.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> getByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    void Add(T entity);
    Task<T> AddAsync(T entity); // CAN DELETE
    void Update(T entity);
    void Delete(T entity);
    
}