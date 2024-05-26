using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DTODrugPrescriptionIn = HospitalManagementSystem.Application.InputDrugPrescriptionDTO;
using DTODrugPrescriptionOut = HospitalManagementSystem.Application.OutputDrugPrescriptionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugPrescriptionServiceProvider : ServiceProviderBase<DTODrugPrescriptionOut, DTODrugPrescriptionIn, CoreDrugPrescription>, IDrugPrescriptionServiceProvider
{
    public DrugPrescriptionServiceProvider(IDrugPrescriptionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
