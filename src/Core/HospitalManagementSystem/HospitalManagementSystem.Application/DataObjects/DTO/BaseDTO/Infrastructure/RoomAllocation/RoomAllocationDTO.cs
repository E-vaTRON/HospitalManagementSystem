namespace HospitalManagementSystem.Application;

public record RoomAllocationDTO : DTOBase
{
    public DateTime     StartTime   { get; init; }
    public DateTime     EndTime     { get; init; }

    public string?  PatientId   { get; init; } // User Id Role<Patient>
    public string?  EmployeeId  { get; init; } // User Id Role<Employee>
}