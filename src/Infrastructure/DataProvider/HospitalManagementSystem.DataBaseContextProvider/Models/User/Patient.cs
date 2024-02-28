namespace HospitalManagementSystem.DataProvider;

public class Patient : User
{
    public virtual ICollection<MedicalExam>     Exams           { get; set; } = new HashSet<MedicalExam>();
    public virtual ICollection<AppointmentBase>     Appointments    { get; set; } = new HashSet<AppointmentBase>();
    public virtual ICollection<RoomAllocation>  RoomAllocations { get; set; } = new HashSet<RoomAllocation>();
}