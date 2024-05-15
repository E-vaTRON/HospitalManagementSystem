namespace IdentitySystem.DataProvider;

public static class ServiceExtensions
{
    #region [ Public Methods - Add ]

    public static void AddHospitalManagementSystemInMemoryDataProviders(this IServiceCollection services,string databaseName = "HospitalDataBase") 
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

        //Providers
        services.AddIdentitySystemDataProviders();

    }
    #endregion
}