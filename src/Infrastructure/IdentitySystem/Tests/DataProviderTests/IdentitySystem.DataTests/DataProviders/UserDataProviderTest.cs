using IdentitySystem.DataProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentitySystem.Tests;

public class UserDataProviderTest : DataProviderTestBase
{
    #region [ Fields ]
    protected readonly IUserManagerProvider UserManager;
    #endregion

    #region [ CTors ]
    public UserDataProviderTest(string realConnection = "") : base(realConnection)
    {
        // Get UserManager from DI
        UserManager = ServiceProvider.GetRequiredService<UserManagerProvider>();
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public async void BeginTransactionAsync_Success()
    {
        // Arrange
        var userDataProvider = new UserDataProvider(UserManager, DbContext);

        // Act
        await userDataProvider.BeginTransactionAsync(CancellationToken.None);

        // Assert
        Assert.NotNull(DbContext.Database.CurrentTransaction);
    }

    [Fact]
    public async void CommitTransactionAsync_Success()
    {
        // Arrange
        var userDataProvider = new UserDataProvider(UserManager, DbContext);
        await userDataProvider.BeginTransactionAsync(CancellationToken.None);

        // Act
        await userDataProvider.CommitTransactionAsync(CancellationToken.None);

        // Assert
        Assert.Null(DbContext.Database.CurrentTransaction);
    }

    #region [ Create ]
    [Fact]
    public async Task Create_Success()
    {
        // Arrange
        var user = Fixture.Build<Domain.User>()
                          .With(i => i.Id, Guid.NewGuid().ToString())
                          .Create();
        // Act
        var userDataProvider = new UserDataProvider(UserManager, DbContext);
        var createResult = await userDataProvider.CreateAsync(user);

        // Assert
        var createdUser = await UserManager.FindByNameAsync(user.UserName!);
        Assert.True(createResult.Succeeded);
        Assert.NotNull(createdUser);
        Assert.Equal(user.UserName, createdUser.UserName);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var user = Fixture.Create<Domain.User>();

        // Act
        var userDataProvider = new UserDataProvider(UserManager, DbContext);
        var updateResult = await userDataProvider.UpdateAsync(user);

        // Assert
        Assert.True(updateResult.Succeeded);
        var updatedUser = await UserManager.FindByNameAsync(user.UserName);
        Assert.NotNull(updatedUser);
        Assert.Equal("updateduser@example.com", updatedUser.Email);
    }
    #endregion

    #endregion
}
