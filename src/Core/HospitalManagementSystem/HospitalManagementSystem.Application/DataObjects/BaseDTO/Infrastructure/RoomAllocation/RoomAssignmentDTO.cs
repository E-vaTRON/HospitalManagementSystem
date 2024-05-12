namespace HospitalManagementSystem.Application;

public class RoomAssignmentDTO : DTOBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  EmployeeId  { get; set; } // User Id Role<Employee>

    public RoomDTO  RoomDTO    { get; set; } = default!;
}
