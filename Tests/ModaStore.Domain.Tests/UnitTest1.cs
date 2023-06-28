using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Product_ShouldHaveAllPropertiesSet()
    {
        // Arrange
        var product = new Product
        {
            Name = "Product Name",
            Description = "Product Description",
            Price = 9.99m,
            PictureUrl = "https://example.com/product.jpg",
            ProductType = new ProductType { Name = "Type Name" },
            ProductTypeId = "type-id",
            ProductBrand = new ProductBrand { Name = "Brand Name" },
            ProductBrandId = "brand-id"
        };
    
        // Act
        var name = product.Name;
        var description = product.Description;
        var price = product.Price;
        var pictureUrl = product.PictureUrl;
        var productType = product.ProductType;
        var productTypeId = product.ProductTypeId;
        var productBrand = product.ProductBrand;
        var productBrandId = product.ProductBrandId;
    
        // Assert
        Assert.Equal("Product Name", name);
        Assert.Equal("Product Description", description);
        Assert.Equal(9.99m, price);
        Assert.Equal("https://example.com/product.jpg", pictureUrl);
        Assert.Equal("Type Name", productType.Name);
        Assert.Equal("type-id", productTypeId);
        Assert.Equal("Brand Name", productBrand.Name);
        Assert.Equal("brand-id", productBrandId);
    }

}