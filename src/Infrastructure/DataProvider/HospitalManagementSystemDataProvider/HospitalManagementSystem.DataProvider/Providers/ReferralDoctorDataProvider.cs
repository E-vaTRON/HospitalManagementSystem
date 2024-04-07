using CoreReferralDoctor = HospitalManagementSystem.Domain.ReferralDoctor;
using DataReferralDoctor = HospitalManagementSystem.DataProvider.ReferralDoctor;

namespace HospitalManagementSystem.DataProvider;

public class ReferralDoctorDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreReferralDoctor, DataReferralDoctor>, IReferralDoctorDataProvider
    where TDbContext : DbContext
{
    public ReferralDoctorDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
