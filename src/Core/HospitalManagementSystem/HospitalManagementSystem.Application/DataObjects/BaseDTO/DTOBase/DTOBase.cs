namespace HospitalManagementSystem.Application;

public class DTOBase : DataObject<string>
{
    public override string  Id              { get; set; } = string.Empty;
    public bool             IsDeleted       { get; set; } = false;
    public DateTime         CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?        LastUpdatedOn   { get; set; }
    public DateTime?        DeleteOn        { get; set; }

    public DTOBase()
    {
        Id = string.Empty;
        IsDeleted = false;
    }
}