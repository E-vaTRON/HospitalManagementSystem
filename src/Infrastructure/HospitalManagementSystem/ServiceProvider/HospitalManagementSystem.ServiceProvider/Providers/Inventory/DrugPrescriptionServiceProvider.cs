using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DTODrugPrescription = HospitalManagementSystem.Application.DrugPrescriptionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugPrescriptionServiceProvider : ServiceProviderBase<DTODrugPrescription, CoreDrugPrescription>, IDrugPrescriptionServiceProvider
{
    public DrugPrescriptionServiceProvider(IDrugPrescriptionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
