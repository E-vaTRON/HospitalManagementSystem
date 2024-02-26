namespace HospitalManagementSystem.DataProvider;

[Serializable]
public abstract class Model : IModel
{
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
}