namespace HospitalManagementSystem.DataProvider;

public class ICDVersion : ModelBase
{
    public string? Version { get; set; }
    public virtual ICollection<ICDCodeVersion> ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
}
