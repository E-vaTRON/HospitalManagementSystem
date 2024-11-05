using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DataMedicalExam = HospitalManagementSystem.DataProvider.MedicalExam;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamDataProvider : DataProviderBase<CoreMedicalExam, DataMedicalExam>, IMedicalExamDataProvider
{
    #region [ CTor ]
    public MedicalExamDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<CoreMedicalExam>> FindByBookingIdAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync();

        return await query.Where(exam => ids.Contains(exam.BookingAppointmentId))
                          .ToListAsync(cancellationToken);
    }
    #endregion
}