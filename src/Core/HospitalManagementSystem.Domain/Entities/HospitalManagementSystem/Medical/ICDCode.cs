namespace HospitalManagementSystem.Domain;

public class ICDCode : EntityBase
{
    public string?      Code         { get; set; }
    public virtual ICollection<ICDCodeVersion> ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
}
