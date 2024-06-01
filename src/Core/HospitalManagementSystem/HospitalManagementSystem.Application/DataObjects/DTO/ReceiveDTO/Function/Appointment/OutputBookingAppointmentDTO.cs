namespace HospitalManagementSystem.Application;

public record OutputBookingAppointmentDTO : BookingAppointmentDTO
{
    public OutputMedicalExamDTO? MedicalExamDTO { get; init; }
}
