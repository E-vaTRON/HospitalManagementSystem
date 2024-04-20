using CoreImportation = HospitalManagementSystem.Domain.Importation;
using DataImportation = HospitalManagementSystem.DataProvider.Importation;

namespace HospitalManagementSystem.DataProvider;

public class ImportationDataProvider : DataProviderBase<CoreImportation, DataImportation>, IImportationServiceProvider
{
    public ImportationDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
