namespace HospitalManagementSystem.Application;

public class RoomDTO : DTOBase
{
    public string       Name        { get; set; } = string.Empty;
    public RoomType     RoomType    { get; set; }
    public int          Capacity    { get; set; }
    public RoomStatus   Status      { get; set; }

    public DepartmentDTO    DepartmentDTO    { get; set; } = default!;

    public virtual ICollection<RoomAllocationDTO>  RoomAllocationDTOs     { get; set; } = new HashSet<RoomAllocationDTO>();
    public virtual ICollection<RoomAssignmentDTO>  RoomAssignmentDTOs     { get; set; } = new HashSet<RoomAssignmentDTO>(); /// ???
}