using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ModaStore.Application.DTOs.Customers;
using ModaStore.Application.DTOs.Identity;
using ModaStore.Application.DTOs.Order;
using Newtonsoft.Json;

namespace ModaStore.API.Tests.Controllers;

public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    // it's test of UserContoller.Get
    [Fact]
    public async Task Get_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var id = "1";
        
        // Act
        var response = await client.GetAsync($"/odata/user");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<UserDto>(responseString);
        
        Assert.IsType<UserDto>(result);
        Assert.Equal(id, result.Id);
    }
    
    // it's test of UserContoller.Put
    [Fact]
    public async Task Put_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestUri = "/odata/user";
        var userDto = new UserDto { /* Initialize the user DTO object */ };

        // Act
        var response = await client.PutAsJsonAsync(requestUri, userDto);

        // Assert
        response.EnsureSuccessStatusCode();
        // Perform additional assertions on the response if needed
    }
    
    // it's test of UserContoller.Delete
    [Fact]
    public async Task Delete_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var id = "1";
        
        // Act
        var response = await client.DeleteAsync($"/odata/user/{id}");
        
        // Assert
        response.EnsureSuccessStatusCode();
        // Perform additional assertions on the response if needed
    }
    
    // it's test of UserContoller.GetAddress
    [Fact]
    public async Task GetAddress_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var id = "1";
        
        // Act
        var response = await client.GetAsync($"/odata/user/address");
        
        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AddressDto>(responseString);
        
        Assert.IsType<AddressDto>(result);
        Assert.Equal(id, result.Id);
    }
    
    // it's test of UserContoller.PutAddress
    [Fact]
    public async Task PutAddress_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestUri = "/odata/user/address";
        var addressDto = new AddressDto { /* Initialize the address DTO object */ };

        // Act
        var response = await client.PutAsJsonAsync(requestUri, addressDto);

        // Assert
        response.EnsureSuccessStatusCode();
        // Perform additional assertions on the response if needed
    }
    
    // it's test of UserContoller.CheckEmailExistsAsync
    [Fact]
    public async Task CheckEmailExistsAsync_ReturnsOkResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var email = "test@gmail.com";

        // Act
        var response = await client.GetAsync($"/odata/user/emailexists/");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<bool>(responseString);
    }
}