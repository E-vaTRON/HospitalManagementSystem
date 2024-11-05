namespace HospitalManagementSystem.Application;

public record OutputDeviceInventoryDTO : DeviceInventoryDTO
{
    public OutputMedicalDeviceDTO?    MedicalDevice    { get; init; }
    public OutputStorageDTO?          Storage          { get; init; }

    public virtual ICollection<OutputAnalysisTestDTO>? AnalysisTests { get; init; }
}
