namespace HospitalManagementSystem.Application;

public record OutputDiagnosisTreatmentDTO : DiagnosisTreatmentDTO
{
    public OutputTreatmentDTO? TreatmentDTO   { get; init; }
    public OutputDiagnosisDTO? DiagnosisDTO   { get; init; }
}