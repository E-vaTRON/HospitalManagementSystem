namespace HospitalManagementSystem.ServiceProvider;

public class SupplingRepository : BaseRepository<Domain.Suppling> , ISupplingRepository
{
    public SupplingRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
