using CoreDepartment = HospitalManagementSystem.Domain.Department;
using DTODepartment = HospitalManagementSystem.Application.DepartmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DepartmentServiceProvider : ServiceProviderBase<DTODepartment, CoreDepartment>, IDepartmentServiceProvider
{
    public DepartmentServiceProvider(IDepartmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
