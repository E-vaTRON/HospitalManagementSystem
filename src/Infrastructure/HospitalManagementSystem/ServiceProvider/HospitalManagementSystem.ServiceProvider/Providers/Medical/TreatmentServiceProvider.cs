using CoreTreatment = HospitalManagementSystem.Domain.Treatment;
using DTOTreatmentIn = HospitalManagementSystem.Application.InputTreatmentDTO;
using DTOTreatmentOut = HospitalManagementSystem.Application.OutputTreatmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class TreatmentServiceProvider : ServiceProviderBase<DTOTreatmentOut, DTOTreatmentIn, CoreTreatment>, ITreatmentServiceProvider
{
    public TreatmentServiceProvider(ITreatmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}