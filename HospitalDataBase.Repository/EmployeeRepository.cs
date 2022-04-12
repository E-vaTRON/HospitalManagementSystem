using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }
    }
}
