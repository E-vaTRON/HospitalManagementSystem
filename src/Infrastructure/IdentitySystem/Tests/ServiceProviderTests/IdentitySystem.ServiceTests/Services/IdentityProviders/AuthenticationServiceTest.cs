namespace IdentitySystem.Tests;

public class AuthenticationServiceTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<IJwtTokenService> JwtProvider;
    protected readonly Mock<IUserServiceProvider> DataProvider;
    protected readonly IAuthenticationService ServiceProvider;
    #endregion

    #region[ CTor ]
    public AuthenticationServiceTest() : base()
    {
        DataProvider = Fixture.Freeze<Mock<IUserServiceProvider>>();
        JwtProvider = Fixture.Freeze<Mock<IJwtTokenService>>();
        ServiceProvider = new AuthenticationService(Mapper, DataProvider.Object, JwtProvider.Object);
    }
    #endregion
}
