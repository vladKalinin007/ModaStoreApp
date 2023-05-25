using Core;

namespace Infrastructure.Data.temp;

public interface IUnitOfWorks
{
    IGenericRepositorys<TEntity> Repository<TEntity>() where TEntity : BasicEntity;
    Task<int> Complete();
}