namespace HospitalManagementSystem.Tests;

public class DatabaseStructureTests
{
    #region [ Fields ]
    private readonly DatabaseConfiguration DatabaseConfiguration = new();
    #endregion

    #region [ CTors ]

    public DatabaseStructureTests()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                                      .Build();
        configuration.GetSection("DatabaseConfiguration").Bind(this.DatabaseConfiguration);
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

    [Fact]
    public void TestCreateDbContext()
    {
        // Arrange

        // Act

        // Assert
        // Add your assertions here
    }
    #endregion
}
