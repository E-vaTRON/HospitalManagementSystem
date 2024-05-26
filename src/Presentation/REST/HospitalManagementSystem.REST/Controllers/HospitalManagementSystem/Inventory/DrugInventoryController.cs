using DTODrugInventoryIn = HospitalManagementSystem.Application.InputDrugInventoryDTO;
using DTODrugInventoryOut = HospitalManagementSystem.Application.OutputDrugInventoryDTO;

namespace HospitalManagementSystem.REST;

public class DrugInventoryController : BaseHMSController<DTODrugInventoryOut, DTODrugInventoryIn>
{
    public DrugInventoryController(IDrugInventoryServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}