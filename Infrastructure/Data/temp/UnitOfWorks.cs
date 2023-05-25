using System.Collections;
using Core;
using Core.Interfaces;

namespace Infrastructure.Data.temp;

// public class UnitOfWorks : IUnitOfWorks
// {
//     private readonly StoreContext _context;
//     
//     private Hashtable _repositories;
//
//     public UnitOfWorks(StoreContext context)
//     {
//         _context = context;
//     }
//     
//     public void Dispose()
//     {
//         _context.Dispose();
//     }
//     
//     public IGenericRepositorys<TEntity> Repository<TEntity>() where TEntity : BasicEntity
//   
//     {
//         if (_repositories == null) _repositories = new Hashtable();
//
//         var type = typeof(TEntity).Name;
//
//         if (!_repositories.ContainsKey(type))
//         {
//             var repositoryType = typeof(GenericRepository<>);
//             var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
//
//             _repositories.Add(type, repositoryInstance);
//         }
//
//         return (IGenericRepositorys<TEntity>)_repositories[type];
//     }
//
//     public async Task<int> Complete()
//     {
//         return await _context.SaveChangesAsync();
//     }
// }

public class UnitOfWorks : IUnitOfWorks
{
    private readonly StoreContext _context;
    private Hashtable _repositories;

    public UnitOfWorks(StoreContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public IGenericRepositorys<TEntity> Repository<TEntity>() where TEntity : BasicEntity
    {
        var entityType = typeof(TEntity);

        if (!_repositories.ContainsKey(entityType))
        {
            var repositoryType = typeof(GenericRepositorys<>).MakeGenericType(entityType);
            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);

            _repositories.Add(entityType, repositoryInstance);
        }

        return (IGenericRepositorys<TEntity>)_repositories[entityType];
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
}
