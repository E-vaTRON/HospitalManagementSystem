namespace HospitalManagementSystem.Application;

public interface IDrugPrescriptionDataProvider : IDataProviderBase<DrugPrescription, string>
{
    #region [ Methods ]
    Task<IList<DrugPrescription>> GetAllIncludeDrugAsync();

    Task<IList<DrugPrescription>> GetMultipleByIdIncludeDrugAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<DrugPrescription> GetByIdIncludeDrugAsync(string id, CancellationToken cancellationToken = default);
    #endregion
}
