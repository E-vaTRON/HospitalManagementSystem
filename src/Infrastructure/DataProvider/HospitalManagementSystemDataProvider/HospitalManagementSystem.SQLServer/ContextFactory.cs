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

        var modelBuilder = SQLDatabaseModelBuilder.SQLModelBuilder.GetModel();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseModel(modelBuilder);
        optionsBuilder.EnableSensitiveDataLogging(true);

        return new HospitalManagementSystemDbContext(optionsBuilder.Options);
    }
}
