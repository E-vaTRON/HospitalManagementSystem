using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DTOMedicalDevice = HospitalManagementSystem.Application.MedicalDeviceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalDeviceServiceProvider : ServiceProviderBase<DTOMedicalDevice, CoreMedicalDevice>, IMedicalDeviceServiceProvider
{
    public MedicalDeviceServiceProvider(IMedicalDeviceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
