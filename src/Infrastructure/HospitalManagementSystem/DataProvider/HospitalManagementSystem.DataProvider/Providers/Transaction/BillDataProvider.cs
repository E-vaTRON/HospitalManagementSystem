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
    protected virtual async Task<IEnumerable<CoreBill>> InternalFindByUserIdAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.WhereIf(id != null, bill => id!.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
                          .ToListAsync(cancellationToken);
    }

    protected virtual async Task<IEnumerable<CoreBill>> InternalFindByUserIdIncludeEpisodeAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.MedicalExamEpisode)
                          .Include(x => x.MedicalExamEpisode.AnalysisTests).ThenInclude(y => y.Id)
                          .Include(x => x.MedicalExamEpisode.DrugPrescriptions).ThenInclude(y => y.Id)
                          .Include(x => x.MedicalExamEpisode.RoomAllocations).ThenInclude(y => y.Id)
                          .WhereIf(id != null, bill => id!.Contains(bill.MedicalExamEpisode.MedicalExam.BookingAppointment!.PatientId))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IList<CoreBill>> GetBillByMultipleUserIdAsync(string[] userIds)
    {
        var bills = await InternalFindByUserIdAsync(userIds);
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }

    public async Task<IList<CoreBill>> GetBillByUserIdAsync(string userId)
    {
        var bills = await InternalFindByUserIdAsync(new string[] { userId });
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }

    public async Task<IList<CoreBill>> GetBillIncludeEpisodeByMultipleUserIdAsync(string[] userIds)
    {
        var bills = await InternalFindByUserIdIncludeEpisodeAsync(userIds);
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }

    public async Task<IList<CoreBill>> GetBillIncludeEpisodeByUserIdAsync(string userId)
    {
        var bills = await InternalFindByUserIdIncludeEpisodeAsync(new string[] { userId });
        ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
        return bills.ToList();
    }
    #endregion
}
