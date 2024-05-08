namespace HospitalManagementSystem.Domain;

public class Treatment : EntityBase
{
    public string   Name        { get; set; } = string.Empty;
    public string   Details     { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<DiagnosisTreatment> DiagnosisTreatments { get; set; } = new HashSet<DiagnosisTreatment>();
}
