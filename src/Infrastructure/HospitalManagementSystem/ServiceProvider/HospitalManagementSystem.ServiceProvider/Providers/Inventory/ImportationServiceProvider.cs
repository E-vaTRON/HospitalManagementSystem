using CoreImportation = HospitalManagementSystem.Domain.Importation;
using DTOImportation = HospitalManagementSystem.Application.ImportationDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ImportationServiceProvider : ServiceProviderBase<DTOImportation, CoreImportation>, IImportationServiceProvider
{
    public ImportationServiceProvider(IImportationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
