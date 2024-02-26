namespace HospitalManagementSystem.DataProvider;

public class Employee : User
{
    public virtual ICollection<Specialization>      Specializations     { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<EmployeeSchedule>    EmployeeSchedules   { get; set; } = new HashSet<EmployeeSchedule>();
}
