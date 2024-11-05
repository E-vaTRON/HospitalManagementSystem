namespace HospitalManagementSystem.Application;

public record OutputDiagnosisTreatmentDTO : DiagnosisTreatmentDTO
{
    public OutputTreatmentDTO? Treatment   { get; init; }
    public OutputDiagnosisDTO? Diagnosis   { get; init; }
}