namespace HospitalManagementSystem.Application;

public record OutputReExamAppointmentDTO : ReExamAppointmentDTO
{
    public OutputMedicalExamEpisodeDTO? MedicalExamEpisodeDTO { get; init; }
}
