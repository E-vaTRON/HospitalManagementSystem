using CoreTreatment = HospitalManagementSystem.Domain.Treatment;
using DataTreatment = HospitalManagementSystem.DataProvider.Treatment;

namespace HospitalManagementSystem.DataProvider;

public class TreatmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreTreatment, DataTreatment>, ITreatmentDataProvider
    where TDbContext : DbContext
{
    public TreatmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}