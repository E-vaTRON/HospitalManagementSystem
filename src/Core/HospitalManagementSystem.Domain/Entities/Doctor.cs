namespace HospitalManagementSystem.Domain;

public class Doctor : User
{
    public bool     Verified        { get; set; }
    public int?     SpecialistLevel { get; set; }

    public virtual ICollection<Specialization>      Specializations     { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<HistoryMedicalExam>  Exams               { get; set; } = new HashSet<HistoryMedicalExam>();
}
