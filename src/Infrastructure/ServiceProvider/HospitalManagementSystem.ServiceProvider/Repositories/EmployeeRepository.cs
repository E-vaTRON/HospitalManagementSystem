namespace HospitalManagementSystem.ServiceProvider;

public class EmployeeRepository : BaseRepository<Domain.Employee>, IEmployeeRepository
{
    public EmployeeRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
