using CoreDrug = HospitalManagementSystem.Domain.Drug;
using DataDrug = HospitalManagementSystem.DataProvider.Drug;

namespace HospitalManagementSystem.DataProvider;

public class DrugDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDrug, DataDrug>, IDrugDataProvider
    where TDbContext : DbContext
{
    public DrugDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
