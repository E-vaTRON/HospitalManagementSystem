using AutoFixture;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
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
    [Fact]
    public async Task SetUserNameAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var newUserName = Fixture.Create<string>();
        var userSetName = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var result = await userManagerProvider.SetUserNameAsync(userSetName, newUserName);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }
    #endregion

    #region [ Create ]
    [Fact]
    public async Task CreateAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<Domain.User>();
        userAdd.Id = Fixture.Create<Guid>().ToString();

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
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
        var userAdd = Fixture.Create<Domain.User>();
        userAdd.Id = Fixture.Create<Guid>().ToString();
        var password = Fixture.Create<string>();

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userAdded = await userDataProvider.CreateAsync(userAdd, password);

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
        var userAddList = Fixture.CreateMany<DataProvider.User>().ToList();

        await DbContext.Users.AddRangeAsync(userAddList.ToArray());
        await DbContext.SaveChangesAsync();

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userFoundList = await userManagerProvider.FindAll().ToListAsync();

        // Assert
        Assert.NotNull(userFoundList);
        Assert.Equal(3, userFoundList.Count);
        foreach (var user in userFoundList)
        {
            var userAdd = userAddList.ElementAt(userFoundList.IndexOf(user));
            Assert.Equal(userAdd.UserName, user.UserName);
        };
    }

    [Fact]
    public async Task FindByMultipleGuidsAsync_Success()
    {
        // Arrange
        var userAddList = Fixture.CreateMany<DataProvider.User>().ToList();

        await DbContext.Users.AddRangeAsync(userAddList.ToArray());
        await DbContext.SaveChangesAsync();

        var idList = userAddList.Select(x => x.Id.ToString()).ToArray();

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userFounds = await userManagerProvider.FindByMultipleGuidsAsync(idList);
        var userFoundList = userFounds.ToList();

        // Assert
        Assert.NotNull(userFoundList);
        Assert.Equal(3, userFoundList.Count);
        foreach (var user in userFoundList)
        {
            var userAdd = userAddList.ElementAt(userFoundList.IndexOf(user));
            Assert.Equal(userAdd.UserName, user.UserName);
        };
    }

    [Fact]
    public async Task FindByIdAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        //DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userFound = await userManagerProvider.FindByIdAsync(userAdd.Id.ToString());

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.Id.ToString(), userFound.Id);
    }

    [Fact]
    public async Task FindByPhoneNumberAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        //DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userFound = await userManagerProvider.FindByPhoneNumberAsync(userAdd.PhoneNumber!);

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.PhoneNumber, userFound.PhoneNumber);
    }


    [Fact]
    public async Task FindByEmailAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userFound = await userManagerProvider.FindByEmailAsync(userAdd.NormalizedEmail!);

        // Assert
        Assert.NotNull(userFound);
        Assert.Equal(userAdd.Email, userFound.Email);
    }

    [Fact]
    public async Task FindByNameAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
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
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userUpdate = Fixture.Create<Domain.User>();

        userUpdate.Id = userAdd.Id.ToString();

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
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
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userDelete = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var userDeleted = await userDataProvider.DeleteAsync(userDelete);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userAdd.Id!);
        Assert.NotNull(userDeleted);
        Assert.True(userDeleted.Succeeded);
        Assert.Null(result);
    }
    #endregion

    #region [ Role ]
    [Fact]
    public async Task GetRolesAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        var roleAddList = Fixture.CreateMany<DataProvider.Role>().ToList();

        var userRoleAddList = Fixture.Build<DataProvider.UserRole>()
                                     .With(i => i.UserId, userAdd.Id)
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
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
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
        var userAdd = Fixture.Create<DataProvider.User>();

        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var userAddRole = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var result = await userDataProvider.AddToRoleAsync(userAddRole, roleAdd.NormalizedName!);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }

    [Fact]
    public async Task RemoveFromRoleAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        var roleAdd = Fixture.Create<DataProvider.Role>();

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
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var result = await userDataProvider.RemoveFromRoleAsync(userRemoveRole, roleNormalizedName);

        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }
    #endregion

    #region [ Claim ]
    [Fact]
    public async Task GetClaimsAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        var userClaimAddList = Fixture.Build<DataProvider.UserClaim>()
                                      .With(i => i.UserId, userAdd.Id)
                                      .CreateMany().ToList();

        await DbContext.UserClaims.AddRangeAsync(userClaimAddList);
        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userGetClaim = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var claims = await userManagerProvider.GetClaimsAsync(userGetClaim);

        // Assert
        Assert.NotNull(claims);
        Assert.Equal(3, claims.Count);
        foreach (var claim in claims)
        {
            var claimAdded = userClaimAddList.ElementAt(claims.IndexOf(claim));
            Assert.Equal(claimAdded.ClaimType, claim.Type);
            Assert.Equal(claimAdded.ClaimValue, claim.Value);
        };
    }

    [Fact]
    public async Task AddClaimAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var claim = new Claim("TestClaim", "TestValue");

        var userAddClaim = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userManagerProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var result = await userManagerProvider.AddClaimAsync(userAddClaim, claim);

        // Assert
        var userClaims = await DbContext.UserClaims.Where(x => x.UserId == userAdd.Id!).ToListAsync();
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
        foreach (var userClaim in userClaims)
        {
            Assert.Equal(userClaim.ClaimType, claim.Type);
            Assert.Equal(userClaim.ClaimValue, claim.Value);
        };
    }

    [Fact]
    public async Task RemoveClaimAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        var userClaimAdd = Fixture.Build<DataProvider.UserClaim>()
                                  .With(i => i.UserId, userAdd.Id)
                                  .Create();

        var claimRemove = new Claim(userClaimAdd.ClaimType!, userClaimAdd.ClaimValue!);

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.UserClaims.AddAsync(userClaimAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;
        DbContext.Entry(userClaimAdd).State = EntityState.Detached;

        var userRemoveClaim = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
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
        var userAdd = Fixture.Create<DataProvider.User>();

        var password = Fixture.Create<string>();
        var passwordHasher = new PasswordHasher<DataProvider.User>();
        var hashedPassword = passwordHasher.HashPassword(userAdd, password);
        userAdd.PasswordHash = hashedPassword;

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userHasPassword = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var hasPassword = await userDataProvider.HasPasswordAsync(userHasPassword);

        // Assert
        Assert.True(hasPassword);
    }

    [Fact]
    public async Task CheckPasswordAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

        var password = Fixture.Create<string>();
        var passwordHasher = new PasswordHasher<DataProvider.User>();
        var hashedPassword = passwordHasher.HashPassword(userAdd, password);
        userAdd.PasswordHash = hashedPassword;

        await DbContext.Users.AddAsync(userAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(userAdd).State = EntityState.Detached;

        var userCheckPassword = Mapper.Map<Domain.User>(userAdd);

        // Act
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var isPasswordValid = await userDataProvider.CheckPasswordAsync(userCheckPassword, password);

        // Assert
        Assert.True(isPasswordValid);
    }

    [Fact]
    public async Task ChangePasswordAsync_Success()
    {
        // Arrange
        var userAdd = Fixture.Create<DataProvider.User>();

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
        var userDataProvider = new UserDataProvider(DbContext, UserManager, Mapper);
        var result = await userDataProvider.ChangePasswordAsync(userChangePassword, currentPassword, newPassword);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }
    #endregion
    #endregion
}
