using CoreFormType = HospitalManagementSystem.Domain.FormType;
using DTOFormTypeIn = HospitalManagementSystem.Application.InputFormTypeDTO;
using DTOFormTypeOut = HospitalManagementSystem.Application.OutputFormTypeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class FormTypeServiceProvider : ServiceProviderBase<DTOFormTypeOut, DTOFormTypeIn, CoreFormType>, IFormTypeServiceProvider
{
    #region [ Methods ]
    public FormTypeServiceProvider(IFormTypeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
