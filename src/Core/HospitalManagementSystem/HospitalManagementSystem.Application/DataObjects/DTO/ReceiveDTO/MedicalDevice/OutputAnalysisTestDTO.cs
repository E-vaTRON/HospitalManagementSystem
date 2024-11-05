namespace HospitalManagementSystem.Application;

public record OutputAnalysisTestDTO : AnalysisTestDTO
{
    public OutputDeviceInventoryDTO?        DeviceInventory     { get; init; }
    public OutputMedicalExamEpisodeDTO?     MedicalExamEpisode  { get; init; }
}