using CoreReferralDoctor = HospitalManagementSystem.Domain.ReferralDoctor;
using DataReferralDoctor = HospitalManagementSystem.DataProvider.ReferralDoctor;

namespace HospitalManagementSystem.DataProvider
{
    public class ReferralDoctorDataProvider : DataProviderBase<CoreReferralDoctor, DataReferralDoctor>, IReferralDoctorDataProvider
    {
        public ReferralDoctorDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
