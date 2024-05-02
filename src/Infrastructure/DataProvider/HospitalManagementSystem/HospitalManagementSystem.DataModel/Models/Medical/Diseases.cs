namespace HospitalManagementSystem.DataProvider;

public class Diseases : ModelBase
{
    public string       Code        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public CodeStatus   Status      { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new HashSet<Diagnosis>();
    public virtual ICollection<ICDCode>   ICDCodes  { get; set; } = new HashSet<ICDCode>();
}