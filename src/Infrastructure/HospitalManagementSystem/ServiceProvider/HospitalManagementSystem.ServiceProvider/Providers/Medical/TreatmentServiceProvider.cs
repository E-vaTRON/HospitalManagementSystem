using CoreTreatment = HospitalManagementSystem.Domain.Treatment;
using DTOTreatment = HospitalManagementSystem.Application.TreatmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class TreatmentServiceProvider : ServiceProviderBase<DTOTreatment, CoreTreatment>, ITreatmentServiceProvider
{
    public TreatmentServiceProvider(ITreatmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}