namespace HospitalManagementSystem.Application;

public record OutputRoomDTO : RoomDTO
{
    public DepartmentDTO? DepartmentDTO { get; init; }

    public ICollection<RoomAllocationDTO>? RoomAllocationDTOs { get; init; }
    public ICollection<RoomAssignmentDTO>? RoomAssignmentDTOs { get; init; }
}