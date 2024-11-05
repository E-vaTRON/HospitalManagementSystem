namespace HospitalManagementSystem.Application;

public record InputMedicalDeviceFormDTO : MedicalDeviceFormDTO
{
    public string? MedicalDeviceId  { get; init; }
    public string? FormTypeId       { get; init; }
}