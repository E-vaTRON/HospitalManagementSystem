namespace HospitalManagementSystem.Tests;

public class DiseasesServiceProviderTest : ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly Mock<IDiseasesDataProvider> DataProvider;
    protected readonly IDiseasesServiceProvider ServiceProvider;
    #endregion

    #region[ CTor ]
    public DiseasesServiceProviderTest()
    {
        DataProvider = Fixture.Freeze<Mock<IDiseasesDataProvider>>();
        ServiceProvider = new DiseasesServiceProvider(DataProvider.Object, Mapper);
    }
    #endregion

    #region []

    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var diseasesDtoAdd = Fixture.Build<DiseasesDTO>()
                                 .With(i => i.Id, Guid.NewGuid().ToString())
                                 .Create();
        var diseasesAdd = Mapper.Map<Domain.Diseases>(diseasesDtoAdd);
        DataProvider.Setup(dp => dp.AddAsync(diseasesAdd, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.AddAsync(diseasesDtoAdd);

        // Assert
        DataProvider.Verify(dp => dp.AddAsync(diseasesAdd, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        //Arrange
        var diseasesDtoAdd = default(DiseasesDTO);
        var diseasesAdd = Mapper.Map<Domain.Diseases>(diseasesDtoAdd);
        DataProvider.Setup(dp => dp.AddAsync(It.IsAny<Domain.Diseases>(), It.IsAny<CancellationToken>())).Throws<Exception>();

        //Act
        var add = async () => await ServiceProvider.AddAsync(diseasesDtoAdd);

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
        var diseasesDtoAdd = Fixture.Build<DiseasesDTO>()
                                    .With(i => i.Id, Guid.NewGuid().ToString())
                                    .Create();

        var diseasesDtoUpdate = Fixture.Build<DiseasesDTO>()
                                    .With(i => i.Id, diseasesDtoAdd.Id)
                                    .Create();
        var diseasesUpdate = Mapper.Map<Domain.Diseases>(diseasesDtoUpdate);
        DataProvider.Setup(x => x.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.UpdateAsync(diseasesDtoUpdate);

        // Assert
        DataProvider.Verify(dp => dp.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>()), Times.Once());
    }
    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var diseasesDtoUpdate = Fixture.Build<DiseasesDTO>()
                                       .With(i => i.Id, Guid.NewGuid().ToString())
                                       .Create();
        var diseasesUpdate = Mapper.Map<Domain.Diseases>(diseasesDtoUpdate);
        DataProvider.Setup(x => x.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await ServiceProvider.UpdateAsync(diseasesDtoUpdate);

        // Assert
        DataProvider.Verify(dp => dp.UpdateAsync(diseasesUpdate, It.IsAny<CancellationToken>()), Times.Once());
        Assert.Null(diseasesUpdate.Id);
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diseasesDtoUpdate = default(DiseasesDTO);
        var diseasesUpdate = Mapper.Map<Domain.Diseases>(diseasesDtoUpdate);
        DataProvider.Setup(x => x.UpdateAsync(It.IsAny<Domain.Diseases>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var update = async () => await ServiceProvider.UpdateAsync(diseasesDtoUpdate);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(update);
        Assert.True(update().IsCompleted);
    }
    #endregion

    #endregion

}
