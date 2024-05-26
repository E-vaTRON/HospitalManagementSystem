using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DTOMedicalDeviceIn = HospitalManagementSystem.Application.InputMedicalDeviceDTO;
using DTOMedicalDeviceOut = HospitalManagementSystem.Application.OutputMedicalDeviceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalDeviceServiceProvider : ServiceProviderBase<DTOMedicalDeviceOut, DTOMedicalDeviceIn, CoreMedicalDevice>, IMedicalDeviceServiceProvider
{
    public MedicalDeviceServiceProvider(IMedicalDeviceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}