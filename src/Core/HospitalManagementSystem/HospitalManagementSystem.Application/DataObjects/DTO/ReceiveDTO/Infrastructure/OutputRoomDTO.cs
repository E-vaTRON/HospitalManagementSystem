namespace HospitalManagementSystem.Application;

public record OutputRoomDTO : RoomDTO
{
    public OutputDepartmentDTO? DepartmentDTO { get; init; }

    public ICollection<OutputRoomAllocationDTO>? RoomAllocationDTOs { get; init; }
    //public ICollection<OutputRoomAssignmentDTO>? RoomAssignmentDTOs { get; init; }
}