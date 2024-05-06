using CoreImportation = HospitalManagementSystem.Domain.Importation;

namespace HospitalManagementSystem.ServiceProvider;

public class ImportationServiceProvider : ServiceProviderBase<CoreImportation>, IImportationServiceProvider
{
    public ImportationServiceProvider(ImportationDataProvider dataProvider) : base(dataProvider)
    {
    }
}
