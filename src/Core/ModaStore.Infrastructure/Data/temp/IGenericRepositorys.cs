using ModaStore.Domain;

namespace ModaStore.Infrastructure.Data.temp;

public interface IGenericRepositorys<T> where T : BasicEntity
{
     Task<IReadOnlyList<T>> ListAllAsync();
}