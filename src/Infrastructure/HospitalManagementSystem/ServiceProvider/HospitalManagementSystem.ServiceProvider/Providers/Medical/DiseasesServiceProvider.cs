using CoreDiseases = HospitalManagementSystem.Domain.Diseases;
using DTODiseasesIn = HospitalManagementSystem.Application.InputDiseasesDTO;
using DTODiseasesOut = HospitalManagementSystem.Application.OutputDiseasesDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiseasesServiceProvider : ServiceProviderBase<DTODiseasesOut, DTODiseasesIn, CoreDiseases>, IDiseasesServiceProvider
{
    public DiseasesServiceProvider(IDiseasesDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}