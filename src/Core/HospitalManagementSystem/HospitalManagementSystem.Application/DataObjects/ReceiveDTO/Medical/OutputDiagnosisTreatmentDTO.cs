namespace HospitalManagementSystem.Application;

public record OutputDiagnosisTreatmentDTO : DiagnosisTreatmentDTO
{
    public TreatmentDTO? TreatmentDTO   { get; set; }
    public DiagnosisDTO? DiagnosisDTO   { get; set; }
}