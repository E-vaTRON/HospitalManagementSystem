namespace HospitalManagementSystem.DataProvider;

public class ICDCode : ModelBase
{
    public string?      Code         { get; set; }
    public virtual ICollection<ICDCodeVersion> ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
}
