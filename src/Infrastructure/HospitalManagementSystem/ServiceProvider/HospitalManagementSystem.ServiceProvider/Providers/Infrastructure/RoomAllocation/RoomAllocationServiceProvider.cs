using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DTORoomAllocationIn = HospitalManagementSystem.Application.InputRoomAllocationDTO;
using DTORoomAllocationOut = HospitalManagementSystem.Application.OutputRoomAllocationDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAllocationServiceProvider : ServiceProviderBase<DTORoomAllocationOut, DTORoomAllocationIn, CoreRoomAllocation>, IRoomAllocationServiceProvider
{
    #region [ Feilds ]
    protected IRoomAllocationDataProvider RoomAllocationDataProvider;
    #endregion

    #region [ CTor ]
    public RoomAllocationServiceProvider(IRoomAllocationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        RoomAllocationDataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    public async Task<DTORoomAllocationOut> GetByIdIncludeRoomAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        var roomAllocation = await RoomAllocationDataProvider.GetByIdIncludeRoomAsync(id, cancellationToken);
        return MapToDTO(roomAllocation)!;
    }

    public async Task<IList<DTORoomAllocationOut>> GetMultipleByIdIncludeRoomAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(ids, nameof(ids));
        var roomAllocations = await RoomAllocationDataProvider.GetMultipleByIdIncludeRoomAsync(ids, cancellationToken);
        return MapToDTOs(roomAllocations).ToList();
    }
    #endregion
}
