namespace HospitalManagementSystem.Application;

public record OutputAnalysisTestDTO : AnalysisTestDTO
{
    public OutputDeviceServiceDTO?        DeviceServiceDTO        { get; init; }
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
}