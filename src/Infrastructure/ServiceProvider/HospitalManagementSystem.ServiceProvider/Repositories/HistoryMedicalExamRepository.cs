namespace HospitalManagementSystem.ServiceProvider;

public class HistoryMedicalExamRepository : BaseRepository<HistoryMedicalExam>, IHistoryMedicalExamRepository
{
    public HistoryMedicalExamRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
