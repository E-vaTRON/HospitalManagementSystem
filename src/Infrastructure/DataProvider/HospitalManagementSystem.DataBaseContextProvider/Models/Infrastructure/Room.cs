namespace HospitalManagementSystem.DataProvider;

public class Room : ModelBase
{
    public string       Name        { get; set; } = string.Empty;
    public RoomType     RoomType    { get; set; }
    public int          Capacity    { get; set; }
    public RoomStatus   Status      { get; set; }

    public string?      DepartmentId    { get; set;}
    public Department   Department      { get; set; } = default!;

    public virtual ICollection<RoomAllocation>  RoomAllocations     { get; set; } = new HashSet<RoomAllocation>();
    public virtual ICollection<RoomAssignment>  RoomAssignments     { get; set; } = new HashSet<RoomAssignment>(); /// ???
}