namespace HospitalManagementSystem.Application;

public class DepartmentDTO : DTOBase
{
    public string   Name    { get; set; } = string.Empty;
    public virtual ICollection<RoomDTO> RoomDTOs { get; set; } = new HashSet<RoomDTO>();
}
