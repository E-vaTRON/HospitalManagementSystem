namespace HospitalManagementSystem.Application;

public record InputReExamAppointmentDTO : ReExamAppointmentDTO
{
    public string? MedicalExamEpisodeDTOId { get; init; }
}
