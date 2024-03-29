using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class ProductAttributes : BaseEntity
{
    public List<string> Materials { get; set; }
    public List<string> Styles { get; set; }
    public List<string> Seasons { get; set; }
    public List<string> Patterns { get; set; }
}
