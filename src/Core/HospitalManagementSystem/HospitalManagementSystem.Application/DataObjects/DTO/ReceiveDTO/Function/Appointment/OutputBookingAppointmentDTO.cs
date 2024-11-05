namespace HospitalManagementSystem.Application;

public record OutputBookingAppointmentDTO : BookingAppointmentDTO
{
    public OutputMedicalExamDTO? MedicalExam { get; init; }
}
