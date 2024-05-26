using DTODrugIn = HospitalManagementSystem.Application.InputDrugDTO;
using DTODrugOut = HospitalManagementSystem.Application.OutputDrugDTO;

namespace HospitalManagementSystem.REST;

public class DrugController : BaseHMSController<DTODrugOut, DTODrugIn>
{
    public DrugController(IDrugServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
