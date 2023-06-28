using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Data;

namespace ModaStore.Domain.Entities.Common;

public abstract class BaseEntity
{
    [Key]
    public string Id
    {
        get { return _id; }
        set
        {
            if (string.IsNullOrEmpty(value))
                _id = UniqueIdentifier.New;
            else
                _id = value;
        }
    }
    
    protected BaseEntity()
    {
        _id = UniqueIdentifier.New;
    }
    
    private string _id;
}