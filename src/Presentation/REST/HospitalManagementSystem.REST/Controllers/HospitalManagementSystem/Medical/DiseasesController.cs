using DTODiseasesIn = HospitalManagementSystem.Application.InputDiseasesDTO;
using DTODiseasesOut = HospitalManagementSystem.Application.OutputDiseasesDTO;

namespace HospitalManagementSystem.REST;

public class DiseasesController : BaseHMSController<DTODiseasesOut, DTODiseasesIn>
{
    public DiseasesController(IDiseasesServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}