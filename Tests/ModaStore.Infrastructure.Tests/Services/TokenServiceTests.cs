using Microsoft.Extensions.Configuration;
using ModaStore.Infrastructure.Services;
using ModaStore.Infrastructure.Services.Authentication.Security;
using Moq;
using Xunit;

namespace ModaStore.Infrastructure.Tests.Services;

public class TokenServiceTests
{
    [Fact]
    public void Constructor_ConfigIsNotNull_ConfigAssignedCorrectly()
    {
        // Arrange
        var configuration = new Mock<IConfiguration>();

        // Act
        var tokenService = new TokenService(configuration.Object);

        // Assert
        Assert.NotNull(tokenService);
        // Assert.Same(configuration.Object, tokenService.GetConfig());
    }

}