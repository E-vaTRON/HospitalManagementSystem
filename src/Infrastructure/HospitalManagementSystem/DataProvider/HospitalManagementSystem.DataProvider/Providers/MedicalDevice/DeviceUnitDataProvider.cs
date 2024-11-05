using CoreDeviceUnit = HospitalManagementSystem.Domain.DeviceUnit;
using DataDeviceUnit = HospitalManagementSystem.DataProvider.DeviceUnit;

namespace HospitalManagementSystem.DataProvider;

public class DeviceUnitDataProvider : DataProviderBase<CoreDeviceUnit, DataDeviceUnit>, IDeviceUnitDataProvider
{
    #region [ CTor ]
    public DeviceUnitDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion
}
