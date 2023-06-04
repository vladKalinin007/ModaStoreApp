using ModaStore.Domain;

namespace ModaStore.Infrastructure.Data.temp;

public interface IUnitOfWorks
{
    IGenericRepositorys<TEntity> Repository<TEntity>() where TEntity : BasicEntity;
    Task<int> Complete();
}