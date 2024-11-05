using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DTOMedicalExamIn = HospitalManagementSystem.Application.InputMedicalExamDTO;
using DTOMedicalExamOut = HospitalManagementSystem.Application.OutputMedicalExamDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamServiceProvider : ServiceProviderBase<DTOMedicalExamOut, DTOMedicalExamIn, CoreMedicalExam>, IMedicalExamServiceProvider
{
    #region [ Fields ]
    protected IMedicalExamDataProvider MedicalExamDataProvider;
    #endregion

    #region [ CTor ]
    public MedicalExamServiceProvider(IMedicalExamDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        MedicalExamDataProvider = dataProvider;
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IEnumerable<DTOMedicalExamOut>> FindByBookingIdAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var medicalExams = await MedicalExamDataProvider.FindByBookingIdAsync(ids, cancellationToken);
        return MapToDTOs(medicalExams);
    }
    #endregion
}
