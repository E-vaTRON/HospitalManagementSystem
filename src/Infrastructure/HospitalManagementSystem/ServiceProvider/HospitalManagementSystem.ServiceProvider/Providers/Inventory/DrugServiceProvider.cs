using CoreDrug = HospitalManagementSystem.Domain.Drug;
using DTODrugIn = HospitalManagementSystem.Application.InputDrugDTO;
using DTODrugOut = HospitalManagementSystem.Application.OutputDrugDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugServiceProvider : ServiceProviderBase<DTODrugOut, DTODrugIn, CoreDrug>, IDrugServiceProvider
{
    public DrugServiceProvider(IDrugDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}