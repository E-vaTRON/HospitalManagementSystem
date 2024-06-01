namespace HospitalManagementSystem.Application;

public record OutputDepartmentDTO : DepartmentDTO
{
    public ICollection<OutputRoomDTO>? RoomDTOs { get; init; }
}
