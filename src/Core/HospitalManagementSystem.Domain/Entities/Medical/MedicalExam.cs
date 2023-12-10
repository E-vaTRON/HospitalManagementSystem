namespace HospitalManagementSystem.Domain;

public class MedicalExam : EntityBase
{
    public string? AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = default!;

    public virtual ICollection<MedicalExamEposode> MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
}