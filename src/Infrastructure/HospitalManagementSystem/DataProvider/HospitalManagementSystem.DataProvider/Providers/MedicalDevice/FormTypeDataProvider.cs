using CoreFormType = HospitalManagementSystem.Domain.FormType;
using DataFormType = HospitalManagementSystem.DataProvider.FormType;

namespace HospitalManagementSystem.DataProvider;

public class FormTypeDataProvider : DataProviderBase<CoreFormType, DataFormType>, IFormTypeDataProvider
{
    #region [ CTor ]
    public FormTypeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion
}
