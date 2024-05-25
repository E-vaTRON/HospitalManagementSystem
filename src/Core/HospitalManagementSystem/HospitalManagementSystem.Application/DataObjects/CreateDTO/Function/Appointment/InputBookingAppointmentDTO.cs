namespace HospitalManagementSystem.Application;

public record InputBookingAppointmentDTO : BookingAppointmentDTO
{
    public string? MedicalExamDTOId { get; init; }
}