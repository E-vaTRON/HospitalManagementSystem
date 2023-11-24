namespace HospitalManagementSystem.Domain;

public class Doctor : User
{
    public bool     Verified    { get; set; }
    public bool     IsDoctor    { get; set; }

    public virtual ICollection<HistoryMedicalExam>  Exams   { get; set; } = new HashSet<HistoryMedicalExam>();
}
