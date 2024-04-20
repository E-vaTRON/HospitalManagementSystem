using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DataDrugPrescription = HospitalManagementSystem.DataProvider.DrugPrescription;

namespace HospitalManagementSystem.DataProvider;

public class DrugPrescriptionDataProvider : DataProviderBase<CoreDrugPrescription, DataDrugPrescription>, IDrugPrescriptionServiceProvider
{
    public DrugPrescriptionDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
