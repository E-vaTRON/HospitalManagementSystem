using CoreDepartment = HospitalManagementSystem.Domain.Department;
using DTODepartmentIn = HospitalManagementSystem.Application.InputDepartmentDTO;
using DTODepartmentOut = HospitalManagementSystem.Application.OutputDepartmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DepartmentServiceProvider : ServiceProviderBase<DTODepartmentOut, DTODepartmentIn, CoreDepartment>, IDepartmentServiceProvider
{
    public DepartmentServiceProvider(IDepartmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
