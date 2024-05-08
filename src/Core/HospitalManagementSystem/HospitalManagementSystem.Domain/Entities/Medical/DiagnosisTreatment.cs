namespace HospitalManagementSystem.Domain;

public class DiagnosisTreatment : EntityBase
{
    public string? Order    { get; set; }
    public string? Note     { get; set; }

    public string?          TreatmentId         { get; set; }
    public Treatment        Treatment           { get; set; } = default!;
    public string?          DiagnosisId         { get; set; }
    public Diagnosis        Diagnosis           { get; set; } = default!;
}
