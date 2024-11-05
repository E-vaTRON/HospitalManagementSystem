namespace HospitalManagementSystem.Tests;

public class DiagnosisTreatmentDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public DiagnosisTreatmentDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]

    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.SaveChangesAsync();

        var diagnosisTreatmentAdd = Fixture.Build<Domain.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id.ToString())
                                           .With(i => i.TreatmentId, treatmentAdd.Id.ToString())
                                           .With(i => i.Id, Guid.NewGuid().ToString())
                                           .Create();

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var add = diagnosisTreatmentProvider.AddAsync(diagnosisTreatmentAdd, new());

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == Guid.Parse(diagnosisTreatmentAdd.Id!));
        Assert.True(add.IsCompletedSuccessfully);
        Assert.Equal(diagnosisTreatmentAdd.DiagnosisId, result?.DiagnosisId.ToString());
        Assert.Equal(diagnosisTreatmentAdd.TreatmentId, result?.TreatmentId.ToString());
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diagnosisTreatmentAdd = default(Domain.DiagnosisTreatment);

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        Task Add() => diagnosisTreatmentProvider.AddAsync(diagnosisTreatmentAdd, new());

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
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                           .With(i => i.TreatmentId, treatmentAdd.Id)
                                           .With(i => i.Id, Guid.NewGuid())
                                           .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        var diagnosisTreatmentUpdate = Fixture.Build<Domain.DiagnosisTreatment>()
                                              .With(i => i.DiagnosisId, diagnosisAdd.Id.ToString())
                                              .With(i => i.TreatmentId, treatmentAdd.Id.ToString())
                                              .With(i => i.Id, diagnosisTreatmentAdd.Id.ToString())
                                              .Create();

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var update = diagnosisTreatmentProvider.UpdateAsync(diagnosisTreatmentUpdate);

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == diagnosisTreatmentAdd.Id);
        Assert.True(update.IsCompletedSuccessfully);
        Assert.Equal(diagnosisTreatmentUpdate.DiagnosisId, result?.DiagnosisId.ToString());
        Assert.Equal(diagnosisTreatmentUpdate.TreatmentId, result?.TreatmentId.ToString());
    }

    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                           .With(i => i.TreatmentId, treatmentAdd.Id)
                                           .With(i => i.Id, Guid.NewGuid())
                                           .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        var diagnosisTreatmentUpdate = Fixture.Build<Domain.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id.ToString())
                                           .With(i => i.TreatmentId, treatmentAdd.Id.ToString())
                                           .With(i => i.Id, Guid.NewGuid().ToString())
                                           .Create();

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var update = diagnosisTreatmentProvider.UpdateAsync(diagnosisTreatmentUpdate);
        async Task Update() => await update;

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == diagnosisTreatmentAdd.Id);
        Assert.True(update.IsCompleted);
        await Assert.ThrowsAsync<ArgumentNullException>(Update);
        Assert.Equal(diagnosisTreatmentAdd.DiagnosisId.ToString(), result?.DiagnosisId.ToString());
        Assert.Equal(diagnosisTreatmentAdd.TreatmentId.ToString(), result?.TreatmentId.ToString());
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                           .With(i => i.TreatmentId, treatmentAdd.Id)
                                           .With(i => i.Id, Guid.NewGuid())
                                           .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        var diagnosisTreatmentUpdate = default(Domain.DiagnosisTreatment);

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var update = diagnosisTreatmentProvider.UpdateAsync(diagnosisTreatmentUpdate);
        async Task Update() => await update;

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == diagnosisTreatmentAdd.Id);
        await Assert.ThrowsAsync<ArgumentNullException>(Update);
        Assert.Equal(diagnosisTreatmentAdd.DiagnosisId.ToString(), result?.DiagnosisId.ToString());
        Assert.Equal(diagnosisTreatmentAdd.TreatmentId.ToString(), result?.TreatmentId.ToString());
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                           .With(i => i.TreatmentId, treatmentAdd.Id)
                                           .With(i => i.Id, Guid.NewGuid())
                                           .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        await diagnosisTreatmentProvider.DeleteByIdAsync(diagnosisTreatmentAdd.Id.ToString(), new());

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == diagnosisTreatmentAdd.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    {
        // Arrange
        var id = new Guid();

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        await diagnosisTreatmentProvider.DeleteByIdAsync(id.ToString(), new());

        // Assert
        var result = await DbContext.DiagnosisTreatments.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }

    [Fact]
    public async void DeleteByIdAsync_NotFound()
    {
        // Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                           .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                           .With(i => i.TreatmentId, treatmentAdd.Id)
                                           .With(i => i.Id, Guid.NewGuid())
                                           .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        var id = this.Fixture.Create<Guid>();

        // Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        await diagnosisTreatmentProvider.DeleteByIdAsync(id.ToString(), new()); ;

        // Assert 
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }
    #endregion

    #region [ Get ]
    [Fact]
    public async void FindAll_Success()
    {
        //Arrange
        var icdCodeAdd = Fixture.Build<DataProvider.ICDCode>()
                    .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.ICDCodeId, icdCodeAdd.Id)
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAddList = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                               .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                               .With(i => i.TreatmentId, treatmentAdd.Id)
                                               .CreateMany().ToArray();

        await DbContext.ICDCodes.AddAsync(icdCodeAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddRangeAsync(diagnosisTreatmentAddList);
        await DbContext.SaveChangesAsync();

        //Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var resultList = await diagnosisTreatmentProvider.FindAllAsync();

        //Assert
        Assert.Equal(3, resultList.Count());

        //Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var diagnosisTreatmentGet = diagnosisTreatmentAddList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(diagnosisTreatmentGet.DiagnosisId.ToString(), result?.DiagnosisId);
            Assert.Equal(diagnosisTreatmentGet.TreatmentId.ToString(), result?.TreatmentId);
        };
    }

    [Fact]
    public async void FindAll_NotFound()
    {
        //Arrange
        // Nothing here
        await DbContext.SaveChangesAsync();

        //Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var resultList = await diagnosisTreatmentProvider.FindAllAsync();

        //Assert
        //Assert.True(!resultList.Any());
        Assert.Empty(resultList);
    }

    [Fact]
    public async void FindByIdAsync_DisableQuickFind()
    {
        //Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                               .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                               .With(i => i.TreatmentId, treatmentAdd.Id)
                                               .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        //Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        var result = await diagnosisTreatmentProvider.FindByIdAsync(diagnosisTreatmentAdd.Id.ToString(), new(), false);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(diagnosisTreatmentAdd.DiagnosisId.ToString(), result?.DiagnosisId);
        Assert.Equal(diagnosisTreatmentAdd.TreatmentId.ToString(), result?.TreatmentId);
    }

    [Fact]
    public async void FindByIdAsync_NotExit()
    {
        //Arrange
        //Nothing here
        await DbContext.SaveChangesAsync();

        //Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var result = await diagnosisProvider.FindByIdAsync(Guid.NewGuid().ToString(), new(), false);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async void FindByIdAsync_IdIsNullOrEmpty_Exception()
    {
        //Arrange
        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .Create();

        var treatmentAdd = Fixture.Build<DataProvider.Treatment>()
                                  .Create();

        var diagnosisTreatmentAdd = Fixture.Build<DataProvider.DiagnosisTreatment>()
                                               .With(i => i.DiagnosisId, diagnosisAdd.Id)
                                               .With(i => i.TreatmentId, treatmentAdd.Id)
                                               .Create();

        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.Treatments.AddAsync(treatmentAdd);
        await DbContext.DiagnosisTreatments.AddAsync(diagnosisTreatmentAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisTreatmentAdd).State = EntityState.Detached;

        //Act
        var diagnosisTreatmentProvider = new DiagnosisTreatmentDataProvider(DbContext, Mapper);
        async Task NullResult() => await diagnosisTreatmentProvider.FindByIdAsync(null);
        async Task EmptyResult() => await diagnosisTreatmentProvider.FindByIdAsync(string.Empty);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentException>(EmptyResult);
    }
    #endregion

    #endregion
}
