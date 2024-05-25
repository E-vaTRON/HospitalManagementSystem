namespace HospitalManagementSystem.Application;

public record OutputDepartmentDTO : DepartmentDTO
{
    public ICollection<RoomDTO>? RoomDTOs { get; init; }
}
