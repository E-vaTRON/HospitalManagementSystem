namespace HospitalManagementSystem.ServiceProvider;

public class DoctorRepository : BaseRepository<Domain.Doctor>, IDoctorRepository
{
    public DoctorRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
