using CoreDepartment = HospitalManagementSystem.Domain.Department;
using DataDepartment = HospitalManagementSystem.DataProvider.Department;

namespace HospitalManagementSystem.DataProvider;

public class DepartmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDepartment, DataDepartment>, IDepartmentDataProvider
    where TDbContext : DbContext
{
    public DepartmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}