namespace HospitalManagementSystem.ServiceProvider;

public class PatientRepository : BaseRepository<Domain.Patient>, IPatientRepository
{
    public PatientRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
