using DTOServiceEpisodeIn = HospitalManagementSystem.Application.InputServiceEpisodeDTO;
using DTOServiceEpisodeOut = HospitalManagementSystem.Application.OutputServiceEpisodeDTO;

namespace HospitalManagementSystem.REST;

public class ServiceEpisodeController : BaseHMSController<DTOServiceEpisodeOut, DTOServiceEpisodeIn>
{
    public ServiceEpisodeController(IServiceEpisodeServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}