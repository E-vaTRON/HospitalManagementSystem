namespace HospitalManagementSystem.Domain;

public class Employee : User
{
    public virtual ICollection<MedicalExamEposode>  Exams           { get; set; } = new HashSet<MedicalExamEposode>();
    public virtual ICollection<Specialization>      Specializations { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<Availability>        Availabilities  { get; set; } = new HashSet<Availability>();
}
