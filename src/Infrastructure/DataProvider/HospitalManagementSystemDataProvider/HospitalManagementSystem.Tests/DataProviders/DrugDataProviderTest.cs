namespace HospitalManagementSystem.Tests;

public class DrugDataProviderTest : DataProviderTestBase
{
    #region [ CTors ]
    public DrugDataProviderTest(string realConnection = "") : base(realConnection)
    {
    }
    #endregion

    #region [ Methods ]
    [Fact]
    public async void DeleteByIdAsync_Success()
    {
        // Arrange
        var drugAdd = this.Fixture.Create<Drug>();
        Drug drug = new()
        {
        };
        await DbContext.Drugs.AddAsync(drugAdd);
        await DbContext.SaveChangesAsync();

        // Act
        var icdProvider = new DrugDataProvider(DbContext, Mapper);
        await icdProvider.DeleteByIdAsync(drugAdd.Id.ToString(), new());

        // Assert
        //var result = await DbContext.ICDs.FirstOrDefaultAsync(d => d.Id == icd.Id);
        //Assert.Null(result);
        //Assert.Equal(icd.Code, result?.Code);
        //Assert.Equal(icd.Description, result?.Description);
        //Assert.Equal(icd.Status.ToString(), result?.Status.ToString());
    }

    #endregion
}
