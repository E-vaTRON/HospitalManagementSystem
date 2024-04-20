using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;
using DataDiagnosisTreatment = HospitalManagementSystem.DataProvider.DiagnosisTreatment;

namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatmentDataProvider : DataProviderBase<CoreDiagnosisTreatment, DataDiagnosisTreatment>, IDiagnosisTreatmentServiceProvider
{
    public DiagnosisTreatmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
