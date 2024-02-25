namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddWave5AcademyExamsSqlServerDataProviders(this IServiceCollection services,
        IConfiguration configuration,
        bool usedInWebApp = false)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception($"{connectionString} is null or empty");

        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var builder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options => {
            //options.UseModel(HospitalManagementSystemDbContext.Current.GetModel());
            options.UseSqlServer(connectionString, sqlServerOptionsAction => {
                sqlServerOptionsAction.EnableRetryOnFailure();
            });
            options.EnableSensitiveDataLogging();
        });

        // Providers
        services.HospitalManagementSystemDataBaseContextProviders<HospitalManagementSystemDbContext>();
    }
    #endregion
}
