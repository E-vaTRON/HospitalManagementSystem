namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtension
{
    #region [ Fields ]
    private static readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemSqlServerDataProviders(this IServiceCollection services, IConfiguration configuration)
    {
        ////Can Use This
        //var connectionString = configuration.GetSection("DatabaseConfiguration:HMSConnection").Value;
        //if (string.IsNullOrEmpty(connectionString))
        //    throw new Exception("The connection string is null or empty");

        configuration.GetSection("DatabaseConfiguration").Bind(DatabaseConfiguration);

        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(DatabaseConfiguration.HMSConnection);
        optionsBuilder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options =>
        {
            options.UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel());
            options.UseSqlServer(DatabaseConfiguration.HMSConnection, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
#if DEBUG
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        });

        //Context
        services.AddHospitalManagementSystemDataBaseContextProviders();

        //Providers
        services.AddHospitalManagementSystemSeedDataProviders();
    }
    #endregion
}
