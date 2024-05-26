using DTOImportationIn = HospitalManagementSystem.Application.InputImportationDTO;
using DTOImportationOut = HospitalManagementSystem.Application.OutputImportationDTO;

namespace HospitalManagementSystem.REST;

public class ImportationController : BaseHMSController<DTOImportationOut, DTOImportationIn>
{
    public ImportationController(IImportationServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}