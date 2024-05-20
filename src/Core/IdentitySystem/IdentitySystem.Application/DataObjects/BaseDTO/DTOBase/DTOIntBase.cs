namespace IdentitySystem.Application;

public class DTOIntBase : DataObject<int>
{
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; }
    public DateTime? DeleteOn { get; set; }

    public DTOIntBase()
    {
        IsDeleted = false;
    }
}
