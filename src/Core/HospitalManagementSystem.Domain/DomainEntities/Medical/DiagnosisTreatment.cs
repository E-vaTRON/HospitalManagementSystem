namespace HospitalManagementSystem.Domain;

public class DiagnosisTreatment : EntityBase
{
    public string?              TreatmentId     { get; set; }
    public virtual Treatment    Treatment       { get; set; } = default!;
    public string?              DiagnosisId     { get; set; }
    public virtual Diagnosis    Diagnosis       { get; set; } = default!;
}
