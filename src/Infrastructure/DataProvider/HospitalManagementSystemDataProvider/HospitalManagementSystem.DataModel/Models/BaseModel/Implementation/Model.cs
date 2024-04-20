namespace HospitalManagementSystem.DataProvider;

[Serializable]
public abstract class Model : IModel
{
    public abstract object[] GetKeys();
}

[Serializable]
public abstract class Model<TMId> : Model, IModel<TMId>
{
    public virtual TMId Id { get; set; } = default!;

    protected Model()
    {
    }

    protected Model(TMId id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return [Id!];
    }
}