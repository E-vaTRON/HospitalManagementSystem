namespace HospitalManagementSystem.Application;

public record OutputReExamAppointmentDTO : ReExamAppointmentDTO
{
    public MedicalExamEpisodeDTO? MedicalExamEpisodeDTO { get; init; }
}
