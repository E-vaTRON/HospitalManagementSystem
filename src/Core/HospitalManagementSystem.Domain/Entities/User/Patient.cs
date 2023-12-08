namespace HospitalManagementSystem.Domain;

public class Patient : User
{
    public virtual ICollection<MedicalExam>  Exams   { get; set; } = new HashSet<MedicalExam>();
}
