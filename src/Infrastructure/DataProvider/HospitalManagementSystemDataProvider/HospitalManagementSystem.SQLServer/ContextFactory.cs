namespace HospitalManagementSystem.DataProvider;

public class ContextFactory : IDesignTimeDbContextFactory<HospitalManagementSystemDbContext>
{
    public HospitalManagementSystemDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();

        // Can Use This
        //var connectionString1 = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        //if (string.IsNullOrEmpty(connectionString1))
        //    throw new Exception("The connection string is null or empty");

        // Or This
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("The connection string is null or empty");

        var modelBuilder = SQLDatabaseModelBuilder.Current.GetModel();
        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
        optionsBuilder.UseModel(modelBuilder);
        optionsBuilder.EnableSensitiveDataLogging(false);

        return new HospitalManagementSystemDbContext(optionsBuilder.Options);
    }
}
