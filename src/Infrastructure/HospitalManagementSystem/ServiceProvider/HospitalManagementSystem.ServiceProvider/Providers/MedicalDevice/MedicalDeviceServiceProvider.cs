using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DTOMedicalDeviceIn = HospitalManagementSystem.Application.InputMedicalDeviceDTO;
using DTOMedicalDeviceOut = HospitalManagementSystem.Application.OutputMedicalDeviceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalDeviceServiceProvider : ServiceProviderBase<DTOMedicalDeviceOut, DTOMedicalDeviceIn, CoreMedicalDevice>, IMedicalDeviceServiceProvider
{
    #region [ Fields ]
    protected readonly IMedicalDeviceDataProvider MedicalDeviceDataProvider;
    #endregion

    #region [ CTor ]
    public MedicalDeviceServiceProvider(IMedicalDeviceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        MedicalDeviceDataProvider = dataProvider;
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<DTOMedicalDeviceOut>> FindAllWithIncludedAsync(CancellationToken cancellationToken)
    {
        var medicalDevices = await MedicalDeviceDataProvider.FindAllWithIncludedAsync(cancellationToken);
        ArgumentNullException.ThrowIfNull(medicalDevices, nameof(medicalDevices));
        return MapToDTOs(medicalDevices).ToList();
    }
    #endregion
}