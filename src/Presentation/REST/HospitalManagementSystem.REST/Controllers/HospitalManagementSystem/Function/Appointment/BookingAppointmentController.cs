using DTOBookingAppointmentIn = HospitalManagementSystem.Application.InputBookingAppointmentDTO;
using DTOBookingAppointmentOut = HospitalManagementSystem.Application.OutputBookingAppointmentDTO;

namespace HospitalManagementSystem.REST;

public class BookingAppointmentController : BaseHMSController<DTOBookingAppointmentOut, DTOBookingAppointmentIn>
{
    #region [ CTor ]
    public BookingAppointmentController(IBookingAppointmentServiceProvider serviceProvider ) : base(serviceProvider)
    {
    }
    #endregion
}
