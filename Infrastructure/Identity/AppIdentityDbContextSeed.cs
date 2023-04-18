using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppIdentityDbContextSeed
{
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                DisplayName = "Vlad", 
                Email = "vlad@test.com",
                UserName = "vlad@test.com",
                Address = new Address
                {
                    FirstName = "Vlad",
                    LastName = "Kalinin",
                    Street = "10 The Street",
                    City = "New York",
                    State = "NY",
                    ZipCode = "90210"
                }
            };
            
            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}