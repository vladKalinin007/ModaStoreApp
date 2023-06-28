using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Specifications;

namespace ModaStore.Domain.Interfaces.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> getByIdAsync(string id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    void Add(T entity);
    Task<T> AddAsync(T entity); // CAN DELETE
    void Update(T entity);
    Task<T> UpdateAsync(T entity); 
    void Delete(T entity);
}