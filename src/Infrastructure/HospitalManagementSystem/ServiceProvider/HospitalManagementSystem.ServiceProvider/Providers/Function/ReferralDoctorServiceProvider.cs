using CoreReferralDoctor = HospitalManagementSystem.Domain.ReferralDoctor;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralDoctorServiceProvider : ServiceProviderBase<CoreReferralDoctor>, IReferralDoctorServiceProvider
{
    public ReferralDoctorServiceProvider(IReferralDoctorDataProvider dataProvider) : base(dataProvider)
    {
    }
}
