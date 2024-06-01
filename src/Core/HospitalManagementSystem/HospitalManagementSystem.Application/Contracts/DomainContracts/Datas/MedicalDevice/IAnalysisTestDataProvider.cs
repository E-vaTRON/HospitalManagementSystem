namespace HospitalManagementSystem.Application;

public interface IAnalysisTestDataProvider : IDataProviderBase<AnalysisTest, string>
{
    #region [ Methods ]
    Task<IList<AnalysisTest>> GetMultipleByIdIncludeServiceAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<AnalysisTest> GetByIdIncludeServiceAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
