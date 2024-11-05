using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DataBookingAppointment = HospitalManagementSystem.DataProvider.BookingAppointment;

namespace HospitalManagementSystem.DataProvider;

public class BookingAppointmentDataProvider : DataProviderBase<CoreBookingAppointment, DataBookingAppointment>, IBookingAppointmentDataProvider
{
    #region [ CTor ]
    public BookingAppointmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<CoreBookingAppointment>> FindByUserIdAsync(string[] ids, CancellationToken cancellationToken)
    {
        var query = await GetQueryableAsync();

        return await query.Where(booking => ids.Contains(booking.PatientId))
                          .ToListAsync(cancellationToken);
    }
    #endregion
}
