using CoreReferral = HospitalManagementSystem.Domain.Referral;
using DTOReferral = HospitalManagementSystem.Application.ReferralDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralServiceProvider : ServiceProviderBase<DTOReferral, CoreReferral>, IReferralServiceProvider
{
    public ReferralServiceProvider(IReferralDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
