using CoreReferral = HospitalManagementSystem.Domain.Referral;
using DataReferral = HospitalManagementSystem.DataProvider.Referral;

namespace HospitalManagementSystem.DataProvider;

public class ReferralDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreReferral, DataReferral>, IReferralDataProvider
    where TDbContext : DbContext
{
    public ReferralDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
