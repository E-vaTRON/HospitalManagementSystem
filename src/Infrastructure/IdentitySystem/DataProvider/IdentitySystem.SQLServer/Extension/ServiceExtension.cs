namespace IdentitySystem.DataProvider;

public static class ServiceExtension
{
    #region [ Fields ]
    private static readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ Public Methods - Add ]
    public static void AddIdentitySystemSqlServerDataProviders(this IServiceCollection services, IConfiguration configuration)
    {
        // Can Use This
        //var connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        //if (string.IsNullOrEmpty(connectionString))
        //    throw new Exception("The connection string is null or empty");

        configuration.GetSection("DatabaseConfiguration").Bind(DatabaseConfiguration);

        var options = new DbContextOptions<IdentitySystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<IdentitySystemDbContext>(options);
        optionsBuilder.UseSqlServer(DatabaseConfiguration.ISConnection);
        optionsBuilder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<IdentitySystemDbContext>(options =>
        {
            options.UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel());
            options.UseSqlServer(DatabaseConfiguration.ISConnection, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
#if DEBUG
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        });

        //Context
        services.AddIdentitySystemDataBaseContextProviders();

        //Providers
        services.AddIdentitySystemSeedDataProviders();
    }
    #endregion
}
