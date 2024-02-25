namespace HospitalManagementSystem.DataBaseContextProvider;

public class ModelBase : Model<string>
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public ModelBase()
    {
        Id = string.Empty;
        IsDeleted = false;
    }
}