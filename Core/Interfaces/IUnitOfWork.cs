using Core.Models;

namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    // IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BasicEntity;
    Task<int> Complete();
}