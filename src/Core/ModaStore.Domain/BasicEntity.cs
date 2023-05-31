using System.ComponentModel.DataAnnotations.Schema;
using ModaStore.Domain.Common;

namespace ModaStore.Domain;

public abstract partial class BasicEntity : ParentEntity
{
    protected BasicEntity()
    {
        UserFields = new List<UserField>();
    }
    
    [NotMapped]
    public IList<UserField> UserFields { get; set; }
}