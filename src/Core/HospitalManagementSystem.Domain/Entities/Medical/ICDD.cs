namespace HospitalManagementSystem.Domain;

public class ICDD : EntityBase
{
    public string   Code        { get; set; } = string.Empty;
    public string?  Description { get; set; }
    public string?  Status      { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new HashSet<Diagnosis>();
}