namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Fields ]
    private static readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemSqlServerDataProviders(this IServiceCollection services, IConfiguration configuration)
    {
        // Can Use This
        //var connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        //if (string.IsNullOrEmpty(connectionString))
        //    throw new Exception("The connection string is null or empty");

        configuration.GetSection("DatabaseConfiguration").Bind(DatabaseConfiguration);

        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        optionsBuilder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options =>
        {
            options.UseModel(SQLDatabaseModelBuilder.Current.GetModel());
            options.UseSqlServer(DatabaseConfiguration.ConnectionString, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
            options.EnableSensitiveDataLogging(false);
        });

        //Context
        services.AddHospitalManagementSystemDataBaseContextProviders<HospitalManagementSystemDbContext>();

        //Providers
        services.AddHospitalManagementSystemDataProviders<HospitalManagementSystemDbContext>();
    }
    #endregion
}
