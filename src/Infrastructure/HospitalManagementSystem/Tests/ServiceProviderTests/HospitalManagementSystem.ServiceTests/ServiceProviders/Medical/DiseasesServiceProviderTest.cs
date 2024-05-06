namespace HospitalManagementSystem.Tests;

public class DiseasesServiceProviderTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<IDiseasesDataProvider> DataProvider;
    protected readonly DiseasesServiceProvider ServiceProvider;
    #endregion

    #region[ CTor ]
    public DiseasesServiceProviderTest()
    {
        DataProvider = Fixture.Freeze<Mock<IDiseasesDataProvider>>();
        ServiceProvider = new DiseasesServiceProvider(DataProvider.Object);
    }
    #endregion

    #region []

    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<Domain.Diseases>()
                            .With(i => i.Id, Guid.NewGuid().ToString())
                            .Create();
        DataProvider.Setup(dp => dp.AddAsync(diseasesAdd, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.AddAsync(diseasesAdd);

        // Assert
        DataProvider.Verify(dp => dp.AddAsync(diseasesAdd, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        //// Arrange
        //var icdAdd = default(Domain.Diseases);

        //// Act
        //var icdProvider = new DiseasesDataProvider(DbContext, Mapper);
        //Task Add() => icdProvider.AddAsync(icdAdd, new());

        //// Assert
        //await Assert.ThrowsAsync<ArgumentNullException>(Add);
        //Assert.True(Add().IsCompleted);
    }
    #endregion

    #endregion

}
