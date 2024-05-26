using CoreDiagnosis = HospitalManagementSystem.Domain.Diagnosis;
using DTODiagnosisIn = HospitalManagementSystem.Application.InputDiagnosisDTO;
using DTODiagnosisOut = HospitalManagementSystem.Application.OutputDiagnosisDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisServiceProvider : ServiceProviderBase<DTODiagnosisOut, DTODiagnosisIn, CoreDiagnosis>, IDiagnosisServiceProvider
{
    public DiagnosisServiceProvider(IDiagnosisDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}

