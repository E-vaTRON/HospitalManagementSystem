namespace HospitalManagementSystem.Application;

public interface IAnalysisTestDataProvider : IDataProviderBase<AnalysisTest, string>
{
    #region [ Methods ]
    Task<IList<AnalysisTest>> GetAllIncludeDeviceAsync();

    Task<IList<AnalysisTest>> GetMultipleByIdIncludeDeviceAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<AnalysisTest> GetByIdIncludeDeviceAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
