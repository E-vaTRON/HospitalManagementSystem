namespace HospitalManagementSystem.Application;

public interface IBookingAppointmentDataProvider : IDataProviderBase<BookingAppointment, string>
{
    Task<IEnumerable<BookingAppointment>> FindByUserIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}
