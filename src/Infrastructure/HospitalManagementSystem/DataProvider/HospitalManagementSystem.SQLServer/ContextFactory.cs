namespace HospitalManagementSystem.DataProvider;

public class ContextFactory : IDesignTimeDbContextFactory<HospitalManagementSystemDbContext>
{
    #region [ Fields ]
    private readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ Factory ]
    public HospitalManagementSystemDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();

        configuration.GetSection("DatabaseConfiguration").Bind(this.DatabaseConfiguration);

        var modelBuilder = SQLDatabaseModelBuilder.SQLModel.GetModel();
        var options = new DbContextOptions<HospitalManagementSystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>(options);
        optionsBuilder.UseSqlServer(DatabaseConfiguration.HMSConnection, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
        optionsBuilder.UseModel(modelBuilder);
        optionsBuilder.EnableSensitiveDataLogging(false);

        return new HospitalManagementSystemDbContext(optionsBuilder.Options);
    }
    #endregion
}
