// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using ModaStore.Infrastructure.Data;
//
// namespace ModaStore.API.Tests.Base;
//
// public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
// {
//     protected override void ConfigureWebHost(IWebHostBuilder builder)
//     {
//         builder.ConfigureServices(services =>
//         {
//             services.AddDbContext<StoreContext>(options =>
//             {
//                 options.UseInMemoryDatabase("DefaultConnectionTest");
//             });
//             
//             var serviceProvider = services.BuildServiceProvider();
//             
//             using (var scope = serviceProvider.CreateScope())
//             {
//                 var scopedServices = scope.ServiceProvider;
//                 var storeContext = scopedServices.GetRequiredService<StoreContext>();
//                 var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();
//                 
//                 storeContext.Database.EnsureCreated();
//                 storeContext.Database.EnsureDeleted();
//                 
//                 try
//                 {
//                     Utilities.InitializeDbForTests(storeContext);
//                 }
//                 catch (Exception ex)
//                 {
//                     logger.LogError(ex, "An error occurred seeding the " +
//                                         "database with test messages. Error: {Message}", ex.Message);
//                 }
//             }
//         });
//     }
// }