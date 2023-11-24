namespace HospitalManagementSystem.API;

[ApiController]
[Route("/api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BaseController : ControllerBase
{
}
