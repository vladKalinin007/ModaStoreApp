using Core.Models;

namespace Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    T Insert(T entity);
    Task<T> InsertAsync(T entity);
}