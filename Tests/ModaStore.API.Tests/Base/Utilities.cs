// using ModaStore.Domain.Entities.Catalog;
// using ModaStore.Infrastructure.Data;
//
// namespace ModaStore.API.Tests.Base;
//
// public class Utilities
// {
//     public static void InitializeDbForTests(StoreContext context)
//     {
//         var products = new List<Product>
//         {
//             new Product
//             {
//                 Name = "Product 1",
//                 Description = "Description 1",
//                 Price = 10,
//                 PictureUrl = "https://via.placeholder.com/150",
//                 ProductTypeId = "1",
//                 ProductBrandId = "1"
//             },
//             new Product
//             {
//                 Name = "Product 2",
//                 Description = "Description 2",
//                 Price = 20,
//                 PictureUrl = "https://via.placeholder.com/150",
//                 ProductTypeId = "2",
//                 ProductBrandId = "2"
//             },
//             new Product
//             {
//                 Name = "Product 3",
//                 Description = "Description 3",
//                 Price = 30,
//                 PictureUrl = "https://via.placeholder.com/150",
//                 ProductTypeId = "3",
//                 ProductBrandId = "3"
//             }
//         };
//         
//         context.Products.AddRange(products);
//         
//         context.SaveChanges();
//     }
// }