using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DataMedicalDevice = HospitalManagementSystem.DataProvider.MedicalDevice;

namespace HospitalManagementSystem.DataProvider;

public class MedicalDeviceDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreMedicalDevice, DataMedicalDevice>, IMedicalDeviceDataProvider
    where TDbContext : DbContext
{
    public MedicalDeviceDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
