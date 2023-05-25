using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class BaseApiEntityModel 
{
    [Key]
    public string Id { get; set; }
}
