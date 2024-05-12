using CoreReferralDoctor = HospitalManagementSystem.Domain.ReferralDoctor;
using DTOReferralDoctor = HospitalManagementSystem.Application.ReferralDoctorDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralDoctorServiceProvider : ServiceProviderBase<DTOReferralDoctor, CoreReferralDoctor>, IReferralDoctorServiceProvider
{
    public ReferralDoctorServiceProvider(IReferralDoctorDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
