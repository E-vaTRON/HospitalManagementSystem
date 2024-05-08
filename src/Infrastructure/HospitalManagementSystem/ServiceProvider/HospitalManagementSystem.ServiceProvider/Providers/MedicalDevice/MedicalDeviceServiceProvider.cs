using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalDeviceServiceProvider : ServiceProviderBase<CoreMedicalDevice>, IMedicalDeviceServiceProvider
{
    public MedicalDeviceServiceProvider(IMedicalDeviceDataProvider dataProvider) : base(dataProvider)
    {
    }
}
