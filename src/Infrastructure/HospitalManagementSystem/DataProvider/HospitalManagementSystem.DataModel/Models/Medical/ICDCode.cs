namespace HospitalManagementSystem.DataProvider;

public class ICDCode : ModelBase
{
    public string?      Code         { get; set; }

    public Guid?            DiseasesId  { get; set; }
    public virtual Diseases Diseases    { get; set; } = default!;

    public virtual ICollection<ICDCodeVersion> ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
}
