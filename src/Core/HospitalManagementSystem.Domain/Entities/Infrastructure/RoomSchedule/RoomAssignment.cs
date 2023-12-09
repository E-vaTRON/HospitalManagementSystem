namespace HospitalManagementSystem.Domain;

public class RoomAssignment
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?      RoomId      { get; set; }
    public Room         Room        { get; set; } = default!;
    public string?      EmployeeId  { get; set; }
    public Employee     Employee    { get; set; } = default!;
}
