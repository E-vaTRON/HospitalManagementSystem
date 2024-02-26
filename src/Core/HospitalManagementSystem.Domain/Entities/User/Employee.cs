namespace HospitalManagementSystem.Domain;

public class Employee : User
{
    public virtual ICollection<RoomAssignment>      RoomAssignments     { get; set; } = new HashSet<RoomAssignment>();
    public virtual ICollection<Specialization>      Specializations     { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<EmployeeSchedule>    EmployeeSchedules   { get; set; } = new HashSet<EmployeeSchedule>();
}
