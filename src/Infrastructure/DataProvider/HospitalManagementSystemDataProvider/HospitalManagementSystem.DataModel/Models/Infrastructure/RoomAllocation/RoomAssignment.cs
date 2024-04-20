﻿namespace HospitalManagementSystem.DataProvider;

public class RoomAssignment : ModelBase
{
    public DateTime     StartTime   { get; set; }
    public DateTime     EndTime     { get; set; }

    public string?  EmployeeId  { get; set; } // User Id Role<Employee>

    public Guid?        RoomId      { get; set; }
    public Room         Room        { get; set; } = default!;
}
