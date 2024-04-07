using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;
using DataDiagnosisTreatment = HospitalManagementSystem.DataProvider.DiagnosisTreatment;

namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDiagnosisTreatment, DataDiagnosisTreatment>, IDiagnosisTreatmentDataProvider
    where TDbContext : DbContext
{
    public DiagnosisTreatmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
