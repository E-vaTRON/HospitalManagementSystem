namespace HospitalManagementSystem.Application;

public record OutputBookingAppointmentDTO : BookingAppointmentDTO
{
    public MedicalExamDTO? MedicalExamDTO { get; init; }
}
