namespace HospitalManagementSystem.Application;

public class DiagnosisTreatmentDTO : DTOBase
{
    public string? Order    { get; set; }
    public string? Note     { get; set; }

    public TreatmentDTO        TreatmentDTO           { get; set; } = default!;
    public DiagnosisDTO        DiagnosisDTO           { get; set; } = default!;
}
