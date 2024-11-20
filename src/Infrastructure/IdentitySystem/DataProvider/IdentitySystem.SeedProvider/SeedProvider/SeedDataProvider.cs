namespace IdentitySystem.DataProvider;

public class SeedDataProvider : ISeedDataProvider
{
    #region [ Fields ]
    private readonly IMapper Mapper;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedDataProvider(IMapper mapper,
                            IdentitySystemDbContext dbContextFactory)
    {
        Mapper = mapper;
        DbContext = dbContextFactory;
    }
    #endregion

    #region [ Methods ]
    public async Task EnsureDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }
        await DbContext.Database.EnsureCreatedAsync();
    }

    public async Task DropDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }

        await DbContext.Database.EnsureDeletedAsync();
    }

    public async Task ClearDatabaseAsync()
    {
        DbContext.RemoveRange(await this.DbContext.Users.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.Roles.ToListAsync());

        DbContext.RemoveRange(await this.DbContext.UserRoles.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.UserClaims.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.UserTokens.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.UserLogins.ToListAsync());

        DbContext.RemoveRange(await this.DbContext.Specializations.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.UserSpecializations.ToListAsync());

        DbContext.RemoveRange(await this.DbContext.Notifications.ToListAsync());

        DbContext.RemoveRange(await this.DbContext.ScheduleSlots.ToListAsync());
        DbContext.RemoveRange(await this.DbContext.ScheduleDays.ToListAsync());
    }

    public async Task SeedDatabaseAsync()
    {
        var strategy = DbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await DbContext.Users.SeedAsync(SeedProvider.Seed.Users, Mapper);
                    await DbContext.Roles.SeedAsync(SeedProvider.Seed.Roles, Mapper);

                    await DbContext.UserRoles.SeedAsync(SeedProvider.Seed.UserRoles, Mapper);
                    await DbContext.UserClaims.SeedAsync(SeedProvider.Seed.UserClaims, Mapper);
                    await DbContext.UserTokens.SeedAsync(SeedProvider.Seed.UserTokens, Mapper);
                    await DbContext.UserLogins.SeedAsync(SeedProvider.Seed.UserLogins, Mapper);

                    await DbContext.Specializations.SeedAsync(SeedProvider.Seed.Specializations, Mapper);
                    await DbContext.UserSpecializations.SeedAsync(SeedProvider.Seed.UserSpecializations, Mapper);

                    await DbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception exception)
                {
                    // Output the exception details to the debug window
                    Debug.WriteLine($"An error occurred during database seeding: {exception.Message}");
                    Debug.WriteLine(exception.StackTrace);

                    // Rollback transaction on error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        });
    }
    #endregion
}
