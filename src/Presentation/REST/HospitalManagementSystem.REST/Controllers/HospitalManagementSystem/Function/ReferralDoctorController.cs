using DTOReferralDoctorIn = HospitalManagementSystem.Application.InputReferralDoctorDTO;
using DTOReferralDoctorOut = HospitalManagementSystem.Application.OutputReferralDoctorDTO;

namespace HospitalManagementSystem.REST;

public class ReferralDoctorController : BaseHMSController<DTOReferralDoctorOut, DTOReferralDoctorIn>
{
    public ReferralDoctorController(IReferralDoctorServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}