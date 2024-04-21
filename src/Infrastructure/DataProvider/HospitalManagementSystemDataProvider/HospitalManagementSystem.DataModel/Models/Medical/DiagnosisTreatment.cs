namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatment : ModelBase
{
    public Guid?                TreatmentId     { get; set; }
    public virtual Treatment    Treatment       { get; set; } = default!;
    public Guid?                DiagnosisId     { get; set; }
    public virtual Diagnosis    Diagnosis       { get; set; } = default!;
}
