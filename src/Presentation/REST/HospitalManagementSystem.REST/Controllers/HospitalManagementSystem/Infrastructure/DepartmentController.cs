using DTODepartmentIn = HospitalManagementSystem.Application.InputDepartmentDTO;
using DTODepartmentOut = HospitalManagementSystem.Application.OutputDepartmentDTO;

namespace HospitalManagementSystem.REST;

public class DepartmentController : BaseHMSController<DTODepartmentOut, DTODepartmentIn>
{
    public DepartmentController(IDepartmentServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
