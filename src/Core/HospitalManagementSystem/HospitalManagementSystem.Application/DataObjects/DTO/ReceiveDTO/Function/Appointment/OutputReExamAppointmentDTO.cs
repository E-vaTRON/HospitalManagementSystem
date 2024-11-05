namespace HospitalManagementSystem.Application;

public record OutputReExamAppointmentDTO : ReExamAppointmentDTO
{
    public OutputMedicalExamEpisodeDTO? MedicalExamEpisode { get; init; }
}
