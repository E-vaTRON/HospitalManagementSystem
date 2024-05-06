namespace HospitalManagementSystem.DataProvider;

public class DiagnosisTreatment : ModelBase
{
    public string? Order    { get; set; }
    public string? Note     { get; set; }

    public Guid?            TreatmentId         { get; set; }
    public Treatment        Treatment           { get; set; } = default!;
    public Guid?            DiagnosisId         { get; set; }
    public Diagnosis        Diagnosis           { get; set; } = default!;
}
