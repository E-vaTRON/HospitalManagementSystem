namespace HospitalManagementSystem.Application;

public record OutputAnalysisTestDTO : AnalysisTestDTO
{
    public DeviceServiceDTO?        DeviceServiceDTO        { get; init; }
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
}