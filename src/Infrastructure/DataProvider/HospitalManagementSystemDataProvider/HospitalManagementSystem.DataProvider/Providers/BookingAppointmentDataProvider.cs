using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DataBookingAppointment = HospitalManagementSystem.DataProvider.BookingAppointment;

namespace HospitalManagementSystem.DataProvider;

public class BookingAppointmentDataProvider : DataProviderBase<CoreBookingAppointment, DataBookingAppointment>, IBookingAppointmentDataProvider
{
    public BookingAppointmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
