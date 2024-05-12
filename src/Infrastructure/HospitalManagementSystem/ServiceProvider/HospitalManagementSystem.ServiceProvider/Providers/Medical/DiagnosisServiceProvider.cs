using CoreDiagnosis = HospitalManagementSystem.Domain.Diagnosis;
using DTODiagnosis = HospitalManagementSystem.Application.DiagnosisDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisServiceProvider : ServiceProviderBase<DTODiagnosis, CoreDiagnosis>, IDiagnosisServiceProvider
{
    public DiagnosisServiceProvider(IDiagnosisDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}

