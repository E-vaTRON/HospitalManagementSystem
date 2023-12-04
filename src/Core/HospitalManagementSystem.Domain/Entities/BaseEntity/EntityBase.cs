namespace HospitalManagementSystem.Domain;

public class EntityBase : Entity<string> , IHasCreatedOn , IHasLastUpdatedOn, IHasDeleteOn
{
    public override string Id { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; }
    public DateTime? DeleteOn { get; set; }

    public EntityBase()
    {
        Id = string.Empty;
        IsDeleted = false;
    }
}