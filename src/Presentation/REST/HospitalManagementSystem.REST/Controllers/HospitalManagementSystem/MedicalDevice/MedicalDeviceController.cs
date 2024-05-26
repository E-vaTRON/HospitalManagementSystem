using DTOMedicalDeviceIn = HospitalManagementSystem.Application.InputMedicalDeviceDTO;
using DTOMedicalDeviceOut = HospitalManagementSystem.Application.OutputMedicalDeviceDTO;

namespace HospitalManagementSystem.REST;

public class MedicalDeviceController : BaseHMSController<DTOMedicalDeviceOut, DTOMedicalDeviceIn>
{
    public MedicalDeviceController(IMedicalDeviceServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}

