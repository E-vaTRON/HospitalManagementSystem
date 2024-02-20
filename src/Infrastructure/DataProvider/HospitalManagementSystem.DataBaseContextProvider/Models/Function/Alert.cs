namespace HospitalManagementSystem.DataBaseContextProvider;

public class Alert : ModelBase
{
    public DateTime     AlertDate   { get; set; }
    public string?      Status      { get; set; } // could be 'sent', 'not sent', etc.
    public string?      Message     { get; set; }

    public string?  UserId  { get; set; }
    public User     User    { get; set; } = default!;

    public string?          AppointmentId       { get; set; }
    public Appointment      Appointment         { get; set; } = default!;
    public string?          RoomAllocationId    { get; set; }
    public RoomAllocation   RoomAllocation      { get; set; } = default!;
    public string?          RoomAssignmentId    { get; set; }
    public RoomAssignment   RoomAssignment      { get; set; } = default!;
}