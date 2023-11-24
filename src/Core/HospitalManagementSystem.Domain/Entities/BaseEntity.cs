namespace HospitalManagementSystem.Domain;

public class BaseEntity
{
    public virtual string Id { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; }
}
