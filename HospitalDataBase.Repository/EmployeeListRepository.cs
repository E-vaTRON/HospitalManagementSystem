using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class EmployeeListRepository : BaseRepository<EmployeeList>, IEmployeeListRepository
    {
        public EmployeeListRepository(ApplicationDbContext context) : base(context) { }
    }
}
