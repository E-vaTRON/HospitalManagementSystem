namespace HospitalManagementSystem.Application;

public record BookingAppointmentDTO : AppointmentBaseDTO
{
    public string?          DoctorId            { get; init; } // User Id Role<Doctor>
}
