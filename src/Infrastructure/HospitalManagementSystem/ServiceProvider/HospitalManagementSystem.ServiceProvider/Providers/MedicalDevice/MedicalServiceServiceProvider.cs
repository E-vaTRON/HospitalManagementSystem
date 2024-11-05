using CoreService = HospitalManagementSystem.Domain.MedicalService;
using DTOServiceIn = HospitalManagementSystem.Application.InputMedicalServiceDTO;
using DTOServiceOut = HospitalManagementSystem.Application.OutputMedicalServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalServiceServiceProvider : ServiceProviderBase<DTOServiceOut, DTOServiceIn, CoreService>, IMedicalServiceServicesProvider
{
    public MedicalServiceServiceProvider(IMedicalServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
