using Microsoft.AspNetCore.Identity;

namespace IdentitySystem.DataProvider;

public class SeedServiceProvider : ISeedProvider
{
    #region [ Fields ]
    protected readonly IServiceProvider ServiceProvider;
    private readonly DataContext DataContexts;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedServiceProvider( IServiceProvider serviceProvider, 
                                DataContext dataContexts,
                                IDbContextFactory<IdentitySystemDbContext> dbContextFactory)
    {
        ServiceProvider = serviceProvider;
        DataContexts = dataContexts;
        DbContext = dbContextFactory.CreateDbContext();
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
        DbContext.RemoveRange(await this.DataContexts.Users.FindAll().ToListAsync());
        DbContext.RemoveRange(await this.DataContexts.Roles.FindAll().ToListAsync());

        DbContext.RemoveRange(await this.DataContexts.UserRoles.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.UserClaims.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.UserTokens.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.UserLogins.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.Specializations.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.UserSpecializations.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.Notifications.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.ScheduleSlots.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.ScheduleDays.FindAllAsync());
    }

    public async Task SeedDatabaseAsync()
    {
        await DataContexts.Users.SeedIdentityAsync(SeedProvider.Seed.Users);
        await DataContexts.Roles.SeedIdentityAsync(SeedProvider.Seed.Roles);

        await DataContexts.UserRoles.SeedAsync(SeedProvider.Seed.UserRoles);
        await DataContexts.UserClaims.SeedAsync(SeedProvider.Seed.UserClaims);
        await DataContexts.UserTokens.SeedAsync(SeedProvider.Seed.UserTokens);
        await DataContexts.UserLogins.SeedAsync(SeedProvider.Seed.UserLogins);

        await DataContexts.Specializations.SeedAsync(SeedProvider.Seed.Specializations);
        await DataContexts.UserSpecializations.SeedAsync(SeedProvider.Seed.UserSpecializations);
    }
    #endregion
}
