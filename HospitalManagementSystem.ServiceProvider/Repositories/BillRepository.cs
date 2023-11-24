namespace HospitalManagementSystem.ServiceProvider;

public class BillRepository : BaseRepository<Domain.Bill> , IBillRepository
{
    public BillRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
