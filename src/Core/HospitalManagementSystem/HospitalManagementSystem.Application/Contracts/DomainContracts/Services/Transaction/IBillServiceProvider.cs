namespace HospitalManagementSystem.Application;

public interface IBillServiceProvider : IServiceProviderBase<OutputBillDTO, InputBillDTO, string>
{
    #region [ User ]
    Task<IList<OutputBillDTO>> GetBillByUserIdAsync(string userId, bool includeEpisode);

    Task<IList<OutputBillDTO>> GetBillByMultipleUserIdAsync(string[] userIds, bool includeEpisode);
    #endregion
}
