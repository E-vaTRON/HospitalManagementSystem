namespace HospitalManagementSystem.Application;

public record OutputFormTypeDTO : FormTypeDTO
{
    public virtual ICollection<OutputMedicalDeviceFormDTO>? MedicalDeviceForms { get; init; }
}
