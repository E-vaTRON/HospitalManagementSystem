namespace HospitalManagementSystem.DataProvider;

public class MedicalDeviceForm : ModelBase
{
    public Guid?            MedicalDeviceId     { get; set; }
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public Guid?            FormTypeId          { get; set; }
    public FormType         FormType            { get; set; } = default!;
}