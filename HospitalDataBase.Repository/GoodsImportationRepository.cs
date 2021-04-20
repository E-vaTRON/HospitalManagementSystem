using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class GoodsImportationRepository : BaseRepository<GoodsImportation>, IGoodsImportationRepository
    {
        public GoodsImportationRepository(ApplicationDbContext context) : base(context) { }
    }
}
