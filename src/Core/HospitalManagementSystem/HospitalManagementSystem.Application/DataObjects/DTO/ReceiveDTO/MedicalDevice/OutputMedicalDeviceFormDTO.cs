namespace HospitalManagementSystem.Application;

public record OutputMedicalDeviceFormDTO : MedicalDeviceFormDTO
{
    public MedicalDevice?   MedicalDevice   { get; init; }
    public FormType?        FormType        { get; init; }
}