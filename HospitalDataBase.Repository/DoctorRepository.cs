using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context) { }
    }
}
