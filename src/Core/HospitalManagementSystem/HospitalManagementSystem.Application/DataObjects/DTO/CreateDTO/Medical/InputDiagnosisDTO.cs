namespace HospitalManagementSystem.Application;

public record InputDiagnosisDTO : DiagnosisDTO
{
    public string? MedicalExamEpisodeDTOId  { get; init; }
    public string? DiseasesDTOId            { get; init; }
}
