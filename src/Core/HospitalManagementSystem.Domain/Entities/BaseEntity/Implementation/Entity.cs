namespace HospitalManagementSystem.Domain;

[Serializable]
public abstract class Entity : IEntity
{
}

[Serializable]
public abstract class Entity<TId> : Entity, IEntity<TId>
{
    public virtual TId Id { get; set; } = default!;

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }
}