namespace IdentitySystem.DataProvider;

public static class ServiceExtensions
{
    #region [ Public Methods - Add ]

    public static void AddIdentitySystemInMemoryDataProviders(this IServiceCollection services,string databaseName = "HospitalIdentityDataBase") 
    {
        var options = new DbContextOptions<IdentitySystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<IdentitySystemDbContext>(options);

        services.AddPooledDbContextFactory<IdentitySystemDbContext>(options => {
            options.UseModel(SQLiteDatabaseModelBuilder.SQLiteModel.GetModel());
            options.UseInMemoryDatabase(databaseName, (o) => {
                o.EnableNullChecks(false);
            });
#if DEBUG
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif

        });
        //Context
        services.AddTransient<IdentitySystemDbContext>(p => p.GetRequiredService<IDbContextFactory<IdentitySystemDbContext>>()
                                                             .CreateDbContext());
        //services.AddDbContext<IdentitySystemDbContext>((serviceProvider, optionsBuilder) =>
        //{
        //    optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        //    optionsBuilder.UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
        //                  .EnableSensitiveDataLogging(true)
        //                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //}, ServiceLifetime.Singleton);

        //Providers
        services.AddIdentitySystemDataProviders();
        services.AddIdentitySystemSeedDataProviders();

    }
    #endregion
}