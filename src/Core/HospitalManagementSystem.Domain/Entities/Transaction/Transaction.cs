namespace HospitalManagementSystem.Domain;

public class Transaction : EntityBase
{
    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
}