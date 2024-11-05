namespace HospitalManagementSystem.Application;

public record InputAnalysisTestDTO : AnalysisTestDTO
{
    public string? DeviceInventoryDTOId     { get; init; }
    public string? MedicalExamEpisodeDTOId  { get; init; }
}