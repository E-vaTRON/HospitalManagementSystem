using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DTODrugPrescriptionIn = HospitalManagementSystem.Application.InputDrugPrescriptionDTO;
using DTODrugPrescriptionOut = HospitalManagementSystem.Application.OutputDrugPrescriptionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugPrescriptionServiceProvider : ServiceProviderBase<DTODrugPrescriptionOut, DTODrugPrescriptionIn, CoreDrugPrescription>, IDrugPrescriptionServiceProvider
{
    #region [ Feilds ]
    protected IDrugPrescriptionDataProvider DrugPrescriptionDataProvider;
    #endregion

    #region [ CTor ]
    public DrugPrescriptionServiceProvider(IDrugPrescriptionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        DrugPrescriptionDataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    public async Task<IList<DTODrugPrescriptionOut>> GetAllIncludeDrugAsync()
    {
        var drugPrescriptions = await DrugPrescriptionDataProvider.GetAllIncludeDrugAsync();
        return MapToDTOs(drugPrescriptions).ToList();
    }

    public async Task<DTODrugPrescriptionOut> GetByIdIncludeDrugAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        var drugPrescription = await DrugPrescriptionDataProvider.GetByIdIncludeDrugAsync(id, cancellationToken);
        return MapToDTO(drugPrescription)!;
    }

    public async Task<IList<DTODrugPrescriptionOut>> GetMultipleByIdIncludeDrugAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(ids, nameof(ids));
        var drugPrescriptions = await DrugPrescriptionDataProvider.GetMultipleByIdIncludeDrugAsync(ids, cancellationToken);
        return MapToDTOs(drugPrescriptions).ToList();
    }
    #endregion
}
