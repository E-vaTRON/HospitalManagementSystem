namespace HospitalManagementSystem.Domain;

public class ReExamAppointment : AppointmentBase
{
    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;
}
