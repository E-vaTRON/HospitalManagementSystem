namespace HospitalManagementSystem.Domain;

public class Room : EntityBase
{
    public string       Name        { get; set; } = string.Empty;
    public RoomType     RoomType    { get; set;}

    public string?      DepartmentId    { get; set;}
    public Department   Department      { get; set; } = default!;
}
