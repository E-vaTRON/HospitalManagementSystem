using CoreTreatment = HospitalManagementSystem.Domain.Treatment;
using DataTreatment = HospitalManagementSystem.DataProvider.Treatment;

namespace HospitalManagementSystem.DataProvider;

public class TreatmentDataProvider : DataProviderBase<CoreTreatment, DataTreatment>, ITreatmentServiceProvider
{
    public TreatmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}