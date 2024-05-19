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
        var userAdd = Fixture.Build<Domain.User>().Without(i => i.UserRoles)
                          .With(i => i.Id, Guid.NewGuid().ToString())
                          .Create();


        // Act
        var userDataProvider = new UserDataProvider(UserManager, DbContext);
        var userAdded = await userDataProvider.CreateAsync(userAdd);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userAdd.Id!));
        Assert.True(userAdded.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(userAdd.UserName, result.UserName);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Without(i => i.UserRoles)
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();
        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userUpdate = Fixture.Build<Domain.User>()
                                .Without(i => i.UserRoles)
                                .Without(i => i.Id)
                                .Create();

        userUpdate.Id = userAdd.Id.ToString();
        // Act
        var userDataProvider = new UserDataProvider(UserManager, DbContext);
        var userUpdated = await userDataProvider.UpdateAsync(userUpdate);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userAdd.Id!);
        Assert.True(userUpdated.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(userUpdate.Email, result.Email);
    }
    #endregion

    #endregion
}
