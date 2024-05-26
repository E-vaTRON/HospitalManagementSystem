using CoreReferralDoctor = HospitalManagementSystem.Domain.ReferralDoctor;
using DTOReferralDoctorIn = HospitalManagementSystem.Application.InputReferralDoctorDTO;
using DTOReferralDoctorOut = HospitalManagementSystem.Application.OutputReferralDoctorDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralDoctorServiceProvider : ServiceProviderBase<DTOReferralDoctorOut, DTOReferralDoctorIn, CoreReferralDoctor>, IReferralDoctorServiceProvider
{
    public ReferralDoctorServiceProvider(IReferralDoctorDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
