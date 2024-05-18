using IdentitySystem.Application;

namespace IdentitySystem.Tests;

public class AuthenticationServiceTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<IJwtTokenService> JwtProvider;
    protected readonly Mock<IUserServiceProvider> UserServiceProvider;
    protected readonly Mock<IUserDataProvider> UserDataProvider;
    protected readonly IAuthenticationService ServiceProvider;
    #endregion

    #region[ CTor ]
    public AuthenticationServiceTest() : base()
    {
        JwtProvider = new Mock<IJwtTokenService>();
        UserDataProvider = new Mock<IUserDataProvider>();
        UserServiceProvider = Fixture.Freeze<Mock<IUserServiceProvider>>();

        ServiceProvider = new AuthenticationService(Mapper, UserServiceProvider.Object, UserDataProvider.Object, JwtProvider.Object);
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public async Task Login_Success()
    {
        // Arrange
        var userDto = Fixture.Create<UserDTO>();
        var dto = Fixture.Build<UserLogin>()
                         .With(x => x.username, userDto.UserName)
                         .With(x => x.password, userDto.PasswordHash)
                         .Create();
        var consumerName = Fixture.Create<string>();
        var accessToken = Fixture.Create<string>();

        var signInResult = SignInResult.Success;

        UserServiceProvider.Setup(x => x.FindByNameAsync(dto.username)).ReturnsAsync(userDto);
        UserServiceProvider.Setup(x => x.CheckPasswordSignInAsync(userDto, dto.password, LoginMode.Email, false, It.IsAny<CancellationToken>())).ReturnsAsync(signInResult);
        JwtProvider.Setup(x => x.GenerateToken(It.IsAny<UserCreateDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(accessToken);

        // Act
        var result = await ServiceProvider.Login(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        UserServiceProvider.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once());
        UserServiceProvider.Verify(x => x.CheckPasswordSignInAsync(It.IsAny<UserDTO>(), It.IsAny<string>(), LoginMode.Email, false, It.IsAny<CancellationToken>()), Times.Once());
        JwtProvider.Verify(x => x.GenerateToken(It.IsAny<UserCreateDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.Login), serviceSuccess.MethodName);
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_LOGGED_IN_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }

    [Fact]
    public async Task LoginWithPhoneNumber_Success()
    {
        // Arrange
        var userDto = Fixture.Create<UserDTO>();
        var dto = Fixture.Build<PhoneNumberUserLogin>()
                         .With(x => x.phoneNumber, userDto.PhoneNumber)
                         .With(x => x.password, userDto.PasswordHash)
                         .Create();
        var consumerName = Fixture.Create<string>();
        var accessToken = Fixture.Create<string>();

        var signInResult = SignInResult.Success;

        UserServiceProvider.Setup(x => x.FindByPhoneNumberAsync(dto.phoneNumber, It.IsAny<CancellationToken>())).ReturnsAsync(userDto);
        UserServiceProvider.Setup(x => x.CheckPasswordSignInAsync(userDto,  dto.password, LoginMode.PhoneNumber, false, It.IsAny<CancellationToken>())).ReturnsAsync(signInResult);
        JwtProvider.Setup(x => x.GenerateToken(It.IsAny<UserCreateDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(accessToken);

        // Act
        var result = await ServiceProvider.LoginWithPhoneNumber(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        UserServiceProvider.Verify(x => x.FindByPhoneNumberAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());
        UserServiceProvider.Verify(x => x.CheckPasswordSignInAsync(It.IsAny<UserDTO>(), It.IsAny<string>(), LoginMode.PhoneNumber, false, It.IsAny<CancellationToken>()), Times.Once());
        JwtProvider.Verify(x => x.GenerateToken(It.IsAny<UserCreateDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.LoginWithPhoneNumber), serviceSuccess.MethodName);
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }

    [Fact]
    public async void Register_Success()
    {
        // Arrange
        var dto = Fixture.Create<UserSignUp>();
        var consumerName = Fixture.Create<string>();

        var userCreateDto = new UserCreateDTO
        {
            Email = dto.email,
            UserName = dto.userName,
            FirstName = dto.firstName,
            LastName = dto.lastName,
            PhoneNumber = dto.phoneNumber,
            CreatedOn = DateTime.UtcNow
        };

        var userDto = Mapper.Map<UserDTO>(userCreateDto);

        var createResult = IdentityResult.Success;

        UserServiceProvider.Setup(x  => x.CreateAsync(It.IsAny<UserDTO>(), dto.password)).ReturnsAsync(createResult);
        // Act
        var result = await ServiceProvider.Register(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.Register), serviceSuccess.MethodName);
        UserDataProvider.Verify(x => x.BeginTransactionAsync(It.IsAny<CancellationToken>()), Times.Once());
        UserDataProvider.Verify(x => x.CommitTransactionAsync(It.IsAny<CancellationToken>()), Times.Once());
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_CREATED_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }
    #endregion
}
