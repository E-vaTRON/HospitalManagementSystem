namespace IdentitySystem.Tests;

public class JWTTokenServiceTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly JwtTokenConfig TokenConfig;
    protected readonly IJwtTokenService ServiceProvider;
    protected readonly Mock<IOptionsMonitor<JwtTokenConfig>> TokenConfigOptionsAccessorMock;
    #endregion

    #region[ CTor ]
    public JWTTokenServiceTest() : base()
    {
        TokenConfig = Fixture.Create<JwtTokenConfig>();
        TokenConfigOptionsAccessorMock = new Mock<IOptionsMonitor<JwtTokenConfig>>();
        TokenConfigOptionsAccessorMock.Setup(x => x.CurrentValue).Returns(TokenConfig);

        ServiceProvider = new JWTTokenService(TokenConfigOptionsAccessorMock.Object);
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public void GenerateToken_Success()
    {
        // Arrange
        var user = Fixture.Create<UserCreateDTO>();
        var iat = DateTime.UtcNow;
        var exp = DateTime.UtcNow.AddDays(1);

        // Act
        var token = ServiceProvider.GenerateToken(user, iat, exp);

        // Assert
        Assert.NotNull(token);
        Assert.IsType<string>(token);
    }

    #endregion
}
