using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Interfaces.Common;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    // IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BasicEntity;
    Task<int> Complete();
}