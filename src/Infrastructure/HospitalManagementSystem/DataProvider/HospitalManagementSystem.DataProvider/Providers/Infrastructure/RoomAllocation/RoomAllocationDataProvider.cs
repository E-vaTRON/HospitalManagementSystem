using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DataRoomAllocation = HospitalManagementSystem.DataProvider.RoomAllocation;

namespace HospitalManagementSystem.DataProvider;

public class RoomAllocationDataProvider : DataProviderBase<CoreRoomAllocation, DataRoomAllocation>, IRoomAllocationDataProvider
{
    #region [ CTor ]
    public RoomAllocationDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual async Task<IEnumerable<CoreRoomAllocation>> InternalGetAllIncludeRoomAsync(Expression<Func<CoreRoomAllocation, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.Room)
                          .WhereIf(predicate != null, predicate!)
                          .ToListAsync(cancellationToken);
    }

    protected virtual async Task<IEnumerable<CoreRoomAllocation>> InternalFindByIdIncludeRoomAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var mId = ParseIds(ids!);
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.Room)
                          .WhereIf(ids != null, service => ids!.Contains(service.Id))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreRoomAllocation>> GetAllIncludeRoomAsync()
    {
        var roomAllocations = await InternalGetAllIncludeRoomAsync();
        ArgumentNullException.ThrowIfNull(roomAllocations, nameof(roomAllocations));
        return roomAllocations.ToList();
    }

    public async Task<IList<CoreRoomAllocation>> GetMultipleByIdIncludeRoomAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var roomAllocations = await InternalFindByIdIncludeRoomAsync(ids);
        ArgumentNullException.ThrowIfNull(roomAllocations, nameof(roomAllocations));
        return roomAllocations.ToList();
    }

    public async Task<CoreRoomAllocation> GetByIdIncludeRoomAsync(string id, CancellationToken cancellationToken = default)
    {
        var roomAllocations = await InternalFindByIdIncludeRoomAsync(new string[] { id });
        ArgumentNullException.ThrowIfNull(roomAllocations, nameof(roomAllocations));
        return roomAllocations.First();
    }
    #endregion
}
