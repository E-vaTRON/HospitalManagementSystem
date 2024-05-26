namespace IdentitySystem.Tests;

public class RoleDataProviderTest : DataProviderTestBase
{
    #region [ Fields ]
    protected readonly IRoleManagerProvider RoleManager;
    #endregion

    #region [ CTors ]
    public RoleDataProviderTest(string realConnection = "") : base(realConnection)
    {
        RoleManager = ServiceProvider.GetRequiredService<RoleManagerProvider>();
    }
    #endregion

    #region [ Methods ]
    #region [ Set ]
    [Fact]
    public async Task SetRoleNameAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var newRoleName = Fixture.Create<string>();
        var roleSetName = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var result = await roleManagerProvider.SetRoleNameAsync(roleSetName, newRoleName);

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
        var roleAdd = Fixture.Create<Domain.Role>();
        roleAdd.Id = Fixture.Create<Guid>().ToString();

        // Act
        var roleDataProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleAdded = await roleDataProvider.CreateAsync(roleAdd);

        // Assert
        var result = await DbContext.Roles.FirstOrDefaultAsync(u => u.Id == Guid.Parse(roleAdd.Id!));
        Assert.True(roleAdded.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(roleAdd.Name, result.Name);
    }
    #endregion

    #region [ Check ]
    [Fact]
    public async Task RoleExistsAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleExists = await roleManagerProvider.RoleExistsAsync(roleAdd.NormalizedName!);

        // Assert
        Assert.True(roleExists);
    }
    #endregion

    #region [ Get ]
    [Fact]
    public async Task FindAll_Success()
    {
        // Arrange
        var roleAddList = Fixture.CreateMany<DataProvider.Role>().ToList();

        await DbContext.Roles.AddRangeAsync(roleAddList.ToArray());
        await DbContext.SaveChangesAsync();

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var rolesFoundList = await roleManagerProvider.FindAll().ToListAsync();

        // Assert
        Assert.NotNull(rolesFoundList);
        Assert.Equal(3, rolesFoundList.Count);
        foreach (var role in rolesFoundList)
        {
            var roleAdd = roleAddList.ElementAt(rolesFoundList.IndexOf(role));
            Assert.Equal(roleAdd.Name, role.Name);
        };
    }

    [Fact]
    public async Task FindByMultipleGuidsAsync_Success()
    {
        // Arrange
        var roleAddList = Fixture.CreateMany<DataProvider.Role>().ToList();

        await DbContext.Roles.AddRangeAsync(roleAddList.ToArray());
        await DbContext.SaveChangesAsync();

        var idList = roleAddList.Select(x => x.Id.ToString()).ToArray();

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleFounds = await roleManagerProvider.FindByMultipleGuidsAsync(idList);
        var roleFoundList = roleFounds.ToList();

        // Assert
        Assert.NotNull(roleFoundList);
        Assert.Equal(3, roleFoundList.Count);
        foreach (var role in roleFoundList)
        {
            var roleAdd = roleAddList.ElementAt(roleFoundList.IndexOf(role));
            Assert.Equal(roleAdd.Name, role.Name);
        };
    }

    [Fact]
    public async Task FindByIdAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        //DbContext.Entry(userAdd).State = EntityState.Detached;

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleFound = await roleManagerProvider.FindByIdAsync(roleAdd.Id.ToString());

        // Assert
        Assert.NotNull(roleFound);
        Assert.Equal(roleAdd.Id.ToString(), roleFound.Id);
    }

    [Fact]
    public async Task FindByNameAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleFound = await roleManagerProvider.FindByNameAsync(roleAdd.NormalizedName!);

        // Assert
        Assert.NotNull(roleFound);
        Assert.Equal(roleAdd.Name, roleFound.Name);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var roleUpdate = Fixture.Create<Domain.Role>();

        roleUpdate.Id = roleAdd.Id.ToString();

        // Act
        var roleDataProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleUpdated = await roleDataProvider.UpdateAsync(roleUpdate);

        // Assert
        var result = await DbContext.Roles.FirstOrDefaultAsync(u => u.Id == roleAdd.Id!);
        Assert.True(roleUpdated.Succeeded);
        Assert.NotNull(result);
        Assert.Equal(roleUpdate.Name, result.Name);
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async Task DeleteAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var roleDelete = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleDataProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var roleDeleted = await roleDataProvider.DeleteAsync(roleDelete);

        // Assert
        var result = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == roleAdd.Id!);
        Assert.NotNull(roleDeleted);
        Assert.True(roleDeleted.Succeeded);
        Assert.Null(result);
    }
    #endregion

    #region [ Claim ]
    [Fact]
    public async Task GetClaimsAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        var roleClaimAddList = Fixture.Build<DataProvider.RoleClaim>()
                                      .With(i => i.RoleId, roleAdd.Id)
                                      .CreateMany().ToList();

        await DbContext.RoleClaims.AddRangeAsync(roleClaimAddList);
        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var roleGetClaim = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var claims = await roleManagerProvider.GetClaimsAsync(roleGetClaim);

        // Assert
        Assert.NotNull(claims);
        Assert.Equal(3, claims.Count);
        foreach (var claim in claims)
        {
            var claimAdded = roleClaimAddList.ElementAt(claims.IndexOf(claim));
            Assert.Equal(claimAdded.ClaimType, claim.Type);
            Assert.Equal(claimAdded.ClaimValue, claim.Value);
        };
    }

    [Fact]
    public async Task AddClaimAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Create<DataProvider.Role>();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var claim = new Claim("TestClaim", "TestValue");

        var roleAddClaim = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleManagerProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var result = await roleManagerProvider.AddClaimAsync(roleAddClaim, claim);

        // Assert
        var userClaims = await DbContext.UserClaims.Where(x => x.UserId == roleAdd.Id!).ToListAsync();
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
        var roleAdd = Fixture.Create<DataProvider.Role>();

        var roleClaimAdd = Fixture.Build<DataProvider.RoleClaim>()
                                  .With(i => i.RoleId, roleAdd.Id)
                                  .Create();

        var claimRemove = new Claim(roleClaimAdd.ClaimType!, roleClaimAdd.ClaimValue!);

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.RoleClaims.AddAsync(roleClaimAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;
        DbContext.Entry(roleClaimAdd).State = EntityState.Detached;

        var roleRemoveClaim = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleDataProvider = new RoleDataProvider(DbContext, RoleManager, Mapper);
        var result = await roleDataProvider.RemoveClaimAsync(roleRemoveClaim, claimRemove);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
    }
    #endregion
    #endregion
}
