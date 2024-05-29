using CoreBill = HospitalManagementSystem.Domain.Bill;
using DTOBillIn = HospitalManagementSystem.Application.InputBillDTO;
using DTOBillOut = HospitalManagementSystem.Application.OutputBillDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class BillServiceProvider : ServiceProviderBase<DTOBillOut, DTOBillIn, CoreBill>, IBillServiceProvider
{
    public BillServiceProvider(IBillDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
