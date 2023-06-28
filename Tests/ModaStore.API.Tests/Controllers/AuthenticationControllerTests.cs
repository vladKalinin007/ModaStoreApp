using System.Text;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using ModaStore.API.Tests.Base;
using ModaStore.Application.DTOs.Identity;
using Newtonsoft.Json;

namespace ModaStore.API.Tests.Controllers;

public class AuthenticationControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    
    public AuthenticationControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Login_ReturnsSuccessResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var model = new LoginDto()
        {
            Email = "vladkalinin@gmail.com",
            Password = "Azerty&01BBB6765s?"
        };

        // Act
        var response = await client.PostAsync($"/odata/authentication/login",
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<LoginDto>(responseString);

        Assert.IsType<LoginDto>(result);
        Assert.Equal(model.Email, result.Email);

    }

    [Fact]
    public async Task Register_ReturnsSuccessResult()
    {
        // Arrange
        var client = _factory.CreateClient();
        var model = new RegisterDto()
        {
            Email = "vladkalinin@gmail.com",
            Password = "Azerty&01BBB6765s?"
        };

        // Act
        var response = await client.PostAsync($"/odata/authentication/register",
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RegisterDto>(responseString);

        Assert.IsType<RegisterDto>(result);
        Assert.Equal(model.Email, result.Email);

    }


}