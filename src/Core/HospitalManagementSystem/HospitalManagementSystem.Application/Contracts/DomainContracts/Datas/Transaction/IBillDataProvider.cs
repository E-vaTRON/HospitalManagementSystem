namespace HospitalManagementSystem.Application;

public interface IBillDataProvider : IDataProviderBase<Bill, string>
{
    #region [ User ]
    Task<IList<Bill>> GetBillByUserIdAsync(string userId, CancellationToken cancellationToken = default!);

    Task<IList<Bill>> GetBillByMultipleUserIdAsync(string[] userIds, CancellationToken cancellationToken = default!);

    Task<IList<Bill>> GetBillIncludeEpisodeByUserIdAsync(string userId, CancellationToken cancellationToken = default!);

    Task<IList<Bill>> GetBillIncludeEpisodeByMultipleUserIdAsync(string[] userIds, CancellationToken cancellationToken = default!);
    #endregion
}
