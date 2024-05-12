using CoreDrug = HospitalManagementSystem.Domain.Drug;
using DTODrug = HospitalManagementSystem.Application.DrugDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugServiceProvider : ServiceProviderBase<DTODrug, CoreDrug>, IDrugServiceProvider
{
    public DrugServiceProvider(IDrugDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
