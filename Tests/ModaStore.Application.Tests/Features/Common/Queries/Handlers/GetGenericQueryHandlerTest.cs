// using AutoMapper;
// using ModaStore.Application.DTOs.Catalog;
// using ModaStore.Application.Features.Common.Queries.Handlers;
// using ModaStore.Application.Features.Common.Queries.Models;
// using ModaStore.Domain.Entities.Catalog;
// using ModaStore.Domain.Interfaces.Data;
// using ModaStore.Infrastructure.Data;
// using Moq;
// using Shouldly;
//
// namespace ModaStore.Application.Tests.Features.Common.Queries.Handlers
// {
//     public class GetGenericQueryHandlerTests
//     {
//         private readonly Mock<StoreContext> _dbContextMock;
//         private readonly Mock<IRepository<Product>> _productRepositoryMock;
//         private readonly IMapper _mapper;
//
//         public GetGenericQueryHandlerTests()
//         {
//             _dbContextMock = new Mock<StoreContext>();
//             _productRepositoryMock = new Mock<IRepository<Product>>();
//
//             // Configure AutoMapper if necessary
//             var configuration = new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile(new YourMappingProfile());
//             });
//
//             _mapper = configuration.CreateMapper();
//         }
//
//         [Fact]
//         public async Task Handle_WhenProductQueryWithId_ReturnsProductDto()
//         {
//             // Arrange
//             var productId = "1";
//             var product = new Product { Id = productId, /* Set other properties */ };
//             var query = new GetGenericQuery<ProductDto, Product>(productId);
//
//             _productRepositoryMock.Setup(repo => repo.GetEntityWithSpec(It.IsAny<Specification<Product>>()))
//                 .ReturnsAsync(product);
//
//             var handler = new GetGenericQueryHandler<ProductDto, Product>(
//                 _dbContextMock.Object,
//                 _productRepositoryMock.Object,
//                 _mapper
//             );
//
//             // Act
//             var result = await handler.Handle(query, CancellationToken.None);
//
//             // Assert
//             result.ShouldNotBeNull();
//             result.Id.ShouldBe(productId);
//             // Assert other properties of the result
//         }
//
//         [Fact]
//         public async Task Handle_WhenProductQueryWithoutId_ReturnsListOfProductDtos()
//         {
//             // Arrange
//             var products = new List<Product> { /* Create a list of products */ };
//             var query = new GetGenericQuery<ProductDto, Product>();
//
//             _productRepositoryMock.Setup(repo => repo.GetAllWithSpecAsync(It.IsAny<Specification<Product>>()))
//                 .ReturnsAsync(products);
//
//             var handler = new GetGenericQueryHandler<ProductDto, Product>(
//                 _dbContextMock.Object,
//                 _productRepositoryMock.Object,
//                 _mapper
//             );
//
//             // Act
//             var result = await handler.Handle(query, CancellationToken.None);
//
//             // Assert
//             result.ShouldNotBeNull();
//             result.ShouldBeAssignableTo<IQueryable<ProductDto>>();
//             result.Count().ShouldBe(products.Count);
//             // Assert other properties of the result
//         }
//
//         // Add more test cases as needed for other scenarios
//
//         // Helper mapping profile class for AutoMapper configuration
//         public class YourMappingProfile : Profile
//         {
//             public YourMappingProfile()
//             {
//                 CreateMap<Product, ProductDto>();
//                 // Add mappings for other entities if necessary
//             }
//         }
//     }
// }
