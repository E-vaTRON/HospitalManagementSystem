namespace HospitalManagementSystem.Tests;

public class ICDDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public ICDDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]

    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var icdAdd = Fixture.Build<Domain.Diseases>()
                            .With(i => i.Id, Guid.NewGuid().ToString())
                            .Create();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var add = icdProvider.AddAsync(icdAdd, new());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == Guid.Parse(icdAdd.Id!));
        Assert.True(add.IsCompletedSuccessfully);
        Assert.Equal(icdAdd.Name, result?.Code);
        Assert.Equal(icdAdd.Description, result?.Description);
        Assert.Equal(icdAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var icdAdd = default(Domain.Diseases);

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        Task Add() => icdProvider.AddAsync(icdAdd, new());

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
        var icdAdd = Fixture.Build<DataProvider.Diseases>()
                            .Create();

        await DbContext.ICDs.AddAsync(icdAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        var icdUpdate = Fixture.Build<Domain.Diseases>()
                               .Without(i => i.IsDeleted)
                               .Without(i => i.Id)
                               .Create();

        icdUpdate.Id = icdAdd.Id.ToString();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var update = icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icdAdd.Id);
        Assert.True(update.IsCompletedSuccessfully);
        Assert.Equal(icdUpdate.Name, result?.Code);
        Assert.Equal(icdUpdate.Description, result?.Description);
        Assert.Equal(icdUpdate.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var icdAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.ICDs.AddRangeAsync(icdAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        var icdUpdate = this.Fixture.Create<Domain.Diseases>();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var update = icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icdAdd.Id);
        Assert.True(update.IsCompleted);
        Assert.Equal(icdAdd.Code, result?.Code);
        Assert.Equal(icdAdd.Description, result?.Description);
        Assert.Equal(icdAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var icdAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.ICDs.AddRangeAsync(icdAdd);
        await DbContext.SaveChangesAsync();

        var icdUpdate = default(Domain.Diseases);

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        async Task Result() => await icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icdAdd.Id);
        await Assert.ThrowsAsync<ArgumentNullException>(Result);
        Assert.Equal(icdAdd.Code, result?.Code);
        Assert.Equal(icdAdd.Description, result?.Description);
        Assert.Equal(icdAdd.Status.ToString(), result?.Status.ToString());
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        var icdAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await base.DbContext.ICDs.AddAsync(icdAdd);
        await base.DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        // Act
        var icdProvider = new ICDDataProvider(base.DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(icdAdd.Id.ToString(), new());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icdAdd.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    {
        // Arrange
        var id = new Guid();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(id.ToString());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }

    [Fact]
    public async void DeleteByIdAsync_NotFound()
    {
        // Arrange
        var icdAdd = this.Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        await DbContext.ICDs.AddAsync(icdAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        var id = this.Fixture.Create<Guid>();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(icdAdd.Id.ToString());

        // Assert 
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == id);
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

        await DbContext.ICDs.AddRangeAsync(icdList.ToArray());
        await DbContext.SaveChangesAsync();

        //Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var resultList = await icdProvider.FindAllAsync();

        //Assert
        Assert.Equal(3, resultList.Count());

        // Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var icd = icdList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(icd.Code, result.Name);
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

        var icdIds = DbContext.ICDs.Select(x => x.Id).ToList();

        //Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var resultList = await icdProvider.FindAllAsync();

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

        await DbContext.ICDs.AddAsync(icd);
        await DbContext.SaveChangesAsync();

        //Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var result = await icdProvider.FindByIdAsync(icd.Id.ToString(), new(), false);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(icd.Code, result.Name);
        Assert.Equal(icd.Description, result.Description);
        Assert.Equal(icd.Status.ToString(), result.Status.ToString());
    }

    [Fact]
    public async void FindByIdAsync_NotExit()
    {
        //Arrange
        var icd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        await DbContext.ICDs.AddAsync(icd);
        await DbContext.SaveChangesAsync();

        //Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var result = await icdProvider.FindByIdAsync(Guid.NewGuid().ToString(), new(), false);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void FindByIdAsync_IdIsNullOrEmpty_Exception()
    {
        //Arrange
        var icdAdd = Fixture.Build<DataProvider.Diseases>()
                            .With(i => i.Id, Guid.NewGuid())
                            .Create();

        await DbContext.ICDs.AddAsync(icdAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        //Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        async Task NullResult() => await icdProvider.FindByIdAsync(null);
        async Task EmptyResult() => await icdProvider.FindByIdAsync(string.Empty);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentException>(EmptyResult);
    }
    #endregion

    #endregion
}
