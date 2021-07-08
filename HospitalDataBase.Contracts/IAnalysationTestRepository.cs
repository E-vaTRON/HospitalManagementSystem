using HospitalDataBase.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalDataBase.Contracts
{
    public interface IAnalysationTestRepository : IBaseRepository<AnalysationTest>
    {
        //Task<AnalysationTest> FindAllID(string patientID, CancellationToken cancellationToken = default);

        //Task<AnalysationTest> FindByCode(string examID, CancellationToken cancellationToken = default);
    }
}
