namespace HospitalManagementSystem.ServiceProvider;

public class GoodsImportationRepository : BaseRepository<Domain.GoodsImportation>, IGoodsImportationRepository
{
    public GoodsImportationRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
