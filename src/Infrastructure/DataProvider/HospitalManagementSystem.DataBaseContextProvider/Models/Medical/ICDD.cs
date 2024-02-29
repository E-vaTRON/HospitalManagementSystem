namespace HospitalManagementSystem.DataProvider;

public class ICDD : ModelBase
{
    public string       Code        { get; set; } = string.Empty;
    public string?      Description { get; set; }
    public CodeStatus   Status      { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new HashSet<Diagnosis>();
}