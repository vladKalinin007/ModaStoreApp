using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class SeenProductsList : BaseEntity
{
    public SeenProductsList()
    {
        SeenProducts = new List<SeenProduct>();
    }
    
    public List<SeenProduct> SeenProducts { get; set; }
}

