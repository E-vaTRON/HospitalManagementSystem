namespace HospitalManagementSystem.Application;

public record OutputDiagnosisTreatmentDTO : DiagnosisTreatmentDTO
{
    public TreatmentDTO? TreatmentDTO   { get; init; }
    public DiagnosisDTO? DiagnosisDTO   { get; init; }
}