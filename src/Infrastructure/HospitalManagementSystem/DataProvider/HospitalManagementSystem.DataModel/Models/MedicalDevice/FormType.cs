namespace HospitalManagementSystem.DataProvider;

public class FormType : ModelBase
{
    public string   Name                { get; set; } = string.Empty;
    public string?  Description         { get; set; }
    public string?  DocumentPath        { get; set; }

    public virtual ICollection<MedicalDeviceForm> MedicalDeviceForms { get; set; } = new HashSet<MedicalDeviceForm>();
}

