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
    #region [ Claim ]
    [Fact]
    public async Task GetClaimsAsync_Success()
    {
        // Arrange
        var roleAdd = Fixture.Build<DataProvider.Role>()
                             .Create();

        var roleClaimAddList = Fixture.Build<DataProvider.RoleClaim>()
                             .With(i => i.RoleId, roleAdd.Id)
                             .CreateMany().ToList();

        await DbContext.RoleClaims.AddRangeAsync(roleClaimAddList);
        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var roleGetClaim = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleManagerProvider = new RoleDataProvider(RoleManager);
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
        var roleAdd = Fixture.Build<DataProvider.Role>()
                             .Create();

        roleAdd.NormalizedName = roleAdd.Name!.ToUpper();

        await DbContext.Roles.AddAsync(roleAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(roleAdd).State = EntityState.Detached;

        var claim = new Claim("TestClaim", "TestValue");

        var roleAddClaim = Mapper.Map<Domain.Role>(roleAdd);

        // Act
        var roleManagerProvider = new RoleDataProvider(RoleManager);
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


    //[Fact]
    //public async Task RemoveClaimAsync_Success()
    //{
    //    // Arrange
    //    var userAdd = Fixture.Build<DataProvider.User>()
    //                         .Create();

    //    var userClaimAdd = Fixture.Build<DataProvider.UserClaim>()
    //                              .Create();

    //    var claimRemove = new Claim(userClaimAdd.ClaimType!, userClaimAdd.ClaimValue!);

    //    await DbContext.Users.AddAsync(userAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(userAdd).State = EntityState.Detached;

    //    var userRemoveClaim = Mapper.Map<Domain.User>(userAdd);

    //    // Act
    //    var userDataProvider = new RoleDataProvider(RoleManager);
    //    var result = await userDataProvider.RemoveClaimAsync(userRemoveClaim, claimRemove);

    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.True(result.Succeeded);
    //}
    #endregion
    #endregion
}
