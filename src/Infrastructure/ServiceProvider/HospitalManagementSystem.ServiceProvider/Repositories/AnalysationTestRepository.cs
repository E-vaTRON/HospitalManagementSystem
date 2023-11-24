namespace HospitalManagementSystem.ServiceProvider;

public class AnalyzationTestRepository : BaseRepository<Domain.AnalyzationTest>, IAnalyzationTestRepository
{
    public AnalyzationTestRepository(HospitalManagementSystemDbContext context) : base(context) { }

    public override IQueryable<Domain.AnalyzationTest> FindAll(Expression<Func<Domain.AnalyzationTest, bool>>? predicate = null)
        => _dbSet
        .WhereIf(predicate != null, predicate!)
        .Include(a => a.HistoryMedicalExam)
        .ThenInclude(a => a!.Patient);

    public async Task<Domain.AnalyzationTest?> FindAllID(string examID, CancellationToken cancellationToken = default)
    {
        var analyzationTest = await FindAll(a => a.ExamID == examID).FirstOrDefaultAsync(cancellationToken);
        if (analyzationTest == null)
            return null;

        return analyzationTest;
    }

    public async Task<Domain.AnalyzationTest> FindByCode(string examID, CancellationToken cancellationToken = default)
    {
        var analyzationTest = await FindAll().Where(a => a.ExamID == examID).FirstOrDefaultAsync(cancellationToken);
        if (analyzationTest == null)
            return null;

        return analyzationTest;
    }
}
