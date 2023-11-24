namespace HospitalManagementSystem.ServiceProvider;

public class HistoryMedicalExamRepository : BaseRepository<Domain.HistoryMedicalExam>, IHistoryMedicalExamRepository
{
    public HistoryMedicalExamRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
