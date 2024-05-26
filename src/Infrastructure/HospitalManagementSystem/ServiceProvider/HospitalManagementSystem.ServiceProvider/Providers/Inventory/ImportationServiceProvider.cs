using CoreImportation = HospitalManagementSystem.Domain.Importation;
using DTOImportationIn = HospitalManagementSystem.Application.InputImportationDTO;
using DTOImportationOut = HospitalManagementSystem.Application.OutputImportationDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ImportationServiceProvider : ServiceProviderBase<DTOImportationOut, DTOImportationIn, CoreImportation>, IImportationServiceProvider
{
    public ImportationServiceProvider(IImportationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
