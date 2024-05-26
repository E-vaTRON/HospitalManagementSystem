namespace HospitalManagementSystem.Application;

public record RoomAssignmentDTO : DTOBase
{
    public DateTime     StartTime   { get; init; }
    public DateTime     EndTime     { get; set; }

    public string?  EmployeeId  { get; init; } // User Id Role<Employee>
}
