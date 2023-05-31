using ModaStore.Domain.Models;

namespace ModaStore.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    // IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BasicEntity;
    Task<int> Complete();
}