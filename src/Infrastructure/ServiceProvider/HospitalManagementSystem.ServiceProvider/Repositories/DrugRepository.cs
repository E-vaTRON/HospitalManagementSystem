namespace HospitalManagementSystem.ServiceProvider;

public class DrugRepository : BaseRepository<Domain.Drug>, IDrugRepository
{
    public DrugRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
