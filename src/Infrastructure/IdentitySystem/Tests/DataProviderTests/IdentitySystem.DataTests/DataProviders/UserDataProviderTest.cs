using OneOf.Types;
using System.Security.Claims;

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
    #region [ Set ]
    //[Fact]
    //public async Task SetUserNameAsync_Success()
    //{
    //    // Arrange
    //    var userAdd = Fixture.Build<Domain.User>()
    //                         .With(i => i.Id, Guid.NewGuid().ToString())
    //                         .Create();

    //    await DbContext.Users.AddAsync(userAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(userAdd).State = EntityState.Detached;

    //    var newUserName = "NewUserName";
    //    var userDataProvider = new UserDataProvider(UserManager, DbContext);

    //    // Act
    //    await userDataProvider.SetUserNameAsync(userAdd, newUserName, CancellationToken.None);

    //    // Assert
    //    var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userAdd.Id));
    //    Assert.NotNull(result);
    //    Assert.Equal(newUserName, result.UserName);
    //}

    //[Fact]
    //public async Task SetNormalizedUserNameAsync_Success()
    //{
    //    // Arrange
    //    var userAdd = Fixture.Build<Domain.User>()
    //                         .With(i => i.Id, Guid.NewGuid().ToString())
    //                         .Create();

    //    await DbContext.Users.AddAsync(userAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(userAdd).State = EntityState.Detached;

    //    var newNormalizedUserName = "NEWUSERNAME";
    //    var userDataProvider = new UserDataProvider(UserManager, DbContext);

    //    // Act
    //    await userDataProvider.SetNormalizedUserNameAsync(userAdd, newNormalizedUserName, CancellationToken.None);

    //    // Assert
    //    var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userAdd.Id));
    //    Assert.NotNull(result);
    //    Assert.Equal(newNormalizedUserName, result.NormalizedUserName);
    //}
    #endregion

    #region [ Create ]
    [Fact]
    public async Task CreateAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<Domain.User>()
                             .With(i => i.Id, Guid.NewGuid().ToString())
                             .Create();

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var userAdded = await userDataProvider.CreateAsync(userAdd);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userAdd.Id!));
        Assert.True(userAdded.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(userAdd.UserName, result.UserName);
    }

    [Fact]
    public async Task CreateAsync_WithPassword_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<Domain.User>()
                             .With(i => i.Id, Guid.NewGuid().ToString())
                             .Create();

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var userAdded = await userDataProvider.CreateAsync(userAdd, userAdd.PasswordHash!);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userAdd.Id!));
        Assert.True(userAdded.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(userAdd.UserName, result.UserName);
    }
    #endregion

    #region [ Get ]
    [Fact]
    public async Task FindAll_Success()
    {
        // Arrange
        var userAddList = Fixture.Build<DataProvider.User>()
                                 .CreateMany().ToList();

        await DbContext.Users.AddRangeAsync(userAddList.ToArray());
        await DbContext.SaveChangesAsync();

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var usersFound = userManagerProvider.FindAll();

        // Assert
        Assert.NotNull(usersFound);
        //Assert.Equal(userAdd.Email, usersFound.First().Email);
    }

    [Fact]
    public async Task FindByMultipleGuidsAsync_Success()
    {
        // Arrange
        var userAddList = Fixture.Build<DataProvider.User>()
                                 .CreateMany().ToList();

        await DbContext.Users.AddRangeAsync(userAddList.ToArray());
        await DbContext.SaveChangesAsync();

        var idList = DbContext.Users.Select(x => x.Id.ToString()).ToArray();

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var usersFoundList = await userManagerProvider.FindByMultipleGuidsAsync(idList);

        // Assert
        Assert.NotNull(usersFoundList);
        Assert.Equal(3, usersFoundList.Count);
    }

    [Fact]
    public async Task FindByIdAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        //DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var userFound = await userManagerProvider.FindByIdAsync(userAdd.Id.ToString());

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.Id.ToString(), userFound.Id);
    }

    [Fact]
    public async Task FindByPhoneNumberAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        //DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var userFound = await userManagerProvider.FindByPhoneNumberAsync(userAdd.PhoneNumber!);

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.PhoneNumber, userFound.PhoneNumber);
    }


    [Fact]
    public async Task FindByEmailAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        userAdd.NormalizedEmail = userAdd.Email!.ToUpper();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var userFound = await userManagerProvider.FindByEmailAsync(userAdd.NormalizedEmail!);

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.Email, userFound.Email);
    }

    [Fact]
    public async Task FindByNameAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        userAdd.NormalizedUserName = userAdd.UserName!.ToUpper();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var userFound = await userManagerProvider.FindByNameAsync(userAdd.NormalizedUserName!);

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.UserName, userFound.UserName);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userUpdate = Fixture.Build<Domain.User>()
                                .Without(i => i.Id)
                                .Create();

        userUpdate.Id = userAdd.Id.ToString();
        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var userUpdated = await userDataProvider.UpdateAsync(userUpdate);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userAdd.Id!);
        Assert.True(userUpdated.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(userUpdate.Email, result.Email);
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async Task DeleteAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();

        var userDelete = Mapper.Map<Domain.User>(userAdd);
        DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var userDeleted = await userDataProvider.DeleteAsync(userDelete);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userAdd.Id!);
        Assert.NotNull(userDeleted);
        Assert.True(userDeleted.Succeeded);
        Assert.Null(result);
    }
    #endregion

    #region [ Claim Role ]
    [Fact]
    public async Task GetRolesAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        var roleAddList = Fixture.Build<DataProvider.Role>()
                                 .CreateMany().ToList();

        var userRoleAddList = Fixture.Build<DataProvider.UserRole>()
                                     .With(i => i.UserId, userAdd.Id)
                                     .With(i => i.User, userAdd)
                                     .Without(i => i.RoleId)
                                     .CreateMany().ToList();

        var roleNameList = new List<string>();
        userRoleAddList.ForEach(userRole =>
        {
            roleNameList.Add(roleAddList.ElementAt(userRoleAddList.IndexOf(userRole)).Name!);
            userRole.RoleId = roleAddList.ElementAt(userRoleAddList.IndexOf(userRole)).Id;
            userRole.Role = roleAddList.ElementAt(userRoleAddList.IndexOf(userRole));
        });

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.Roles.AddRangeAsync(roleAddList.ToArray());
        await DbContext.UserRoles.AddRangeAsync(userRoleAddList.ToArray());
        await DbContext.SaveChangesAsync();

        var userGetRole = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var roles = await userDataProvider.GetRolesAsync(userGetRole);

        // Assert
        var resultList = await DbContext.Roles.Where(x => roleAddList.Contains(x)).ToListAsync();
        Assert.NotNull(roles);
        Assert.Equal(3, roles.Count);
        foreach (var result in resultList)
        {
            var roleName = roleNameList.ElementAt(resultList.IndexOf(result));
            Assert.Equal(roleName, result.Name);
        }
    }

    [Fact]
    public async Task AddToRoleAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Create();

        var roleAdd = Fixture.Build<DataProvider.Role>()
                             .Create();

        roleAdd.NormalizedName = roleAdd.Name!.ToUpper();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var userAddRole = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var result = await userDataProvider.AddToRoleAsync(userAddRole, roleAdd.NormalizedName);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }

    [Fact]
    public async Task RemoveFromRoleAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        var roleAdd = Fixture.Build<DataProvider.Role>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        roleAdd.NormalizedName = roleAdd.Name!.ToUpper();

        var userRoleAdd = Fixture.Build<DataProvider.UserRole>()
                                 .With(i => i.UserId, userAdd.Id)
                                 .With(i => i.RoleId, roleAdd.Id)
                                 .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.UserRoles.AddAsync(userRoleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;
        DbContext.Entry(roleAdd).State = EntityState.Detached;
        DbContext.Entry(userRoleAdd).State = EntityState.Detached;

        var userRemoveRole = Mapper.Map<Domain.User>(userAdd);
        var roleNormalizedName = roleAdd.NormalizedName!;

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var result = await userDataProvider.RemoveFromRoleAsync(userRemoveRole, roleNormalizedName);

        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }


    [Fact]
    public async Task AddClaimAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var claim = new Claim("TestClaim", "TestValue");

        var userAddClaim = Mapper.Map<Domain.User>(userAdd);
        // Act
        var userManagerProvider = new UserDataProvider(UserManager);
        var result = await userManagerProvider.AddClaimAsync(userAddClaim, claim);

        // Assert
        var user = await DbContext.Users.Include(x => x.UserClaims).FirstOrDefaultAsync(x => x.Id == userAdd.Id!);
        var userClaims = await DbContext.UserClaims.Where(x => user!.UserClaims.Contains(x)).ToListAsync();
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
        Assert.Contains(userClaims.Where(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value).First(), userClaims);
    }


    [Fact]
    public async Task RemoveClaimAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Create();

        var userClaimAdd = Fixture.Build<DataProvider.UserClaim>()
                                  .Create();

        var claimRemove = new Claim(userClaimAdd.ClaimType!, userClaimAdd.ClaimValue!);

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userRemoveClaim = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var result = await userDataProvider.RemoveClaimAsync(userRemoveClaim, claimRemove);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }

    #endregion

    #region [ Password ]
    [Fact]
    public async Task HasPasswordAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Create();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userHasPassword = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var hasPassword = await userDataProvider.HasPasswordAsync(userHasPassword);

        // Assert
        Assert.True(hasPassword);
    }

    [Fact]
    public async Task CheckPasswordAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .Without(i => i.PasswordHash)
                             .Create();

        var password = Fixture.Create<string>();
        var passwordHasher = new PasswordHasher<DataProvider.User>();

        // Hash the password
        var hashedPassword = passwordHasher.HashPassword(userAdd, password);
        userAdd.PasswordHash = hashedPassword;

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userCheckPassword = Mapper.Map<Domain.User>(userAdd);

        // Act
        //var creationResult = await UserManager.CreateAsync(userCheckPassword, password);

        var userDataProvider = new UserDataProvider(UserManager);
        var isPasswordValid = await userDataProvider.CheckPasswordAsync(userCheckPassword, password);

        // Assert
        Assert.True(isPasswordValid);
    }

    [Fact]
    public async Task ChangePasswordAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Build<DataProvider.User>()
                             .With(i => i.Id, Guid.NewGuid())
                             .Create();

        var currentPassword = Fixture.Create<string>();
        var newPassword = Fixture.Create<string>();

        var passwordHasher = new PasswordHasher<DataProvider.User>();
        var currentHashedPassword = passwordHasher.HashPassword(userAdd, currentPassword);
        userAdd.PasswordHash = currentHashedPassword;

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userChangePassword = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(UserManager);
        var result = await userDataProvider.ChangePasswordAsync(userChangePassword, currentPassword, newPassword);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }
    #endregion

    #endregion
}
