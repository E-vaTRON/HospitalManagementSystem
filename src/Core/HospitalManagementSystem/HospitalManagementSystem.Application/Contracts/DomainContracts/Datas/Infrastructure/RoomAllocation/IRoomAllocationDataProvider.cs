namespace HospitalManagementSystem.Application;

public interface IRoomAllocationDataProvider : IDataProviderBase<RoomAllocation, string>
{
    #region [ Methods ]
    Task<IList<RoomAllocation>> GetMultipleByIdIncludeRoomAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<RoomAllocation> GetByIdIncludeRoomAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
