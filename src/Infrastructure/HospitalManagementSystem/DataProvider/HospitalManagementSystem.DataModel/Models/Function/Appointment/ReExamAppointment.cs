namespace HospitalManagementSystem.DataProvider;

public class ReExamAppointment : AppointmentBase
{
    public Guid?                MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode?  MedicalExamEpisode      { get; set; } = default!;
}
