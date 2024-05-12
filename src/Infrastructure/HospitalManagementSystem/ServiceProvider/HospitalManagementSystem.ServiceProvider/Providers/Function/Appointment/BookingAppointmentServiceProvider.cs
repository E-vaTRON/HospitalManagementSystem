using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DTOBookingAppointment = HospitalManagementSystem.Application.BookingAppointmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class BookingAppointmentServiceProvider : ServiceProviderBase<DTOBookingAppointment, CoreBookingAppointment>, IBookingAppointmentServiceProvider
{
    public BookingAppointmentServiceProvider(IBookingAppointmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
