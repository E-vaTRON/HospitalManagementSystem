using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DTODeviceServiceIn = HospitalManagementSystem.Application.InputDeviceServiceDTO;
using DTODeviceServiceOut = HospitalManagementSystem.Application.OutputDeviceServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceServiceProvider : ServiceProviderBase<DTODeviceServiceOut, DTODeviceServiceIn, CoreDeviceService>, IDeviceServiceServiceProvider
{
    #region [ Fields ]
    protected readonly IDeviceServiceDataProvider DeviceServiceDataProvider;
    #endregion

    #region [ CTor ]
    public DeviceServiceServiceProvider(IDeviceServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        DeviceServiceDataProvider = dataProvider;
    }
    #endregion

    #region [ Method ]
    public async Task<IList<DTODeviceServiceOut>> GetByMultipleServiceIdIncludeDeviceAsync(string[] serviceIds)
    {
        ArgumentNullException.ThrowIfNull(serviceIds, nameof(serviceIds));

        var deviceServices = await DeviceServiceDataProvider.GetByMultipleServiceIdIncludeDeviceAsync(serviceIds);

        ArgumentNullException.ThrowIfNull(deviceServices, nameof(deviceServices));
        return MapToDTOs(deviceServices).ToList();
    }

    public async Task<IList<DTODeviceServiceOut>> GetByServiceIdIncludeDeviceAsync(string serviceId)
    {
        ArgumentNullException.ThrowIfNull(serviceId, nameof(serviceId));

        var deviceServices = await DeviceServiceDataProvider.GetByServiceIdIncludeDeviceAsync(serviceId);

        ArgumentNullException.ThrowIfNull(deviceServices, nameof(deviceServices));
        return MapToDTOs(deviceServices).ToList();
    }
    #endregion
}