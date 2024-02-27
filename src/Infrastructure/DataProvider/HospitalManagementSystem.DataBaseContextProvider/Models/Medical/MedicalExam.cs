namespace HospitalManagementSystem.DataProvider;

public class MedicalExam : ModelBase
{
    public string?      AppointmentId { get; set; }
    public Appointment?  Appointment { get; set; } = default!;

    public virtual ICollection<MedicalExamEposode> MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
}