using CoreDeviceUnit = HospitalManagementSystem.Domain.DeviceUnit;
using DTODeviceUnitIn = HospitalManagementSystem.Application.InputDeviceUnitDTO;
using DTODeviceUnitOut = HospitalManagementSystem.Application.OutputDeviceUnitDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceUnitServiceProvider : ServiceProviderBase<DTODeviceUnitOut, DTODeviceUnitIn, CoreDeviceUnit>, IDeviceUnitServiceProvider
{
    #region [ CTor ]
    public DeviceUnitServiceProvider(IDeviceUnitDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
