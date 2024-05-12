using CoreDiseases = HospitalManagementSystem.Domain.Diseases;
using DTODiseases = HospitalManagementSystem.Application.DiseasesDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiseasesServiceProvider : ServiceProviderBase<DTODiseases, CoreDiseases>, IDiseasesServiceProvider
{
    public DiseasesServiceProvider(IDiseasesDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
