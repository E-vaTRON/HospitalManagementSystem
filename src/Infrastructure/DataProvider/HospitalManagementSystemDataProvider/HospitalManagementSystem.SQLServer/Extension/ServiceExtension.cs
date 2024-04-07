namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemSqlServerDataProviders(this IServiceCollection services, IConfiguration configuration)
    {
        // Can Use This
        //var connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        //if (string.IsNullOrEmpty(connectionString))
        //    throw new Exception("The connection string is null or empty");

        // Or This
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("The connection string is null or empty");

        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options =>
        {
            options.UseModel(SQLDatabaseModelBuilder.Current.GetModel());
            options.UseSqlServer(connectionString, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
            options.EnableSensitiveDataLogging(false);
        });

        //Context
        services.AddHospitalManagementSystemDataBaseContextProviders<HospitalManagementSystemDbContext>();

        //Providers
        services.AddHospitalManagementSystemDataProviders<HospitalManagementSystemDbContext>();
    }
    #endregion
}
