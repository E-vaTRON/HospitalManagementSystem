using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;

namespace HospitalManagementSystem.ServiceProvider;

public class BookingAppointmentServiceProvider : ServiceProviderBase<CoreBookingAppointment>, IBookingAppointmentServiceProvider
{
    public BookingAppointmentServiceProvider(BookingAppointmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
