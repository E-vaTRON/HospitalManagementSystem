﻿namespace HospitalManagementSystem.Tests;

public class MedicalServiceDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public MedicalServiceDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]
        
    //#region [ Add ]
    //[Fact]
    //public async void AddAsync_Success()
    //{
    //    // Arrange
    //    var diseasesAdd = Fixture.Build<Domain.Diseases>()
    //                             .With(i => i.Id, Guid.NewGuid().ToString())
    //                             .Create();

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    var add = diseasesProvider.AddAsync(diseasesAdd, new());

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == Guid.Parse(diseasesAdd.Id!));
    //    Assert.True(add.IsCompletedSuccessfully);
    //    Assert.Equal(diseasesAdd.Name, result?.Name);
    //    Assert.Equal(diseasesAdd.Description, result?.Description);
    //    Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    //}

    //[Fact]
    //public async void AddAsync_EntityIsNull_Exception()
    //{
    //    // Arrange
    //    var diseasesAdd = default(Domain.Diseases);

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    Task Add() => diseasesProvider.AddAsync(diseasesAdd, new());

    //    // Assert
    //    await Assert.ThrowsAsync<ArgumentNullException>(Add);
    //    Assert.True(Add().IsCompleted);
    //}
    //#endregion

    //#region [ Update ]
    //[Fact]
    //public async void UpdateAsync_Success()
    //{
    //    // Arrange
    //    var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
    //                             .Create();

    //    await DbContext.Diseases.AddAsync(diseasesAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(diseasesAdd).State = EntityState.Detached;

    //    var diseasesUpdate = Fixture.Build<Domain.Diseases>()
    //                           .Without(i => i.IsDeleted)
    //                           .Without(i => i.Id)
    //                           .Create();

    //    diseasesUpdate.Id = diseasesAdd.Id.ToString();

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    var update = diseasesProvider.UpdateAsync(diseasesUpdate);

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
    //    Assert.True(update.IsCompletedSuccessfully);
    //    Assert.Equal(diseasesUpdate.Name, result?.Name);
    //    Assert.Equal(diseasesUpdate.Description, result?.Description);
    //    Assert.Equal(diseasesUpdate.Status.ToString(), result?.Status.ToString());
    //}

    //[Fact]
    //public async void UpdateAsync_NotFound_Exception()
    //{
    //    // Arrange
    //    var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
    //                             .Create();

    //    await DbContext.Diseases.AddRangeAsync(diseasesAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(diseasesAdd).State = EntityState.Detached;

    //    var diseasesUpdate = this.Fixture.Create<Domain.Diseases>();

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    var update = diseasesProvider.UpdateAsync(diseasesUpdate);

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
    //    Assert.True(update.IsCompleted);
    //    Assert.Equal(diseasesAdd.Name, result?.Name);
    //    Assert.Equal(diseasesAdd.Description, result?.Description);
    //    Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    //}

    //[Fact]
    //public async void UpdateAsync_EntityIsNull_Exception()
    //{
    //    // Arrange
    //    var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
    //                             .Create();

    //    await DbContext.Diseases.AddRangeAsync(diseasesAdd);
    //    await DbContext.SaveChangesAsync();

    //    var diseasesUpdate = default(Domain.Diseases);

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    async Task Result() => await diseasesProvider.UpdateAsync(diseasesUpdate);

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
    //    await Assert.ThrowsAsync<ArgumentNullException>(Result);
    //    Assert.Equal(diseasesAdd.Name, result?.Name);
    //    Assert.Equal(diseasesAdd.Description, result?.Description);
    //    Assert.Equal(diseasesAdd.Status.ToString(), result?.Status.ToString());
    //}
    //#endregion

    //#region [ Delete ]
    //[Fact]
    //public async void DeleteByIdAsync_Success()
    //{
    //    // Arrange
    //    var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
    //                             .Create();

    //    await base.DbContext.Diseases.AddAsync(diseasesAdd);
    //    await base.DbContext.SaveChangesAsync();
    //    DbContext.Entry(diseasesAdd).State = EntityState.Detached;

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(base.DbContext, Mapper);
    //    await diseasesProvider.DeleteByIdAsync(diseasesAdd.Id.ToString(), new());

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == diseasesAdd.Id);
    //    Assert.Null(result);
    //}

    //[Fact]
    //public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    //{
    //    // Arrange
    //    var id = new Guid();

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    await diseasesProvider.DeleteByIdAsync(id.ToString());

    //    // Assert
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
    //    Assert.Null(result);
    //}

    //[Fact]
    //public async void DeleteByIdAsync_NotFound()
    //{
    //    // Arrange
    //    var diseasesAdd = this.Fixture.Build<DataProvider.Diseases>()
    //                             .Create();

    //    await DbContext.Diseases.AddAsync(diseasesAdd);
    //    await DbContext.SaveChangesAsync();
    //    DbContext.Entry(diseasesAdd).State = EntityState.Detached;

    //    var id = this.Fixture.Create<Guid>();

    //    // Act
    //    var diseasesProvider = new DiseasesDataProvider(DbContext, Mapper);
    //    await diseasesProvider.DeleteByIdAsync(diseasesAdd.Id.ToString());

    //    // Assert 
    //    var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
    //    Assert.Null(result);
    //}
    //#endregion

    #region [ Get ]
    [Fact]
    public async void FindAll()
    {
        //Arrange
        var medicalServiceList = Fixture.Build<DataProvider.MedicalService>()
                             .CreateMany().ToList();

        await DbContext.MedicalServices.AddRangeAsync(medicalServiceList.ToArray());
        await DbContext.SaveChangesAsync();

        //Act
        var medicalServicesProvider = new MedicalServiceDataProvider(DbContext, Mapper);
        var resultList = await medicalServicesProvider.FindAllAsync();

        //Assert
        Assert.Equal(3, resultList.Count());

        // Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var icd = medicalServiceList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(icd.Name, result.Name);
        };
    }

    [Fact]
    public async void FindAll_NotFound()
    {
        //Arrange
        // Nothing here
        await DbContext.SaveChangesAsync();

        var medicalServices = DbContext.MedicalServices.Select(x => x.Id).ToList();

        //Act
        var medicalServicesProvider = new MedicalServiceDataProvider(DbContext, Mapper);
        var resultList = await medicalServicesProvider.FindAllAsync();

        //Assert
        //Assert.True(!resultList.Any());
        Assert.Empty(resultList);
    }

    [Fact]
    public async void FindByIdAsync_DisableQuickFind()
    {
        //Arrange
        var medicalService = Fixture.Build<DataProvider.MedicalService>()
                                    .Create();

        await DbContext.MedicalServices.AddAsync(medicalService);
        await DbContext.SaveChangesAsync();

        //Act
        var medicalServiceProvider = new MedicalServiceDataProvider(DbContext, Mapper);
        var result = await medicalServiceProvider.FindByIdAsync(medicalService.Id.ToString(), new(), false);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(medicalService.Name, result.Name);
    }

    [Fact]
    public async void FindByIdAsync_NotExit()
    {
        //Arrange
        var medicalService = Fixture.Build<DataProvider.MedicalService>()
                         .Create();

        await DbContext.MedicalServices.AddAsync(medicalService);
        await DbContext.SaveChangesAsync();

        //Act
        var medicalServiceProvider = new MedicalServiceDataProvider(DbContext, Mapper);
        var result = await medicalServiceProvider.FindByIdAsync(Guid.NewGuid().ToString(), new(), false);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void FindByIdAsync_IdIsNullOrEmpty_Exception()
    {
        //Arrange
        var medicalServiceAdd = Fixture.Build<DataProvider.MedicalService>()
                                       .With(i => i.Id, Guid.NewGuid())
                                       .Create();

        await DbContext.MedicalServices.AddAsync(medicalServiceAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(medicalServiceAdd).State = EntityState.Detached;

        //Act
        var medicalServiceProvider = new MedicalServiceDataProvider(DbContext, Mapper);
        async Task NullResult() => await medicalServiceProvider.FindByIdAsync(null);
        async Task EmptyResult() => await medicalServiceProvider.FindByIdAsync(string.Empty);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentException>(EmptyResult);
    }
    #endregion

    #endregion
}
