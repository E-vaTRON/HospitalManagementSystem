using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DataDrugPrescription = HospitalManagementSystem.DataProvider.DrugPrescription;

namespace HospitalManagementSystem.DataProvider;

public class DrugPrescriptionDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDrugPrescription, DataDrugPrescription>, IDrugPrescriptionDataProvider
    where TDbContext : DbContext
{
    public DrugPrescriptionDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
