using CoreMedicalDeviceForm = HospitalManagementSystem.Domain.MedicalDeviceForm;
using DTOMedicalDeviceFormIn = HospitalManagementSystem.Application.InputMedicalDeviceFormDTO;
using DTOMedicalDeviceFormOut = HospitalManagementSystem.Application.OutputMedicalDeviceFormDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalDeviceFormServiceProvider : ServiceProviderBase<DTOMedicalDeviceFormOut, DTOMedicalDeviceFormIn, CoreMedicalDeviceForm>, IMedicalDeviceFormServiceProvider
{
    #region [ Methods ]
    public MedicalDeviceFormServiceProvider(IMedicalDeviceFormDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
