namespace HospitalManagementSystem.Tests;

public class DiagnosisDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public DiagnosisDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]

    #region [ Add ]
    [Fact]
    public async void AddAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                           .Create();

        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.SaveChangesAsync();

        var diagnosisAdd = Fixture.Build<Domain.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id.ToString())
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id.ToString())
                                  .With(i => i.Id, Guid.NewGuid().ToString())
                                  .Create();

        // Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var add = diagnosisProvider.AddAsync(diagnosisAdd, new());

        // Assert
        var result = await DbContext.Diagnoses.FirstOrDefaultAsync(d => d.Id == Guid.Parse(diagnosisAdd.Id!));
        Assert.True(add.IsCompletedSuccessfully);
        Assert.Equal(diagnosisAdd.DiseasesId, result?.DiseasesId.ToString());
        Assert.Equal(diagnosisAdd.MedicalExamEpisodeId, result?.MedicalExamEpisodeId.ToString());
        Assert.Equal(diagnosisAdd.DiagnosisCode, result?.DiagnosisCode);
        Assert.Equal(diagnosisAdd.Symptom, result?.Symptom);
        Assert.Equal(diagnosisAdd.Description, result?.Description);
    }

    [Fact]
    public async void AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diagnosisAdd = default(Domain.Diagnosis);

        // Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        Task Add() => diagnosisProvider.AddAsync(diagnosisAdd, new());

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

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        var diagnosisUpdate = Fixture.Build<Domain.Diagnosis>()
                                     .With(i => i.DiseasesId, diseasesAdd.Id.ToString())
                                     .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id.ToString())
                                     .With(i => i.Id, diagnosisAdd.Id.ToString())
                                     .Create();

        // Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var update = diagnosisProvider.UpdateAsync(diagnosisUpdate);

        // Assert
        var result = await DbContext.Diagnoses.FirstOrDefaultAsync(d => d.Id == diagnosisAdd.Id);
        Assert.True(update.IsCompletedSuccessfully);
        Assert.Equal(diagnosisUpdate.DiseasesId, result?.DiseasesId.ToString());
        Assert.Equal(diagnosisUpdate.MedicalExamEpisodeId, result?.MedicalExamEpisodeId.ToString());
        Assert.Equal(diagnosisUpdate.DiagnosisCode, result?.DiagnosisCode);
        Assert.Equal(diagnosisUpdate.Symptom, result?.Symptom);
        Assert.Equal(diagnosisUpdate.Description, result?.Description);
    }

    [Fact]
    public async void UpdateAsync_NotFound_Exception()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        var diagnosisUpdate = Fixture.Build<Domain.Diagnosis>()
                             .With(i => i.DiseasesId, diseasesAdd.Id.ToString())
                             .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id.ToString())
                             .Create();

        // Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var update = diagnosisProvider.UpdateAsync(diagnosisUpdate);

        // Assert
        var result = await DbContext.Diagnoses.FirstOrDefaultAsync(d => d.Id == diagnosisAdd.Id);
        Assert.True(update.IsCompleted);
        Assert.Equal(diagnosisAdd.DiseasesId.ToString(), result?.DiseasesId.ToString());
        Assert.Equal(diagnosisAdd.MedicalExamEpisodeId.ToString(), result?.MedicalExamEpisodeId.ToString());
        Assert.Equal(diagnosisAdd.DiagnosisCode, result?.DiagnosisCode);
        Assert.Equal(diagnosisAdd.Symptom, result?.Symptom);
        Assert.Equal(diagnosisAdd.Description, result?.Description);
    }

    [Fact]
    public async void UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        var diagnosisUpdate = default(Domain.Diagnosis);

        // Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        async Task Result() => await diagnosisProvider.UpdateAsync(diagnosisUpdate);

        // Assert
        var result = await DbContext.Diagnoses.FirstOrDefaultAsync(d => d.Id == diagnosisAdd.Id);
        await Assert.ThrowsAsync<ArgumentNullException>(Result);
        Assert.Equal(diagnosisAdd.DiseasesId.ToString(), result?.DiseasesId.ToString());
        Assert.Equal(diagnosisAdd.MedicalExamEpisodeId.ToString(), result?.MedicalExamEpisodeId.ToString());
        Assert.Equal(diagnosisAdd.DiagnosisCode, result?.DiagnosisCode);
        Assert.Equal(diagnosisAdd.Symptom, result?.Symptom);
        Assert.Equal(diagnosisAdd.Description, result?.Description);
    }
    #endregion

    #region [ Delete ]
    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        // Act
        var icdProvider = new DiagnosisDataProvider(base.DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(diagnosisAdd.Id.ToString(), new());

        // Assert
        var result = await DbContext.Diagnoses.FirstOrDefaultAsync(d => d.Id == diagnosisAdd.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteByIdAsync_IdIsNullOrEmpty_Exception()
    {
        // Arrange
        var id = new Guid();

        // Act
        var icdProvider = new DiseasesDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(id.ToString());

        // Assert
        var result = await DbContext.Diseases.FirstOrDefaultAsync(d => d.Id == id);
        Assert.Null(result);
    }

    [Fact]
    public async void DeleteByIdAsync_NotFound()
    {
        // Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        var id = this.Fixture.Create<Guid>();

        // Act
        var icdProvider = new DiseasesDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(diagnosisAdd.Id.ToString());

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
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                                 .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                           .Create();

        var diagnosisList = Fixture.Build<DataProvider.Diagnosis>()
                                   .With(i => i.DiseasesId, diseasesAdd.Id)
                                   .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                   .CreateMany().ToArray();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddRangeAsync(diagnosisList);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();

        //Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var resultList = await diagnosisProvider.FindAllAsync();

        //Assert
        Assert.Equal(3, resultList.Count());

        // Check that each item in the database has the correct properties
        foreach (var result in resultList)
        {
            var diagnosis = diagnosisList.ElementAt(resultList.ToList().IndexOf(result));
            Assert.NotNull(result);
            Assert.Equal(diagnosis.DiseasesId.ToString(), result?.DiseasesId);
            Assert.Equal(diagnosis.MedicalExamEpisodeId.ToString(), result?.MedicalExamEpisodeId);
            Assert.Equal(diagnosis.DiagnosisCode, result?.DiagnosisCode);
            Assert.Equal(diagnosis.Symptom, result?.Symptom);
            Assert.Equal(diagnosis.Description, result?.Description);
        };
    }

    [Fact]
    public async void FindAll_NotFound()
    {
        //Arrange
        // Nothing here
        await DbContext.SaveChangesAsync();

        //Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var resultList = await diagnosisProvider.FindAllAsync();

        //Assert
        //Assert.True(!resultList.Any());
        Assert.Empty(resultList);
    }

    [Fact]
    public async void FindByIdAsync_DisableQuickFind()
    {
        //Arrange
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        //Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        var result = await diagnosisProvider.FindByIdAsync(diagnosisAdd.Id.ToString(), new(), false);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(diagnosisAdd.DiseasesId.ToString(), result?.DiseasesId);
        Assert.Equal(diagnosisAdd.MedicalExamEpisodeId.ToString(), result?.MedicalExamEpisodeId);
        Assert.Equal(diagnosisAdd.DiagnosisCode, result?.DiagnosisCode);
        Assert.Equal(diagnosisAdd.Symptom, result?.Symptom);
        Assert.Equal(diagnosisAdd.Description, result?.Description);
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
        var diseasesAdd = Fixture.Build<DataProvider.Diseases>()
                         .Create();

        var medicalExamEpisodeAdd = Fixture.Build<DataProvider.MedicalExamEpisode>()
                                   .Create();

        var diagnosisAdd = Fixture.Build<DataProvider.Diagnosis>()
                                  .With(i => i.DiseasesId, diseasesAdd.Id)
                                  .With(i => i.MedicalExamEpisodeId, medicalExamEpisodeAdd.Id)
                                  .With(i => i.Id, Guid.NewGuid())
                                  .Create();

        await DbContext.Diseases.AddAsync(diseasesAdd);
        await DbContext.Diagnoses.AddAsync(diagnosisAdd);
        await DbContext.MedicalExamEpisodes.AddAsync(medicalExamEpisodeAdd);
        await DbContext.SaveChangesAsync();
        DbContext.Entry(diagnosisAdd).State = EntityState.Detached;

        //Act
        var diagnosisProvider = new DiagnosisDataProvider(DbContext, Mapper);
        async Task NullResult() => await diagnosisProvider.FindByIdAsync(null);
        async Task EmptyResult() => await diagnosisProvider.FindByIdAsync(string.Empty);

        //Assert
        await Assert.ThrowsAsync<ArgumentNullException>(NullResult);
        await Assert.ThrowsAsync<ArgumentException>(EmptyResult);
    }
    #endregion

    #endregion
}
