using CoreReferral = HospitalManagementSystem.Domain.Referral;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralServiceProvider : ServiceProviderBase<CoreReferral>, IReferralServiceProvider
{
    public ReferralServiceProvider(ReferralDataProvider dataProvider) : base(dataProvider)
    {
    }
}
