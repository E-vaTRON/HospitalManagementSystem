using CoreReferral = HospitalManagementSystem.Domain.Referral;
using DTOReferralIn = HospitalManagementSystem.Application.InputReferralDTO;
using DTOReferralOut = HospitalManagementSystem.Application.OutputReferralDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReferralServiceProvider : ServiceProviderBase<DTOReferralOut, DTOReferralIn, CoreReferral>, IReferralServiceProvider
{
    public ReferralServiceProvider(IReferralDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
