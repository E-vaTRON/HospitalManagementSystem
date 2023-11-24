namespace HospitalManagementSystem.ServiceProvider;

public class UserRepository : BaseRepository<Domain.User>, IUserRepository
{
    public UserRepository(HospitalManagementSystemDbContext context) : base(context) { }
}