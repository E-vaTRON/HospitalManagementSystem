using CoreBookingAppointment = HospitalManagementSystem.Domain.BookingAppointment;
using DataBookingAppointment = HospitalManagementSystem.DataProvider.BookingAppointment;

namespace HospitalManagementSystem.DataProvider;

public class BookingAppointmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreBookingAppointment, DataBookingAppointment>, IBookingAppointmentDataProvider
    where TDbContext : DbContext
{
    public BookingAppointmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
