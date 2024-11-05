using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DTOBookingAppointmentIn = HospitalManagementSystem.Application.InputBookingAppointmentDTO;
using DTOBookingAppointmentOut = HospitalManagementSystem.Application.OutputBookingAppointmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class BookingAppointmentServiceProvider : ServiceProviderBase<DTOBookingAppointmentOut, DTOBookingAppointmentIn, CoreBookingAppointment>, IBookingAppointmentServiceProvider
{
    #region [ Fields ]
    protected readonly IBookingAppointmentDataProvider BookingAppointmentDataProvider;
    #endregion

    #region [ CTor ]
    public BookingAppointmentServiceProvider(IBookingAppointmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        BookingAppointmentDataProvider = dataProvider;
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<OutputBookingAppointmentDTO>> FindByUserIdAsync(string[] ids, CancellationToken cancellationToken)
    {
        var bookingAppointments = await BookingAppointmentDataProvider.FindByUserIdAsync(ids, cancellationToken);
        return MapToDTOs(bookingAppointments);
    }
    #endregion
}
