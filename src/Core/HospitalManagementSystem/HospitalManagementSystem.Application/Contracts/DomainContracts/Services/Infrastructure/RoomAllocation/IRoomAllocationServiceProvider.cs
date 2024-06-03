namespace HospitalManagementSystem.Application;

public interface IRoomAllocationServiceProvider : IServiceProviderBase<OutputRoomAllocationDTO, InputRoomAllocationDTO, string>
{
    #region [ Methods ]
    Task<IList<OutputRoomAllocationDTO>> GetMultipleByIdIncludeRoomAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<OutputRoomAllocationDTO> GetByIdIncludeRoomAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
