namespace HospitalManagementSystem.Application;

public class ReExamAppointmentDTO : AppointmentBaseDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO { get; set; } = default!;
}
