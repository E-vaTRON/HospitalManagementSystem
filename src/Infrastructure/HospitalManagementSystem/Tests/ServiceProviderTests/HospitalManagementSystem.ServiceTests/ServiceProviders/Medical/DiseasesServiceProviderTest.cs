using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        //Arrange
        var diseasesAdd = default(Domain.Diseases);
        DataProvider.Setup(dp => dp.AddAsync(It.IsAny<Domain.Diseases>(), It.IsAny<CancellationToken>())).Throws<Exception>();

        //Act
        var add = async () => await ServiceProvider.AddAsync(diseasesAdd);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(add);
        Assert.True(add().IsCompleted);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<Domain.Diseases>()
                                 .With(i => i.Id, Guid.NewGuid().ToString())
                                 .Create();

        var diseasesUpdate = Fixture.Build<Domain.Diseases>()
                                    .With(i => i.Id, diseasesAdd.Id)
                                    .Create();

        DataProvider.Setup(x => x.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.UpdateAsync(diseasesUpdate);

        // Assert
        DataProvider.Verify(dp => dp.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>()), Times.Once());
    }
    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var diseasesUpdate = Fixture.Build<Domain.Diseases>()
                                    .With(i => i.Id, Guid.NewGuid().ToString())
                                    .Create();

        DataProvider.Setup(x => x.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.UpdateAsync(diseasesUpdate);

        // Assert
        DataProvider.Verify(dp => dp.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>()), Times.Once());
        Assert.Null(diseasesUpdate.Id);
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diseasesUpdate = default(Domain.Diseases);

        DataProvider.Setup(x => x.UpdateAsync(It.IsAny<Domain.Diseases>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var update = async () => await ServiceProvider.UpdateAsync(diseasesUpdate);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(update);
        Assert.True(update().IsCompleted);
    }
    #endregion

    #endregion

}
