namespace HospitalManagementSystem.DataProvider;

public class Patient : User
{
    public virtual ICollection<MedicalExam>     Exams           { get; set; } = new HashSet<MedicalExam>();
    public virtual ICollection<Appointment>     Appointments    { get; set; } = new HashSet<Appointment>();
}