namespace HospitalManagementSystem.DataBaseContextProvider;

public class BaseModel<T>
{
    public T? Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; }
}
