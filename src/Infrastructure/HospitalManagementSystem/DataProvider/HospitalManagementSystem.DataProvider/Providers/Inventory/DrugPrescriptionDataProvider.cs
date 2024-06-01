using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;
using DataDrugPrescription = HospitalManagementSystem.DataProvider.DrugPrescription;

namespace HospitalManagementSystem.DataProvider;

public class DrugPrescriptionDataProvider : DataProviderBase<CoreDrugPrescription, DataDrugPrescription>, IDrugPrescriptionDataProvider
{
    #region [ CTor ]
    public DrugPrescriptionDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual async Task<IEnumerable<CoreDrugPrescription>> InternalFindByIdIncludeDrugAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var mId = ParseIds(id!);
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.DrugInventory.Drug)
                          .WhereIf(id != null, service => id!.Contains(service.Id))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreDrugPrescription>> GetMultipleByIdIncludeDrugAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var drugPrescriptions = await InternalFindByIdIncludeDrugAsync(ids);
        ArgumentNullException.ThrowIfNull(drugPrescriptions, nameof(drugPrescriptions));
        return drugPrescriptions.ToList();
    }

    public async Task<CoreDrugPrescription> GetByIdIncludeDrugAsync(string id, CancellationToken cancellationToken = default)
    {
        var drugPrescriptions = await InternalFindByIdIncludeDrugAsync(new string[] { id });
        ArgumentNullException.ThrowIfNull(drugPrescriptions, nameof(drugPrescriptions));
        return drugPrescriptions.First();
    }
    #endregion
}
