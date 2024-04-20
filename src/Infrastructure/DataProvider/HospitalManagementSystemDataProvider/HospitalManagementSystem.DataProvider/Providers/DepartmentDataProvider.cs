using CoreDepartment = HospitalManagementSystem.Domain.Department;
using DataDepartment = HospitalManagementSystem.DataProvider.Department;

namespace HospitalManagementSystem.DataProvider;

public class DepartmentDataProvider : DataProviderBase<CoreDepartment, DataDepartment>, IDepartmentServiceProvider
{
    public DepartmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}