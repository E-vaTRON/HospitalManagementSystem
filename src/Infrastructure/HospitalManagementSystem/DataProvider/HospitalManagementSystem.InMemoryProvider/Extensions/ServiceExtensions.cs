namespace HospitalManagementSystem.DataProvider;

public static class ServiceExtensions
{
    #region [ Public Methods - Add ]

    public static void AddHospitalManagementSystemInMemoryDataProviders(this IServiceCollection services, string databaseName = "HospitalDataBase") 
    {
        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);

        services.AddPooledDbContextFactory<HospitalManagementSystemDbContext>(options => {
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
        services.AddTransient<HospitalManagementSystemDbContext>(p => p.GetRequiredService<IDbContextFactory<HospitalManagementSystemDbContext>>()
                                                                       .CreateDbContext());

        //Providers
        services.AddHospitalManagementSystemSeedDataProviders();

    }
    #endregion
}