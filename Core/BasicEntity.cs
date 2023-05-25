using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core;

public abstract partial class BasicEntity : ParentEntity
{
    protected BasicEntity()
    {
        UserFields = new List<UserField>();
    }
    
    [NotMapped]
    public IList<UserField> UserFields { get; set; }
}