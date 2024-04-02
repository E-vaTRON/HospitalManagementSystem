namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemSqlServerDataProviders(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("DatabaseConfiguration:ConnectionString").Value;
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("The connection string is null or empty");

        var elo = SQLDatabaseModelBuilder.SQLModelBuilder.GetModel();
        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options => {
            options.UseModel(SQLDatabaseModelBuilder.SQLModelBuilder.GetModel());
            options.UseSqlServer(connectionString, 
                                 sqlServerOptionsAction => {sqlServerOptionsAction.EnableRetryOnFailure();});
            options.EnableSensitiveDataLogging();
        });
        //Providers
        services.AddHospitalManagementSystemDataProviders<HospitalManagementSystemDbContext>();
    }
    #endregion
}
