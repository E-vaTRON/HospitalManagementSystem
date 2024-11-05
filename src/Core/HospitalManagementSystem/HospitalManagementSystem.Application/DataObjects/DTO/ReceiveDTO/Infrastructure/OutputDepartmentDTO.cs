namespace HospitalManagementSystem.Application;

public record OutputDepartmentDTO : DepartmentDTO
{
    public ICollection<OutputRoomDTO>? Rooms { get; init; }
}
