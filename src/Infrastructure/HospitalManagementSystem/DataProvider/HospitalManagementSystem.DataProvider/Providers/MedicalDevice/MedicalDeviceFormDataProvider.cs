using CoreMedicalDeviceForm = HospitalManagementSystem.Domain.MedicalDeviceForm;
using DataMedicalDeviceForm = HospitalManagementSystem.DataProvider.MedicalDeviceForm;

namespace HospitalManagementSystem.DataProvider;

public class MedicalDeviceFormDataProvider : DataProviderBase<CoreMedicalDeviceForm, DataMedicalDeviceForm>, IMedicalDeviceFormDataProvider
{
    #region [ CTor ]
    public MedicalDeviceFormDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion
}
