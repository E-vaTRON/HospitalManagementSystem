using DTOStorageIn = HospitalManagementSystem.Application.InputStorageDTO;
using DTOStorageOut = HospitalManagementSystem.Application.OutputStorageDTO;

namespace HospitalManagementSystem.REST;
public class StorageController : BaseHMSController<DTOStorageOut, DTOStorageIn>
{
    public StorageController(IStorageServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
