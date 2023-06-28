using Microsoft.VisualStudio.TestPlatform.TestHost;
using ModaStore.API.Tests.Base;
using ModaStore.Domain.Entities.Order.OrderManagement;
using Newtonsoft.Json;
using Shouldly;

namespace ModaStore.API.Tests.Controllers;

public class OrderControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    
    public OrderControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async Task GetOrderById_ReturnsSuccessResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var id = "1";
        
        // Act
        var response = await client.GetAsync($"/odata/order/{id}");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Order>(responseString);
        
        Assert.IsType<Order>(result);
        Assert.Equal(id, result.Id);
    }
}