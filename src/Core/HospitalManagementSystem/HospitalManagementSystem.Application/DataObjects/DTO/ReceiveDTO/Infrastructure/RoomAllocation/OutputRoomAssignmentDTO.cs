namespace HospitalManagementSystem.Application;

public record OutputRoomAssignmentDTO : RoomAssignmentDTO
{
    public RoomDTO? RoomDTO { get; init; }
}