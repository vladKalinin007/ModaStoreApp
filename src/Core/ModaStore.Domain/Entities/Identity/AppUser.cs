using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ModaStore.Domain.Entities.Content;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public Address Address { get; set; }
    public ICollection<Comment> Comments { get; set; }
}