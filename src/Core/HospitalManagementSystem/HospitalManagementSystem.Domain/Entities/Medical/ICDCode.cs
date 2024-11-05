namespace HospitalManagementSystem.Domain;

public class ICDCode : EntityBase
{
    public string?      Code         { get; set; }
    public string?      Condition    { get; set; }

    public string?      DiseasesId  { get; set; }
    public Diseases     Diseases    { get; set; } = default!;

    public virtual ICollection<ICDCodeVersion>  ICDCodeVersions { get; set; } = new HashSet<ICDCodeVersion>();
    public virtual ICollection<Diagnosis>       Diagnoses       { get; set; } = new HashSet<Diagnosis>();
}
