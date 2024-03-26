namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void HospitalManagementSystemSqlServerDataProviders<TDbContext>(this IServiceCollection services, IConfiguration configuration)
        where TDbContext : DbContext
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception($"{connectionString} is null or empty");

        var options = new DbContextOptions<TDbContext>();
        var builder = new DbContextOptionsBuilder<TDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging(false);

        services.AddPooledDbContextFactory<TDbContext>(options => {
            //options.UseModel(HospitalManagementSystemDbContext.Current.GetModel());
            options.UseSqlServer(connectionString, sqlServerOptionsAction => {
                sqlServerOptionsAction.EnableRetryOnFailure();
            });
            options.EnableSensitiveDataLogging();
        });
    }
    #endregion
}
