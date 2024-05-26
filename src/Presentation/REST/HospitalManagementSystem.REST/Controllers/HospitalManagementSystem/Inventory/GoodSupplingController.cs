using DTOGoodSupplingIn = HospitalManagementSystem.Application.InputGoodSupplingDTO;
using DTOGoodSupplingOut = HospitalManagementSystem.Application.OutputGoodSupplingDTO;

namespace HospitalManagementSystem.REST;

public class GoodSupplingController : BaseHMSController<DTOGoodSupplingOut, DTOGoodSupplingIn>
{
    public GoodSupplingController(IGoodSupplingServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}