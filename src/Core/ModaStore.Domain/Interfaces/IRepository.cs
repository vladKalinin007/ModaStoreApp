using ModaStore.Domain.Models;

namespace ModaStore.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    T Insert(T entity);
    Task<T> InsertAsync(T entity);
}