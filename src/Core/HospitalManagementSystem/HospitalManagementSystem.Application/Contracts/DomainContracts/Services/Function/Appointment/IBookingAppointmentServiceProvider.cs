namespace HospitalManagementSystem.Application;

public interface IBookingAppointmentServiceProvider : IServiceProviderBase<OutputBookingAppointmentDTO, InputBookingAppointmentDTO, string>
{
    Task<IEnumerable<OutputBookingAppointmentDTO>> FindByUserIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}
