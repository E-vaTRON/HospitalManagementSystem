using IdentitySystem.Application;

namespace IdentitySystem.Tests;

public class AuthenticationServiceTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<IJwtTokenService> JwtProvider;
    protected readonly Mock<IUserServiceProvider> UserServiceProvider;
    protected readonly Mock<IDatabaseServiceProvider> DatabaseServiceProvider;
    protected readonly IAuthenticationService ServiceProvider;
    #endregion

    #region[ CTor ]
    public AuthenticationServiceTest() : base()
    {
        JwtProvider = new Mock<IJwtTokenService>();
        DatabaseServiceProvider = Fixture.Freeze<Mock<IDatabaseServiceProvider>>();
        UserServiceProvider = Fixture.Freeze<Mock<IUserServiceProvider>>();

        ServiceProvider = new AuthenticationService(Mapper, UserServiceProvider.Object, DatabaseServiceProvider.Object, JwtProvider.Object);
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public async Task LoginLoginWithUserName_Success()
    {
        // Arrange
        var userDtoOut = Fixture.Create<OutputUserDTO>();
        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);

        var dto = Fixture.Build<Application.UserNameLoginRecord>()
                         .With(x => x.userName, userDtoOut.UserName)
                         .With(x => x.password, userDtoOut.PasswordHash)
                         .Create();
        var consumerName = Fixture.Create<string>();
        var accessToken = Fixture.Create<string>();

        var signInResult = SignInResult.Success;

        UserServiceProvider.Setup(x => x.FindByNameAsync(dto.userName)).ReturnsAsync(userDtoOut);
        UserServiceProvider.Setup(x => x.CheckPasswordSignInAsync(userDtoIn, dto.password, LoginMode.Email, false)).ReturnsAsync(signInResult);
        JwtProvider.Setup(x => x.GenerateToken(It.IsAny<InputUserDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(accessToken);

        // Act
        var result = await ServiceProvider.LoginWithUserName(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        UserServiceProvider.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once());
        UserServiceProvider.Verify(x => x.CheckPasswordSignInAsync(It.IsAny<InputUserDTO>(), It.IsAny<string>(), LoginMode.Email, false), Times.Once());
        JwtProvider.Verify(x => x.GenerateToken(It.IsAny<InputUserDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.LoginWithUserName), serviceSuccess.MethodName);
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_LOGGED_IN_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }

    [Fact]
    public async Task LoginWithPhoneNumber_Success()
    {
        // Arrange
        var userDtoOut = Fixture.Create<OutputUserDTO>();
        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);

        var dto = Fixture.Build<PhoneNumberLoginRecord>()
                         .With(x => x.phoneNumber, userDtoOut.PhoneNumber)
                         .With(x => x.password, userDtoOut.PasswordHash)
                         .Create();
        var consumerName = Fixture.Create<string>();
        var accessToken = Fixture.Create<string>();

        var signInResult = SignInResult.Success;

        UserServiceProvider.Setup(x => x.FindByPhoneNumberAsync(dto.phoneNumber)).ReturnsAsync(userDtoOut);
        UserServiceProvider.Setup(x => x.CheckPasswordSignInAsync(userDtoIn,  dto.password, LoginMode.PhoneNumber, false)).ReturnsAsync(signInResult);
        JwtProvider.Setup(x => x.GenerateToken(It.IsAny<InputUserDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(accessToken);

        // Act
        var result = await ServiceProvider.LoginWithPhoneNumber(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        UserServiceProvider.Verify(x => x.FindByPhoneNumberAsync(It.IsAny<string>()), Times.Once());
        UserServiceProvider.Verify(x => x.CheckPasswordSignInAsync(It.IsAny<InputUserDTO>(), It.IsAny<string>(), LoginMode.PhoneNumber, false), Times.Once());
        JwtProvider.Verify(x => x.GenerateToken(It.IsAny<InputUserDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.LoginWithPhoneNumber), serviceSuccess.MethodName);
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }

    [Fact]
    public async void Register_Success()
    {
        // Arrange
        var dto = Fixture.Create<SignUpRecord>();
        var consumerName = Fixture.Create<string>();

        var userCreateDto = new InputUserDTO
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

        UserServiceProvider.Setup(x  => x.CreateAsync(It.IsAny<InputUserDTO>(), dto.password)).ReturnsAsync(createResult);
        // Act
        var result = await ServiceProvider.Register(dto, consumerName, CancellationToken.None);

        // Assert
        var serviceSuccess = result.AsT0;
        Assert.IsType<ServiceSuccess>(serviceSuccess);
        Assert.Equal(nameof(AuthenticationService), serviceSuccess.ServiceName);
        Assert.Equal(nameof(ServiceProvider.Register), serviceSuccess.MethodName);
        DatabaseServiceProvider.Verify(x => x.BeginTransactionAsync(It.IsAny<CancellationToken>()), Times.Once());
        DatabaseServiceProvider.Verify(x => x.CommitTransactionAsync(It.IsAny<CancellationToken>()), Times.Once());
        Assert.Equal(IdentitySystem.ServiceProvider.IdentityConstants.USER_CREATED_SUCCESSFULLY, serviceSuccess.SuccessMessage);
    }
    #endregion
}
