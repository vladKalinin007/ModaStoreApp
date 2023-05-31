using System.ComponentModel.DataAnnotations;

namespace ModaStore.API.Models;

public class BaseApiEntityModel 
{
    [Key]
    public string Id { get; set; }
}
