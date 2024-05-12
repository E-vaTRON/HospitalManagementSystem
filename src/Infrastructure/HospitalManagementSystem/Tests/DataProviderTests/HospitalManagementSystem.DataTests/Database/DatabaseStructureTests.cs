namespace HospitalManagementSystem.Tests;

public class DatabaseStructureTests
{
    #region [ Fields ]
    protected readonly HospitalManagementSystemDbContext DbContext;
    private readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ CTors ]

    public DatabaseStructureTests()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();
        configuration.GetSection("DatabaseConfiguration").Bind(this.DatabaseConfiguration);

        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>().UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
                                                                                             .EnableSensitiveDataLogging(true);

        if (string.IsNullOrEmpty(DatabaseConfiguration.ConnectionString))
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        else
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

        var options = optionsBuilder.Options;

        DbContext = new HospitalManagementSystemDbContext(options);
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public void DomainDatabaseExists()
    {
        #region [ Arrange ]
        var expected = true;
        #endregion

        #region [ Act ]
        var actual = SqlDatabaseHelper.DatabaseExists(DatabaseConfiguration.ConnectionString);
        #endregion

        #region [ Assert ]
        Assert.Equal(expected, actual);
        #endregion
    }
    #endregion
}
