namespace HospitalManagementSystem.Domain;

public class ICDVersion : EntityBase
{
    public string? Version { get; set; }
    public virtual ICollection<ICDCodeVersion> ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
}
