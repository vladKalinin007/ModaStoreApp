using System.ComponentModel.DataAnnotations;
using ModaStore.Domain.Entities.Common;

namespace ModaStore.Application.DTOs.Identity;

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; }
    
    public string UserName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}", ErrorMessage = "Password must have 1 Uppercase, 1 lowercase, 1 number, 1 non alphanumeric and at least 8 characters")]
    public string Password { get; set; }
}