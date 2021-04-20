using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class DoctorListRepository : BaseRepository<DoctorList>, IDoctorListRepository
    {
        public DoctorListRepository(ApplicationDbContext context) : base(context) { }
    }
}
