using OneOf.Types;

namespace IdentitySystem.Tests;

public class UserServiceProviderTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<ISignInProvider> SignInProvider;
    protected readonly Mock<IUserDataProvider> DataProvider;
    protected readonly IUserServiceProvider ServiceProvider;
    #endregion

    #region[ CTor ]
    public UserServiceProviderTest()
    {
        SignInProvider = new Mock<ISignInProvider>();
        DataProvider = Fixture.Freeze<Mock<IUserDataProvider>>();
        ServiceProvider = new UserServiceProvider(DataProvider.Object, SignInProvider.Object, Mapper);
    }
    #endregion

    #region [ Methods ]

    #region [ Check ]
    [Fact]
    public async Task CheckPasswordSignInAsync_Success()
    {
        // Arrange
        var userDto = Fixture.Create<InputUserDTO>();
        var password = Fixture.Create<string>();
        var lockoutOnFailure = false;
        var cancellationToken = CancellationToken.None;

        var user = Mapper.Map<Domain.User>(userDto);

        DataProvider.Setup(x => x.FindByEmailAsync(user.Email!)).ReturnsAsync(user);
        DataProvider.Setup(x => x.FindByPhoneNumberAsync(user.PhoneNumber!)).ReturnsAsync(user);
        SignInProvider.Setup(x => x.CheckPasswordSignInAsync(user, password, lockoutOnFailure)).ReturnsAsync(SignInResult.Success);

        // Act
        var emailResult = await ServiceProvider.CheckPasswordSignInAsync(userDto, password, LoginMode.Email, lockoutOnFailure); 
        var phoneNumberResult = await ServiceProvider.CheckPasswordSignInAsync(userDto, password, LoginMode.PhoneNumber, lockoutOnFailure);

        // Assert
        Assert.Equal(SignInResult.Success, emailResult);
        Assert.Equal(SignInResult.Success, phoneNumberResult);
    }

    #endregion

    #endregion
}
