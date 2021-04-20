using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.Repository
{
    public class HistoryMedicalExamRepository : BaseRepository<HistoryMedicalExam>, IHistoryMedicalExamRepository
    {
        public HistoryMedicalExamRepository(ApplicationDbContext context) : base(context) { }
    }
}
