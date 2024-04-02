namespace HospitalManagementSystem.Domain;

public class Diagnosis : EntityBase
{
    public string   DiagnosisCode   { get; set; } = string.Empty;
    public string?  Description     { get; set; }

    public string?              ICDId               { get; set; }
    public ICD                  ICD                 { get; set; } = default!;

    public virtual ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
}