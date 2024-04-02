namespace HospitalManagementSystem.Domain;

public class Treatment : EntityBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<MedicalExamEposode>  MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Diagnosis>           Diagnoses           { get; set; } = new HashSet<Diagnosis>();
}
