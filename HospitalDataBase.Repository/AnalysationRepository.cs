using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class AnalysationRepository : BaseRepository<Analysation>, IAnalysationRepository
    {
        public AnalysationRepository(ApplicationDbContext context) : base(context) { }
    }
}
