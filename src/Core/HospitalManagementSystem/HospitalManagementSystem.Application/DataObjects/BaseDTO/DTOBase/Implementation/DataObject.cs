namespace HospitalManagementSystem.Application;

[Serializable]
public abstract record DataObject : IDataObject
{
}

[Serializable]
public abstract record DataObject<TId> : DataObject, IDataObject<TId>
{
    public virtual TId Id { get; set; } = default!;

    protected DataObject() { }

    protected DataObject(TId id)
    {
        Id = id;
    }
}