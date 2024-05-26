namespace HospitalManagementSystem.Application;

public record InputAnalysisTestDTO : AnalysisTestDTO
{
    public string? DeviceServiceDTOId       { get; init; }
    public string? MedicalExamEpisodeDTOId  { get; init; }
}