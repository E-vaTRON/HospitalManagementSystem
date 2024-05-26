using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DTOBookingAppointmentIn = HospitalManagementSystem.Application.InputBookingAppointmentDTO;
using DTOBookingAppointmentOut = HospitalManagementSystem.Application.OutputBookingAppointmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class BookingAppointmentServiceProvider : ServiceProviderBase<DTOBookingAppointmentOut, DTOBookingAppointmentIn, CoreBookingAppointment>, IBookingAppointmentServiceProvider
{
    public BookingAppointmentServiceProvider(IBookingAppointmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
