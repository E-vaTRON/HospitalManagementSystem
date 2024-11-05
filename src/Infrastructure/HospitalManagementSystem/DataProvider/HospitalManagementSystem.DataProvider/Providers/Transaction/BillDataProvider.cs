using Microsoft.EntityFrameworkCore;
using System.Threading;
using CoreBill = HospitalManagementSystem.Domain.Bill;
using DataBill = HospitalManagementSystem.DataProvider.Bill;

namespace HospitalManagementSystem.DataProvider;

public class BillDataProvider : DataProviderBase<CoreBill, DataBill>, IBillDataProvider
{
    #region [ CTor ]
    public BillDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual Task<IQueryable<CoreBill>> InternalGetQueryableIncludeRelatedAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.Include(x => x.MedicalExamEpisode)
                                    .Include(x => x.MedicalExamEpisode.AnalysisTests).ThenInclude(y => y.Id)
                                    .Include(x => x.MedicalExamEpisode.DrugPrescriptions).ThenInclude(y => y.Id)
                                    .Include(x => x.MedicalExamEpisode.RoomAllocations).ThenInclude(y => y.Id)
                                    .ProjectTo<CoreBill>(Mapper.ConfigurationProvider));
    }


    protected virtual async Task<IEnumerable<CoreBill>> InternalFindByUserIdAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        //return await query.WhereIf(id != null, bill => id!.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
        //                  .ToListAsync(cancellationToken);

        //return await query.Where(bill => id!.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId)).IgnoreAutoIncludes()
        //                  .ToListAsync(cancellationToken);

        return await query.Where(bill => id.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
                          .ToListAsync(cancellationToken);
    }

    //protected virtual async Task<IEnumerable<CoreBill>> InternalFindByUserIdIncludeEpisodeAsync(string[] id, CancellationToken cancellationToken = default)
    //{
    //    var query = await GetQueryableAsync(false, cancellationToken);

    //    return await query.Include(x => x.MedicalExamEpisode)
    //                      .Include(x => x.MedicalExamEpisode.AnalysisTests).ThenInclude(y => y.Id)
    //                      .Include(x => x.MedicalExamEpisode.DrugPrescriptions).ThenInclude(y => y.Id)
    //                      .Include(x => x.MedicalExamEpisode.RoomAllocations).ThenInclude(y => y.Id)
    //                      .WhereIf(id != null, bill => id!.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
    //                      .ToListAsync(cancellationToken);
    //}
    #endregion

    #region [ Public Methods ]
    public async Task<IList<CoreBill>> GetBillByMultipleUserIdAsync(string[] userIds, CancellationToken cancellationToken)
    {
        var bills = await InternalFindByUserIdAsync(userIds);
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }

    public async Task<IList<CoreBill>> GetBillByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var bills = await InternalFindByUserIdAsync(new string[] { userId });
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }

    public async Task<IList<CoreBill>> GetBillIncludeEpisodeByMultipleUserIdAsync(string[] userIds, CancellationToken cancellationToken)
    {
        var query = await InternalGetQueryableIncludeRelatedAsync();
        return await query.Where(bill => userIds.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
                          .ToListAsync(cancellationToken);
    }

    public async Task<IList<CoreBill>> GetBillIncludeEpisodeByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var query = await InternalGetQueryableIncludeRelatedAsync();
        return await query.Where(bill => bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId!.Equals(userId))
                          .ToListAsync(cancellationToken);
    }
    #endregion
}
