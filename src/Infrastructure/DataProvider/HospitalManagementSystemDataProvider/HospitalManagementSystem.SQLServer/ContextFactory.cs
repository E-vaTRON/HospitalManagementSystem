namespace HospitalManagementSystem.DataProvider;

public class ContextFactory : IDesignTimeDbContextFactory<HospitalManagementSystemDbContext>
{
    public HospitalManagementSystemDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();

        var connectionString = configuration.GetSection("DatabaseConfiguration:ConnectionString").Value;
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("The connection string is null or empty");

        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging(true);

        return new HospitalManagementSystemDbContext(optionsBuilder.Options);
    }
}
