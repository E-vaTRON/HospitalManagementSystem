using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;
using DataDiagnosisTreatment = HospitalManagementSystem.DataProvider.DiagnosisTreatment;

namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatmentDataProvider : DataProviderBase<CoreDiagnosisTreatment, DataDiagnosisTreatment>, IDiagnosisTreatmentDataProvider
{
    public DiagnosisTreatmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
