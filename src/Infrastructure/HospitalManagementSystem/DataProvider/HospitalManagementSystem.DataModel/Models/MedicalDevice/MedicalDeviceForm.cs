namespace HospitalManagementSystem.DataProvider;

public class MedicalDeviceForm : ModelBase
{
    public string           MedicalDeviceId     { get; set; } = string.Empty;
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public string           FormTypeId          { get; set; } = string.Empty;
    public FormType         FormType            { get; set; } = default!;
}