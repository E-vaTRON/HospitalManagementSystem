using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Core.Database;

namespace HospitalDataBase.Repository
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }
    }
}
