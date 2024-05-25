namespace HospitalManagementSystem.Application;

public record InputRoomDTO : RoomDTO
{
    public string? DepartmentDTOId { get; init; }
}