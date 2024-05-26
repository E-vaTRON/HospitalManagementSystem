namespace HospitalManagementSystem.Application;

public record InputRoomAssignmentDTO : RoomAssignmentDTO
{
    public string? RoomDTOId { get; init; }
}
