namespace HospitalManagementSystem.REST;

public class BookingAppointmentController : BaseHMSController<BookingAppointmentDTO>
{
    #region [ CTor ]
    public BookingAppointmentController(IBookingAppointmentServiceProvider serviceProvider ) : base( serviceProvider )
    {
    }
    #endregion
}
