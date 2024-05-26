namespace HospitalManagementSystem.Application;

public record InputMedicalExamDTO : MedicalExamDTO
{
    public string? BookingAppointmentDTOId { get; init; }
}