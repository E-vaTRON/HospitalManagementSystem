using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;
using DTODiagnosisTreatment = HospitalManagementSystem.Application.DiagnosisTreatmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisTreatmentServiceProvider : ServiceProviderBase<DTODiagnosisTreatment, CoreDiagnosisTreatment>, IDiagnosisTreatmentServiceProvider
{
    public DiagnosisTreatmentServiceProvider(IDiagnosisTreatmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
