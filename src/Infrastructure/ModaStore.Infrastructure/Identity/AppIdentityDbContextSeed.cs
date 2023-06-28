using Microsoft.AspNetCore.Identity;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Entities.Order.OrderManagement;

namespace ModaStore.Infrastructure.Identity;

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
                    Zipcode = "90210"
                }
            };
            
            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}