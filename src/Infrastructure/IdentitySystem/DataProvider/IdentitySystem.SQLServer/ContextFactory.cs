namespace IdentitySystem.DataProvider;

public class ContextFactory : IDesignTimeDbContextFactory<IdentitySystemDbContext>
{
    #region [ Fields ]
    private readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ Factory ]
    public IdentitySystemDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();
        configuration.GetSection("DatabaseConfiguration").Bind(this.DatabaseConfiguration);

        var modelBuilder = SQLDatabaseModelBuilder.SQLModel.GetModel();
        var options = new DbContextOptions<IdentitySystemDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<IdentitySystemDbContext>(options);
        optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString, sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure());
        optionsBuilder.UseModel(modelBuilder);
        optionsBuilder.EnableSensitiveDataLogging(false);

        return new IdentitySystemDbContext(optionsBuilder.Options);
    }
    #endregion
}
