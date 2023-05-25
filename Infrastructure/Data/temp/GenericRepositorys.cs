using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.temp;

public class GenericRepositorys<T> : IGenericRepositorys<T> where T : BasicEntity
{
    private readonly StoreContext _context;

    public GenericRepositorys(StoreContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}