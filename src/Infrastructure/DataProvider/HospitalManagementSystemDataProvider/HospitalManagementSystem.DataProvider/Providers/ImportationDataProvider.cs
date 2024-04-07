using CoreImportation = HospitalManagementSystem.Domain.Importation;
using DataImportation = HospitalManagementSystem.DataProvider.Importation;

namespace HospitalManagementSystem.DataProvider;

public class ImportationDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreImportation, DataImportation>, IImportationDataProvider
    where TDbContext : DbContext
{
    public ImportationDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
