using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.Tests;

public class DatabaseStructureTests
{
    #region [ Fields ]
    private readonly DatabaseConfiguration databaseConfig = new();
    #endregion

    #region [ CTors ]

    public DatabaseStructureTests()
    {
        var configuration = new ConfigurationBuilder()
                                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                                    .Build();
        configuration.GetSection("DatabaseConfiguration").Bind(this.databaseConfig);
    }
    #endregion

    #region [ Methods ]

    [Fact]
    public void DatabaseExists()
    {
        #region [ Arrange ]
        var expected = "Server=DESKTOP-ULLPH77\\SQLEXPRESS;Database=HospitalDataBase;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=True;Trusted_Connection=SSPI;Encrypt=false;";
        #endregion

        #region [ Act ]
        var actual = databaseConfig.ConnectionString;
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
