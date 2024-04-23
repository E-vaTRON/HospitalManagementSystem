namespace HospitalManagementSystem.DataProvider;

public class ReExamAppointment : AppointmentBase
{
    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode?  MedicalExamEposode      { get; set; } = default!;
}
