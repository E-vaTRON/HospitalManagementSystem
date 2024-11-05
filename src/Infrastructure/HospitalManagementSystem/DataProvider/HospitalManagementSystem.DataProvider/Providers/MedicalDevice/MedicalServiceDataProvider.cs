using CoreService = HospitalManagementSystem.Domain.MedicalService;
using DataService = HospitalManagementSystem.DataProvider.MedicalService;

namespace HospitalManagementSystem.DataProvider;

public class MedicalServiceDataProvider : DataProviderBase<CoreService, DataService>, IMedicalServiceDataProvider
{
    #region [ CTor ]
    public MedicalServiceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    #endregion

    #region [ Public Methods ]
    //public async Task<IList<CoreService>> GetBillByMultipleUserIdAsync(string[] userIds)
    //{
    //    var bills = await InternalFindByUserIdAsync(userIds);
    //    ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
    //    return bills.ToList();
    //}
    #endregion
}
