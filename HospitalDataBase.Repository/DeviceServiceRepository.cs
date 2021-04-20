using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class DeviceServiceRepository : BaseRepository<DeviceService>, IDeviceServiceRepository
    {
        public DeviceServiceRepository(ApplicationDbContext context) : base(context) { }
    }
}
