namespace HospitalManagementSystem.Application;

public interface IDrugPrescriptionServiceProvider : IServiceProviderBase<OutputDrugPrescriptionDTO, InputDrugPrescriptionDTO, string>
{
    #region [ Methods ]
    Task<IList<OutputDrugPrescriptionDTO>> GetMultipleByIdIncludeDrugAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<OutputDrugPrescriptionDTO> GetByIdIncludeDrugAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
