using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalDataBase.Repository
{
    public class AnalysationTestRepository : BaseRepository<AnalysationTest>, IAnalysationTestRepository
    {
        public AnalysationTestRepository(ApplicationDbContext context) : base(context) { }

        //public override IQueryable<AnalysationTest> FindAll(Expression<Func<AnalysationTest, bool>>? predicate = null)
        //    => _dbSet
        //    .WhereIf(predicate != null, predicate!)
        //    .Include(a => a.HistoryMedicalExam)
        //    .ThenInclude(a => a!.Patient);

        //public async Task<AnalysationTest> FindAllID(string examID, CancellationToken cancellationToken = default)
        //    => await FindAll(a => a.ExamID == examID)
        //    .FirstOrDefaultAsync(cancellationToken);

        //public async Task<AnalysationTest> FindByCode(string examID, CancellationToken cancellationToken = default)
        //    => await FindAll()
        //    .Where(a => a.ExamID == examID)
        //    .FirstOrDefaultAsync(cancellationToken);
    }
}
