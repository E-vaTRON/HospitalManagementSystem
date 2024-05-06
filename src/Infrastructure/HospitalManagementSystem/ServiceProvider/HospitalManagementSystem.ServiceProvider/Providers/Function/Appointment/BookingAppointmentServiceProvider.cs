using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;

namespace HospitalManagementSystem.ServiceProvider;

public class BookingAppointmentServiceProvider : ServiceProviderBase<CoreBookingAppointment>, IBookingAppointmentServiceProvider
{
    public BookingAppointmentServiceProvider(IBookingAppointmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
