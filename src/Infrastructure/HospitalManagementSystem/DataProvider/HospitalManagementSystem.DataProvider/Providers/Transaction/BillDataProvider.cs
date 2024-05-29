using CoreBill = HospitalManagementSystem.Domain.Bill;
using DataBill = HospitalManagementSystem.DataProvider.Bill;

namespace HospitalManagementSystem.DataProvider;

public class BillDataProvider : DataProviderBase<CoreBill, DataBill>, IBillDataProvider
{
    public BillDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
