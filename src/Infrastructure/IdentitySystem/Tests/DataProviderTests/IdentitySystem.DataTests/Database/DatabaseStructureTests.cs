namespace IdentitySystem.Tests;

public class DatabaseStructureTests
{
    #region [ Fields ]
    protected readonly IdentitySystemDbContext DbContext;
    private readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ CTors ]

    public DatabaseStructureTests()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();
        configuration.GetSection("DatabaseConfiguration").Bind(this.DatabaseConfiguration);

        var optionsBuilder = new DbContextOptionsBuilder<IdentitySystemDbContext>().UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
                                                                                             .EnableSensitiveDataLogging(true);

        if (string.IsNullOrEmpty(DatabaseConfiguration.ConnectionString))
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        else
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

        var options = optionsBuilder.Options;

        DbContext = new IdentitySystemDbContext(options);
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public void DomainDatabaseExists()
    {
        #region [ Arrange ]
        //var expected = true;
        var contextFactory = new ContextFactory();
        #endregion

        #region [ Act ]
        var actual = contextFactory.CreateDbContext(new string[] { });
        #endregion

        #region [ Assert ]
        //Assert.Equal(expected, actual);
        #endregion
     }
    #endregion
}
