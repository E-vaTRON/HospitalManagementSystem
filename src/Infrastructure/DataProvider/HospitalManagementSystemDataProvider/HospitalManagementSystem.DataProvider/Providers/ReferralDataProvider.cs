using CoreReferral = HospitalManagementSystem.Domain.Referral;
using DataReferral = HospitalManagementSystem.DataProvider.Referral;

namespace HospitalManagementSystem.DataProvider;

public class ReferralDataProvider : DataProviderBase<CoreReferral, DataReferral>, IReferralServiceProvider
{
    public ReferralDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
