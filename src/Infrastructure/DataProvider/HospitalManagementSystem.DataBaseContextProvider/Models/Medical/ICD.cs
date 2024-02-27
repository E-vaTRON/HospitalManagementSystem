namespace HospitalManagementSystem.DataProvider;

public class ICD : ModelBase
{
    public string       Code        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public ICDStatus    Status      { get; set; }

    public virtual ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
}