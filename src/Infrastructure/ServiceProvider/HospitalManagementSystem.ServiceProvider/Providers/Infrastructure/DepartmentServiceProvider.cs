using CoreDepartment = HospitalManagementSystem.Domain.Department;

namespace HospitalManagementSystem.ServiceProvider;

public class DepartmentServiceProvider : ServiceProviderBase<CoreDepartment>, IDepartmentServiceProvider
{
    public DepartmentServiceProvider(DepartmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
