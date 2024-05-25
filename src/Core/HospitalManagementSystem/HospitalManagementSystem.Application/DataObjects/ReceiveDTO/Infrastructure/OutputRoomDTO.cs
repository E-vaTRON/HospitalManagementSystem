namespace HospitalManagementSystem.Application;

public record OutputRoomDTO : RoomDTO
{
    public DepartmentDTO? DepartmentDTO { get; set; }

    public ICollection<RoomAllocationDTO>? RoomAllocationDTOs { get; set; }
    public ICollection<RoomAssignmentDTO>? RoomAssignmentDTOs { get; set; }
}