using System.ComponentModel.DataAnnotations;

namespace ModaStore.Domain.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}