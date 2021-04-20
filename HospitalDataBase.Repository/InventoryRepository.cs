using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Core.Database;

namespace HospitalDataBase.Repository
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
