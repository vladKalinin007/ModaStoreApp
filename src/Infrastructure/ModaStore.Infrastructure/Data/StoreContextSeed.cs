// using System.Text.Json;
// using Microsoft.Extensions.Logging;
// using ModaStore.Domain.Entities.Catalog;
// using ModaStore.Domain.Entities.Order.OrderManagement;
//
//
// namespace ModaStore.Infrastructure.Data;
//
// public class StoreContextSeed
// {
//     public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
//     {
//         try
//         {
//             if (!context.ProductBrands.Any())
//             {
//                 var brandsData = File.ReadAllText("/Users/vladislavkalinin/Projects/API/src/Infrastructure/ModaStore.Infrastructure/Data/SeedData/brands.json");
//                 var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
//
//                 foreach (var item in brands)
//                 {
//                     context.ProductBrands.Add(item);
//                 }
//
//                 await context.SaveChangesAsync();
//                 
//             }
//
//             if (!context.ProductTypes.Any())
//             {
//                 var typesData = File.ReadAllText("/Users/vladislavkalinin/Projects/API/src/Infrastructure/ModaStore.Infrastructure/Data/SeedData/types.json");
//                 var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
//
//                 foreach (var item in types)
//                 {
//                     context.ProductTypes.Add(item);
//                 }
//
//                 await context.SaveChangesAsync();
//             }
//
//             if (!context.DeliveryMethods.Any())
//             {
//                 var dmData = File.ReadAllText("/Users/vladislavkalinin/Projects/API/src/Infrastructure/ModaStore.Infrastructure/Data/SeedData/delivery.json");
//                 var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
//
//                 foreach (var item in methods)
//                 {
//                     context.DeliveryMethods.Add(item);
//                 }
//
//                 await context.SaveChangesAsync();
//             }
//
//             if (!context.Categories.Any())
//             {
//                 var categoriesData = File.ReadAllText("/Users/vladislavkalinin/Projects/API/src/Infrastructure/ModaStore.Infrastructure/Data/SeedData/categories.json");
//                 var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
//                 
//                 foreach (var item in categories)
//                 {
//                     context.Categories.Add(item);
//                 }
//                 
//                 await context.SaveChangesAsync();
//             }
//             
//             if (!context.Products.Any())
//             {
//                 var productsData = File.ReadAllText("/Users/vladislavkalinin/Projects/API/src/Infrastructure/ModaStore.Infrastructure/Data/SeedData/products.json");
//                 var products = JsonSerializer.Deserialize<List<Product>>(productsData);
//
//                 foreach (var item in products)
//                 {
//                     context.Products.Add(item);
//                 }
//
//                 await context.SaveChangesAsync();
//             }
//         }
//         catch (Exception ex)
//         {
//             var logger = loggerFactory.CreateLogger<StoreContextSeed>();
//             logger.LogError(ex.Message);
//             Console.WriteLine(ex.Message);
//         }
//     }
// }