namespace HospitalManagementSystem.DataProvider;

public class ModelBase : Model<Guid>
{
    public override Guid    Id              { get; set; } = Guid.NewGuid();
    public bool             IsDeleted       { get; set; } = false;
    public DateTime         CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?        LastUpdatedOn   { get; set; }
    public DateTime?        DeleteOn        { get; set; }

    public ModelBase()
    {
        Id = Guid.NewGuid();
        IsDeleted = false;
    }
}