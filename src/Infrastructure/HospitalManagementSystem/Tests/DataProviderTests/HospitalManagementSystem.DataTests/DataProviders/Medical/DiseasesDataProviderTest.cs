namespace HospitalManagementSystem.Tests;

public class DiseasesDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public DiseasesDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]
        
    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<Domain.Diseases>()
                            .With(i => i.Id, Guid.NewGuid().ToString())
                            .Create();

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var add = diseasesProvider.AddAsync(diseasesAdd, new());

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == Guid.Parse(diseasesAdd.Id!));
        Assert.True(add.IsCompletedSuccessfully);
        Assert.Equal(diseasesAdd.Name, result?.Name);
        Assert.Equal(diseasesAdd.Description, result?.Description);
        Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diseasesAdd = default(Domain.Diseases);

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        Task Add() => diseasesProvider.AddAsync(diseasesAdd, new());

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(Add);
        Assert.True(Add().IsCompleted);
    }
    #endregion

    #region [ Update ]
    [Fact]
    public async void UpdateAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diseasesAdd).State = EntityState.Detached;

        var diseasesUpdate = Fixture.Build<Domain.Diseases>()
                               .Without(i => i.IsDeleted)
                               .Without(i => i.Id)
                               .Create();

        diseasesUpdate.Id = diseasesAdd.Id.ToString();

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var update = diseasesProvider.UpdateAsync(diseasesUpdate);

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
        Assert.True(update.IsCompletedSuccessfully);
        Assert.Equal(diseasesUpdate.Name, result?.Name);
        Assert.Equal(diseasesUpdate.Description, result?.Description);
        Assert.Equal(diseasesUpdate.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.Diseases.AddRangeAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diseasesAdd).State = EntityState.Detached;

        var diseasesUpdate = this.Fixture.Create<Domain.Diseases>();

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var update = diseasesProvider.UpdateAsync(diseasesUpdate);

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
        Assert.True(update.IsCompleted);
        Assert.Equal(diseasesAdd.Name, result?.Name);
        Assert.Equal(diseasesAdd.Description, result?.Description);
        Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.Diseases.AddRangeAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();

        var diseasesUpdate = default(Domain.Diseases);

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        async Task Result() => await diseasesProvider.UpdateAsync(diseasesUpdate);

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
        await Assert.ThrowsAsync<ArgumentNullException>(Result);
        Assert.Equal(diseasesAdd.Name, result?.Name);
        Assert.Equal(diseasesAdd.Description, result?.Description);
        Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await base.DbContext.Diseases.AddAsync(diseasesAdd);
        await base.DbContext.SaveChangesAsync();
        DbContext.Entry(diseasesAdd).State = EntityState.Detached;

        // Act
        var diseasesProvider = new DiseasesDataProvider(base.DbContext, Mapper);
        await diseasesProvider.DeleteByIdAsync(diseasesAdd.Id.ToString(), new());

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    {
        // Arrange
        var id = new Guid();

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        await diseasesProvider.DeleteByIdAsync(id.ToString());

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }

    [Fact]
    public async void DeleteByIdAsync_NotFound()
    {
        // Arrange
        var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diseasesAdd).State = EntityState.Detached;

        var id = this.Fixture.Create<Guid>();

        // Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        await diseasesProvider.DeleteByIdAsync(diseasesAdd.Id.ToString());

        // Assert 
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }
    #endregion

    #region [ Get ]
    [Fact]
    public async void FindAll()
    {
        //Arrange
        List<DataProvider.Diseases> icdList = Fixture.Build<DataProvider.Diseases>()
                                                .CreateMany().ToList();

        await DbContext.Diseases.AddRangeAsync(icdList.ToArray());
        await DbContext.SaveChangesAsync();

        //Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var resultList = await diseasesProvider.FindAllAsync();

        //Assert
        Assert.Equal(3, resultList.Count());

        // Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var icd = icdList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(icd.Name, result.Name);
            Assert.Equal(icd.Description, result.Description);
            Assert.Equal(icd.Status.ToString(), result.Status.ToString());
        };
    }

    [Fact]
    public async void FindAll_NotFound()
    {
        //Arrange
        // Nothing here
        await DbContext.SaveChangesAsync();

        var icdIds = DbContext.Diseases.Select(x => x.Id).ToList();

        //Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var resultList = await diseasesProvider.FindAllAsync();

        //Assert
        //Assert.True(!resultList.Any());
        Assert.Empty(resultList);
    }

    [Fact]
    public async void FindByIdAsync_DisableQuickFind()
    {
        //Arrange
        var icd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        await DbContext.Diseases.AddAsync(icd);
        await DbContext.SaveChangesAsync();

        //Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var result = await diseasesProvider.FindByIdAsync(icd.Id.ToString(), new(), false);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(icd.Name, result.Name);
        Assert.Equal(icd.Description, result.Description);
        Assert.Equal(icd.Status.ToString(), result.Status.ToString());
    }

    [Fact]
    public async void FindByIdAsync_NotExit()
    {
        //Arrange
        var icd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        await DbContext.Diseases.AddAsync(icd);
        await DbContext.SaveChangesAsync();

        //Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        var result = await diseasesProvider.FindByIdAsync(Guid.NewGuid().ToString(), new(), false);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void FindByIdAsync_IdIsNullOrEmpty_Exception()
    {
        //Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                            .With(i => i.Id, Guid.NewGuid())
                            .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diseasesAdd).State = EntityState.Detached;

        //Act
        var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
        async Task NullResult() => await diseasesProvider.FindByIdAsync(null);
        async Task EmptyResult() => await diseasesProvider.FindByIdAsync(string.Empty);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentException>(EmptyResult);
    }
    #endregion

    #endregion
}
