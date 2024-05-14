namespace IdentitySystem.Application;

[Serializable]
public abstract class DataObject : IDataObject
{
}

[Serializable]
public abstract class DataObject<TId> : DataObject, IDataObject<TId>
{
    public virtual TId Id { get; set; } = default!;

    protected DataObject()
    {
    }

    protected DataObject(TId id)
    {
        Id = id;
    }
}