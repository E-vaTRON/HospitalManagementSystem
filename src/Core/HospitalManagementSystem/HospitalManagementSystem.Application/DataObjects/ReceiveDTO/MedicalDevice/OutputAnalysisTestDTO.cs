namespace HospitalManagementSystem.Application;

public record OutputAnalysisTestDTO : AnalysisTestDTO
{
    public DeviceServiceDTO?        DeviceServiceDTO        { get; set; }
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; set; }
}