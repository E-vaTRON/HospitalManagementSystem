using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DataMedicalDevice = HospitalManagementSystem.DataProvider.MedicalDevice;

namespace HospitalManagementSystem.DataProvider
{
    public class MedicalDeviceDataProvider : DataProviderBase<CoreMedicalDevice, DataMedicalDevice>, IMedicalDeviceDataProvider
    {
        public MedicalDeviceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
