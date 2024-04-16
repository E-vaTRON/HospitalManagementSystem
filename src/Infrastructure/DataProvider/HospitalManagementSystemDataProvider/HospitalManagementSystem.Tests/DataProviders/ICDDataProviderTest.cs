namespace HospitalManagementSystem.Tests;

public class ICDDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public ICDDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var icd = this.Fixture.Create<Domain.ICD>();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        //async Task Result() => 
            await icdProvider.AddAsync(icd, new());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync();
        //Assert.True(Result().IsCompletedSuccessfully);
        Assert.Equal(icd.Code, result?.Code);
        Assert.Equal(icd.Description, result?.Description);
        Assert.Equal(icd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var icd = default(Domain.ICD);

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        async Task Result() => await icdProvider.AddAsync(icd, new());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync();
        await Assert.ThrowsAsync<ArgumentNullException>(Result);
        Assert.Null(result);
    }

    [Fact]
    public async void UpdateAsync_Success()
    {
        // Arrange
        //var icdAdd = this.Fixture.Create<ICD>();

        ICD icdAdd = new()
        {
            Code = "Code",
            Description = "Description",
            Status = CodeStatus.Active
        };

        await DbContext.ICDs.AddRangeAsync(icdAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(icdAdd).State = EntityState.Detached;

        //var icdUpdate = this.Fixture.Create<Domain.ICD>();

        Domain.ICD icdUpdate = new()
        {
            Code = "CodeUp",
            Description = "DescriptionUp",
            Status = Domain.CodeStatus.Active
        };
        icdUpdate.Id = icdAdd.Id.ToString();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        //async Task Result() =>
        await icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync();
        //Assert.True(Result().IsCompletedSuccessfully);
        Assert.Equal(icdUpdate.Code, result?.Code);
        Assert.Equal(icdUpdate.Description, result?.Description);
        Assert.Equal(icdUpdate.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var icdAdd = this.Fixture.Create<ICD>();

        await DbContext.ICDs.AddRangeAsync(icdAdd);
        await DbContext.SaveChangesAsync();

        var icdUpdate = this.Fixture.Create<Domain.ICD>();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        await icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync();
        Assert.Equal(icdAdd.Code, result?.Code);
        Assert.Equal(icdAdd.Description, result?.Description);
        Assert.Equal(icdAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var icdAdd = this.Fixture.Create<ICD>();

        await DbContext.ICDs.AddRangeAsync(icdAdd);
        await DbContext.SaveChangesAsync();

        var icdUpdate = default(Domain.ICD);

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        async Task Result() => await icdProvider.UpdateAsync(icdUpdate);

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync();
        await Assert.ThrowsAsync<ArgumentNullException>(Result);
        Assert.Equal(icdAdd.Code, result?.Code);
        Assert.Equal(icdAdd.Description, result?.Description);
        Assert.Equal(icdAdd.Status.ToString(), result?.Status.ToString());
    }

    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        //var icdAdd = this.Fixture.Create<ICD>();
        ICD icd = new()
        {
            Code = "Code",
            Description = "Description",
            Status = CodeStatus.Active
        };
        await base.DbContext.ICDs.AddAsync(icd);
        await base.DbContext.SaveChangesAsync();
        DbContext.Entry(icd).State = EntityState.Detached;

        // Act
        var icdProvider = new ICDDataProvider(base.DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(icd.Id.ToString(), new());

        // Assert
        var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icd.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    {
        // Arrange
        var id = string.Empty;

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(id);

        // Assert
    }

    [Fact]
    public async void DeleteByIdAsync_NotFound()
    {
        // Arrange
        var icdAdd = this.Fixture.Create<ICD>();

        await DbContext.ICDs.AddAsync(icdAdd);
        await DbContext.SaveChangesAsync();

        var id = this.Fixture.Create<Guid>().ToString();

        // Act
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(icdAdd.Id.ToString());

        // Assert
    }

    [Fact]
    public async void FindAll()
    {
        #region [ Arrange ]

        List<ICD> icdList = Fixture.Create<List<ICD>>();

        await DbContext.ICDs.AddRangeAsync(icdList);
        await DbContext.SaveChangesAsync();

        var icdIds = DbContext.ICDs.Select(x => x.Id).ToList();
        #endregion

        #region [ Act ]
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var resultList = await icdProvider.FindAllAsync();
        #endregion

        #region [ Assert ]
        Assert.Equal(3, resultList.Count());

        // Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var icd = icdList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(icd.Code, result.Code);
            Assert.Equal(icd.Description, result.Description);
            Assert.Equal(icd.Status.ToString(), result.Status.ToString());
        };
        #endregion
    }

    [Fact]
    public async void FindAll_NotFound()
    {
        #region [ Arrange ]
        // Nothing here
        await DbContext.SaveChangesAsync();

        var icdIds = DbContext.ICDs.Select(x => x.Id).ToList();
        #endregion

        #region [ Act ]
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var resultList = await icdProvider.FindAllAsync();
        #endregion

        #region [ Assert ]
        //Assert.True(!resultList.Any());
        Assert.Empty(resultList);
        #endregion
    }

    [Fact]
    public async void FindByIdAsync_DisableQuickFind()
    {
        #region [ Arrange ]
        ICD icd = Fixture.Create<ICD>();

        await DbContext.ICDs.AddAsync(icd);
        await DbContext.SaveChangesAsync();
        #endregion

        #region [ Act ]
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var result = await icdProvider.FindByIdAsync(icd.Id.ToString(), new(), false);
        #endregion

        #region [ Assert ]
        Assert.NotNull(result);
        Assert.Equal(icd.Code, result.Code);
        Assert.Equal(icd.Description, result.Description);
        Assert.Equal(icd.Status.ToString(), result.Status.ToString());
        #endregion
    }

    [Fact]
    public async void FindByIdAsync_NotExit()
    {
        #region [ Arrange ]
        ICD icd = Fixture.Create<ICD>();

        await DbContext.ICDs.AddAsync(icd);
        await DbContext.SaveChangesAsync();
        #endregion

        #region [ Act ]
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        var result = await icdProvider.FindByIdAsync(Guid.NewGuid().ToString(), new(), false);
        #endregion

        #region [ Assert ]
        Assert.Null(result);
        #endregion
    }

    [Fact]
    public async void FindByIdAsync_IdIsNullOrEmpty_Exception()
    {
        #region [ Arrange ]
        ICD icd = Fixture.Create<ICD>();

        await DbContext.ICDs.AddAsync(icd);
        await DbContext.SaveChangesAsync();
        #endregion

        #region [ Act ]
        var icdProvider = new ICDDataProvider(DbContext, Mapper);
        async Task NullResult() => await icdProvider.FindByIdAsync(null);
        async Task EmptyResult() => await icdProvider.FindByIdAsync(string.Empty);
        #endregion

        #region [ Assert ]
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentNullException>(EmptyResult);
        #endregion
    }
    #endregion
}
