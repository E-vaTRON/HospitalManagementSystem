namespace HospitalManagementSystem.Domain;

public class MedicalExam : EntityBase
{
    public string?  PatientID    { get; set; }       //mã số bệnh nhân
    public Patient  Patient      { get; set; } = default!;

    public virtual ICollection<MedicalExamEposode> MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
}