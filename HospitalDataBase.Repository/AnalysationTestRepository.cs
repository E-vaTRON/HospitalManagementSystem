using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class AnalysationTestRepository : BaseRepository<AnalysationTest>, IAnalysationTestRepository
    {
        public AnalysationTestRepository(ApplicationDbContext context) : base(context) { }
    }
}
