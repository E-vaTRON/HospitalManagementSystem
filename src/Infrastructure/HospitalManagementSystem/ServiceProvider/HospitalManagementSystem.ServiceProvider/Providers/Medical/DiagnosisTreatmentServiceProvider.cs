using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;
using DTODiagnosisTreatmentIn = HospitalManagementSystem.Application.InputDiagnosisTreatmentDTO;
using DTODiagnosisTreatmentOut = HospitalManagementSystem.Application.OutputDiagnosisTreatmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisTreatmentServiceProvider : ServiceProviderBase<DTODiagnosisTreatmentOut, DTODiagnosisTreatmentIn, CoreDiagnosisTreatment>, IDiagnosisTreatmentServiceProvider
{
    public DiagnosisTreatmentServiceProvider(IDiagnosisTreatmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
