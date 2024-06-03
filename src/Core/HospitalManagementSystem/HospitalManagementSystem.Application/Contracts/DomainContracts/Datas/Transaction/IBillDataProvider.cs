namespace HospitalManagementSystem.Application;

public interface IBillDataProvider : IDataProviderBase<Bill, string>
{

    #region [ User ]
    Task<IList<Bill>> GetBillByUserIdAsync(string userId);

    Task<IList<Bill>> GetBillByMultipleUserIdAsync(string[] userIds);

    Task<IList<Bill>> GetBillIncludeEpisodeByUserIdAsync(string userId);

    Task<IList<Bill>> GetBillIncludeEpisodeByMultipleUserIdAsync(string[] userIds);
    #endregion
}
