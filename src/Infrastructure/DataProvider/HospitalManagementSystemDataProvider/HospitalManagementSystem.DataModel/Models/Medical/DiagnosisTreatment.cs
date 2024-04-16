namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatment : ModelBase
{
    public Guid?        TreatmentId     { get; set; }
    public Treatment    Treatment       { get; set; } = default!;
    public Guid?        DiagnosisId     { get; set; }
    public Diagnosis    Diagnosis       { get; set; } = default!;
}
