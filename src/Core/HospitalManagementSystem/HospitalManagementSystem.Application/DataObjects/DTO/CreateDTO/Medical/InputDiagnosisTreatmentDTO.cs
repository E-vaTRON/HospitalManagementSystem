namespace HospitalManagementSystem.Application;

public record InputDiagnosisTreatmentDTO : DiagnosisTreatmentDTO
{
    public string? TreatmentDTOId   { get; init; }
    public string? DiagnosisDTOId   { get; init; }
}