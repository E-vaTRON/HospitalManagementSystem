namespace HospitalManagementSystem.Application;

public record DiagnosisDTO : DTOBase
{
    public string   DiagnosisCode   { get; init; } = string.Empty;
    public string?  Symptom         { get; init; }        // Làm bản riêng ?????
    public string?  Description     { get; init; }
}