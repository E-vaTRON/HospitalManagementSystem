namespace HospitalManagementSystem.Application;

public record OutputRoomDTO : RoomDTO
{
    public OutputDepartmentDTO? Department { get; init; }

    public ICollection<OutputRoomAllocationDTO>? RoomAllocations { get; init; }
    //public ICollection<OutputRoomAssignmentDTO>? RoomAssignmentDTOs { get; init; }
}