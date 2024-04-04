namespace HospitalManagementSystem.Domain;

public class Patient
{
    public virtual ICollection<MedicalExam> Exams { get; set; } = new HashSet<MedicalExam>();
    public virtual ICollection<ReExamAppointment> ReExamAppointments { get; set; } = new HashSet<ReExamAppointment>();
}