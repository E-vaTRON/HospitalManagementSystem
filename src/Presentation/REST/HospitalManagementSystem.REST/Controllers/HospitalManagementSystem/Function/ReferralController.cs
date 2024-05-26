using DTOReferralIn = HospitalManagementSystem.Application.InputReferralDTO;
using DTOReferralOut = HospitalManagementSystem.Application.OutputReferralDTO;

namespace HospitalManagementSystem.REST;

public class ReferralController : BaseHMSController<DTOReferralOut, DTOReferralIn>
{
    public ReferralController(IReferralServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}