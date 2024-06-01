using CoreBill = HospitalManagementSystem.Domain.Bill;
using DTOBillIn = HospitalManagementSystem.Application.InputBillDTO;
using DTOBillOut = HospitalManagementSystem.Application.OutputBillDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class BillServiceProvider : ServiceProviderBase<DTOBillOut, DTOBillIn, CoreBill>, IBillServiceProvider
{
    #region [ Fields ]
    protected readonly IBillDataProvider BillDataProvider;
    #endregion

    #region [ CTor ]
    public BillServiceProvider(IBillDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        BillDataProvider = dataProvider;
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IList<DTOBillOut>> GetBillByMultipleUserIdAsync(string[] userIds, bool includeEpisode)
    {
        ArgumentNullException.ThrowIfNull(userIds, nameof(userIds));
        IList<CoreBill> bills;
        if (includeEpisode) 
            bills = await BillDataProvider.GetBillByMultipleUserIdAsync(userIds);
        else
            bills = await BillDataProvider.GetBillIncludeEpisodeByMultipleUserIdAsync(userIds);
        ArgumentNullException.ThrowIfNull(bills, nameof(bills));
        return MapToDTOs(bills).ToList();
    }

    public async Task<IList<DTOBillOut>> GetBillByUserIdAsync(string userId, bool includeEpisode)
    {
        ArgumentNullException.ThrowIfNull(userId, nameof(userId));
        IList<CoreBill> bills;
        if (includeEpisode)
            bills = await BillDataProvider.GetBillByUserIdAsync(userId);
        else
            bills = await BillDataProvider.GetBillIncludeEpisodeByUserIdAsync(userId);
        ArgumentNullException.ThrowIfNull(bills, nameof(bills));
        return MapToDTOs(bills).ToList();
    }
    #endregion
}
