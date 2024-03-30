namespace HospitalManagementSystem.DataProvider;

public class Employee : User
{
    public virtual ICollection<RoomAssignment>  RoomAssignments     { get; set; } = new HashSet<RoomAssignment>();
    public virtual ICollection<Specialization>  Specializations     { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<ScheduleDay>     EmployeeSchedules   { get; set; } = new HashSet<ScheduleDay>();
}
